﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;

using FMOD;

using VixenPlus.Properties;

using VixenPlusCommon;

namespace VixenPlus {
    internal sealed class Engine8 : IDisposable, IQueryable {
        public delegate void ProgramEndDelegate();

        public delegate void SequenceChangeDelegate();

        private static readonly List<Engine8> InstanceList = new List<Engine8>();
        private readonly object _runLock;
        private EngineContext[] _engineContexts;
        private System.Timers.Timer _eventTimer;
        private fmod _fmod;
        private HardwareUpdateDelegate _hardwareUpdateDelegate;
        private Host _host;
        private bool _isLoggingEnabled;
        private bool _isRunning;
        private bool _isStopping;
        private PlugInRouter _plugInRouter;
        private int _primaryContext;
        private int _secondaryContext;
        private IEngine _secondaryEngine;
        private EngineTimer _surfacedTimer;
        private bool _useSequencePluginData;


        internal Engine8(Host host, int audioDeviceIndex) {
            IsPaused = false;
            IsLooping = false;
            _secondaryEngine = null;
            _isRunning = false;
            _runLock = new object();
            _useSequencePluginData = false;
            _primaryContext = 0;
            _secondaryContext = 1;
            AudioSpeed = 1f;
            _isLoggingEnabled = false;
            _isStopping = false;
            ConstructUsing(EngineMode.Synchronous, host, audioDeviceIndex);
        }


        internal Engine8(EngineMode mode, Host host, int audioDeviceIndex) {
            IsPaused = false;
            IsLooping = false;
            _secondaryEngine = null;
            _isRunning = false;
            _runLock = new object();
            _useSequencePluginData = false;
            _primaryContext = 0;
            _secondaryContext = 1;
            AudioSpeed = 1f;
            _isLoggingEnabled = false;
            _isStopping = false;
            ConstructUsing(mode, host, audioDeviceIndex);
        }


        public float AudioSpeed { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private XmlDocument CommDoc { get; set; }

        public SequenceProgram CurrentObject { get; private set; }

        public bool IsPaused { get; private set; }

        public bool IsRunning {
            get { return _secondaryEngine != null ? _secondaryEngine.IsRunning : _isRunning; }
        }

        public bool IsLooping { private get; set; }

        private EngineMode Mode { get; set; }

        public int Position {
            get { return _engineContexts[_primaryContext].TickCount; }
        }


        public void Dispose() {
            ReleaseSecondaryEngine();
            if (Mode == EngineMode.Synchronous) {
                if (_eventTimer != null) {
                    _eventTimer.Stop();
                    _eventTimer.Elapsed -= EventTimerElapsed;
                    _eventTimer.Dispose();
                    _eventTimer = null;
                }
                _fmod.Stop(_engineContexts[_primaryContext].SoundChannel);
                if (_engineContexts[_secondaryContext] != null) {
                    _fmod.Stop(_engineContexts[_secondaryContext].SoundChannel);
                }
                _fmod.Shutdown();
            }
            if (_plugInRouter != null) {
                try {
                    _plugInRouter.Shutdown(_engineContexts[_primaryContext].RouterContext);
                    if (_engineContexts[_secondaryContext] != null) {
                        _plugInRouter.Shutdown(_engineContexts[_secondaryContext].RouterContext);
                    }
                }
                catch (Exception exception) {
                    MessageBox.Show(Resources.engineShutDownError + exception.Message, Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (_surfacedTimer != null) {
                _surfacedTimer.Dispose();
                _surfacedTimer = null;
            }
            ProgramEnd = null;
            SequenceChange = null;
            _hardwareUpdateDelegate = null;
            if (CurrentObject != null) {
                CurrentObject.Dispose();
            }
            InstanceList.Remove(this);
            GC.SuppressFinalize(this);
        }


        public event ProgramEndDelegate ProgramEnd;

        public event SequenceChangeDelegate SequenceChange;

        private int CalcContainingSequence(int milliseconds) {
            var mills = 0;
            for (var i = 0; i < CurrentObject.EventSequences.Count; i++) {
                mills += CurrentObject.EventSequences[i].Length;
                if (milliseconds <= mills) {
                    return i;
                }
            }
            return -1;
        }

        private void ConstructUsing(EngineMode mode, Host host, int audioDeviceIndex) {
            Mode = mode;
            _host = host;
            _plugInRouter = Host.Router;
            if (mode == EngineMode.Synchronous) {
                _eventTimer = new System.Timers.Timer(1.0);
                _eventTimer.Elapsed += EventTimerElapsed;
                _fmod = fmod.GetInstance(audioDeviceIndex);
                _surfacedTimer = (Mode == EngineMode.Synchronous) ? new EngineTimer(CurrentTime) : null;
            }
            else {
                _eventTimer = null;
                _fmod = null;
                _surfacedTimer = null;
            }
            _hardwareUpdateDelegate = HardwareUpdate;
            _engineContexts = new[] {new EngineContext(), new EngineContext()};
            InstanceList.Add(this);
        }


        private void CreateScriptEngine(EventSequence sequence) {
            if ((sequence.EngineType != EngineType.Procedural) || (_secondaryEngine != null)) {
                return;
            }

            var secondaryEnginePath = Path.GetFileName(((ISystem) Interfaces.Available["ISystem"]).UserPreferences.GetString("SecondaryEngine"));

            if (secondaryEnginePath != null) {
                LoadSecondaryEngine(Path.Combine(Paths.BinaryPath, secondaryEnginePath));
            }
            if (_secondaryEngine == null) {
                return;
            }
            _secondaryEngine.HardwareUpdate = _hardwareUpdateDelegate;
            _secondaryEngine.CommDoc = CommDoc;
        }


        private int CurrentTime() {
            return (_engineContexts[_primaryContext].SoundChannel != null) && _engineContexts[_primaryContext].SoundChannel.IsPlaying
                ? (int) _engineContexts[_primaryContext].SoundChannel.Position
                : _engineContexts[_primaryContext].StartOffset + ((int) _engineContexts[_primaryContext].Timekeeper.ElapsedMilliseconds);
        }


        private int DetermineSecondarySequenceIndex() {
            var sequenceIndex = _engineContexts[_primaryContext].SequenceIndex;
            if ((sequenceIndex + 1) != CurrentObject.EventSequences.Count) {
                return (sequenceIndex + 1);
            }
            if (IsLooping) {
                return 0;
            }
            return -1;
        }


        private void ExecutionStopThread() {
            if (_secondaryEngine != null) {
                lock (_secondaryEngine) {
                    if (_secondaryEngine.IsRunning) {
                        lock (_runLock) {
                            _isRunning = false;
                            IsPaused = false;
                        }
                        _secondaryEngine.Stop();
                    }
                }
            }
            else if ((_isRunning || IsPaused) && _plugInRouter != null) {
                StopExecution();
                _engineContexts[_primaryContext].CurrentSequence = null;
                OnProgramEnd();
            }
            _isStopping = false;
        }


        ~Engine8() {
            Dispose();
        }


        private void FinalizeEngineContext(EngineContext context, bool shutdownRouterContext = true) {
            if (context == null) {
                return;
            }

            if (shutdownRouterContext && (context.RouterContext != null)) {
                _plugInRouter.Shutdown(context.RouterContext);
                context.RouterContext = null;
            }
            if (context.SoundChannel != null) {
                _fmod.ReleaseSound(context.SoundChannel);
                context.SoundChannel = null;
            }
            if (!context.Timekeeper.IsRunning) {
                return;
            }
            context.Timekeeper.Stop();
            context.Timekeeper.Reset();
        }


        private void FireEvent(EngineContext context, int index) {
            if ((!context.Timekeeper.IsRunning || !_eventTimer.Enabled) || _isStopping) {
                return;
            }

            for (var i = 0; i < context.CurrentSequence.FullChannels.Count; i++) {
                context.RouterContext.EngineBuffer[i] = context.Data[i, index];
            }
            HardwareUpdate(context.RouterContext.EngineBuffer);
        }


        public void HardwareUpdate(byte[] values) {
            if (!_isRunning || _isStopping) {
                return;
            }

            lock (_runLock) {
                if (!_isRunning || _isStopping) {
                    return;
                }

                int num;
                var context = _engineContexts[_primaryContext];
                var engineBuffer = context.RouterContext.EngineBuffer;
                values.CopyTo(engineBuffer, 0);
                _plugInRouter.BeginUpdate();
                var flag = context.LastPeriod == null;
                for (num = 0; (num < engineBuffer.Length) && !flag; num++) {
                    flag |= engineBuffer[num] != context.LastPeriod[num];
                }
                if (!flag) {
                    _plugInRouter.CancelUpdate();
                }
                else {
                    if ((context.LastPeriod != null) && (engineBuffer.Length == context.LastPeriod.Length)) {
                        engineBuffer.CopyTo(context.LastPeriod, 0);
                    }
                    var executableObject = context.RouterContext.ExecutableObject;
                    var count = executableObject.Channels.Count;
                    for (num = 0; num < count; num++) {
                        var channel = executableObject.Channels[num];
                        if (channel.DimmingCurve != null) {
                            engineBuffer[num] = channel.DimmingCurve[engineBuffer[num]];
                        }
                    }
                    for (num = 0; num < context.ChannelMask.Length; num++) {
                        engineBuffer[num] = (byte) (engineBuffer[num] & context.ChannelMask[num]);
                    }
                    try {
                        _plugInRouter.EndUpdate();
                    }
                    catch (Exception) {
                        StopExecution();
                    }
                }
            }
        }


        private void InitEngineContext(ref EngineContext context, int sequenceIndex) {
            if (context == null) {
                return;
            }

            context.Timekeeper.Stop();
            if (Host.InvokeRequired) {
                Host.Invoke(new InitEngineContextDelegate(InitEngineContext), new object[] {context, sequenceIndex});
            }
            else if ((sequenceIndex == -1) || (CurrentObject.EventSequences.Count <= sequenceIndex)) {
                FinalizeEngineContext(context);
            }
            else {
                var executableObject = CurrentObject.EventSequences[sequenceIndex].Sequence;
                if (context.RouterContext == null) {
                    context.RouterContext = _plugInRouter.CreateContext(new byte[executableObject.FullChannelCount],
                        _useSequencePluginData ? executableObject.PlugInData : CurrentObject.SetupData,
                        executableObject, _surfacedTimer);
                }
                if (CurrentObject.Mask.Length > sequenceIndex) {
                    context.ChannelMask = CurrentObject.Mask[sequenceIndex];
                }
                else if (context == _engineContexts[_primaryContext]) {
                    context.ChannelMask = _engineContexts[_secondaryContext].ChannelMask;
                }
                else {
                    context.ChannelMask = _engineContexts[_primaryContext].ChannelMask;
                }
                context.SequenceIndex = sequenceIndex;
                context.TickCount = 0;
                context.LastIndex = -1;
                context.SequenceTickLength = executableObject.Time;
                context.FadeStartTickCount = ((CurrentObject.CrossFadeLength == 0) || (CurrentObject.EventSequences.Count == 1))
                    ? 0
                    : ((IsLooping || (CurrentObject.EventSequences.Count > (sequenceIndex + 1)))
                        ? (executableObject.Time - (CurrentObject.CrossFadeLength * 1000)) : 0);
                context.StartOffset = 0;
                context.SoundChannel = executableObject.Audio != null ? _fmod.LoadSound(Path.Combine(Paths.AudioPath, executableObject.Audio.FileName), context.SoundChannel) : _fmod.LoadSound(null);
                if ((CurrentObject.CrossFadeLength != 0) && (context.SoundChannel != null)) {
                    if (IsLooping || (sequenceIndex > 0)) {
                        context.SoundChannel.SetEntryFade(CurrentObject.CrossFadeLength);
                    }
                    if (IsLooping || (CurrentObject.EventSequences.Count > (sequenceIndex + 1))) {
                        context.SoundChannel.SetExitFade(CurrentObject.CrossFadeLength);
                    }
                }
                context.CurrentSequence = executableObject;
                context.MaxEvent = context.CurrentSequence.TotalEventPeriods;
                context.LastPeriod = new byte[context.CurrentSequence.FullChannels.Count];
                for (var i = 0; i < context.LastPeriod.Length; i++) {
                    context.LastPeriod[i] = (byte) i;
                }
                context.Data = ReconfigureSourceData(executableObject);
            }
        }


        private void Initialize(EventSequence sequence) {
            switch (Mode) {
                case EngineMode.Asynchronous:
                    InitializeForAsynchronous(sequence);
                    break;
                default:
                    Initialize(new SequenceProgram(sequence));
                    break;
            }
        }


        public void Initialize(IExecutable obj) {
            var sequenceProgram = obj as SequenceProgram;
            if (sequenceProgram != null) {
                Initialize(sequenceProgram);
            }
            else {
                var eventSequence = obj as EventSequence;
                if (eventSequence != null) {
                    Initialize(eventSequence);
                }
                else {
                    var profile = obj as Profile;
                    if (profile == null) {
                        throw new Exception("Trying to initialize the engine with an unknown object type.\nType: " + obj.GetType());
                    }
                    Initialize((Profile) obj);
                }
            }
        }


        private void Initialize(Profile profile) {
            if (Mode == EngineMode.Synchronous) {
                throw new Exception("Only an asynchronous engine instance can be initialized with a profile.");
            }
            profile.Freeze();
            InitializeForAsynchronous(profile);
        }


        private void Initialize(SequenceProgram program) {
            if (Mode == EngineMode.Asynchronous) {
                InitializeForAsynchronous(program);
            }
            else {
                if (program.EventSequences.Count == 0) {
                    throw new Exception("Cannot execute a program that has no sequences.");
                }
                CurrentObject = program;
                _useSequencePluginData = CurrentObject.UseSequencePluginData;
                if (CurrentObject.EventSequences.Count > 1) {
                    if (_engineContexts[_secondaryContext] == null) {
                        _engineContexts[_secondaryContext] = new EngineContext();
                    }
                }
                else {
                    _engineContexts[_secondaryContext] = null;
                }
            }
        }


        private void InitializeForAsynchronous(IExecutable executableObject) {
            var channels = executableObject.FullChannels;
            if (channels.Count == 0) {
                throw new Exception("Trying to setup for asynchronous operation with no channels?");
            }
            if ((_engineContexts[_primaryContext].RouterContext != null) && _engineContexts[_primaryContext].RouterContext.Initialized) {
                _plugInRouter.Shutdown(_engineContexts[_primaryContext].RouterContext);
            }
            _engineContexts[_primaryContext].RouterContext = _plugInRouter.CreateContext(new byte[channels.Count], executableObject.PlugInData,
                executableObject, null);
            _engineContexts[_primaryContext].ChannelMask = executableObject.Mask[0];
            _engineContexts[_secondaryContext] = null;
            Host.Communication["CurrentObject"] = CurrentObject;
            _plugInRouter.Startup(_engineContexts[_primaryContext].RouterContext);
            _isRunning = true;
            Host.Communication["CurrentObject"] = null;
        }


        private void LoadSecondaryEngine(string enginePath) {
            if (Mode == EngineMode.Asynchronous) {
                return;
            }
            if (enginePath == null) {
                ReleaseSecondaryEngine();
                return;
            }
            IEngine engine = null;
            try {
                var assembly = Assembly.LoadFile(enginePath);
                foreach (var type in assembly.GetExportedTypes()) {
                    if (type.GetInterfaces().Any(type2 => type2.Name == "IEngine")) {
                        engine = (IEngine) Activator.CreateInstance(type);
                    }
                    if (engine != null) {
                        goto Label_00EB; // TODO: can break; go here?
                    }
                }
            }
            catch {
                MessageBox.Show(Path.GetFileName(enginePath) + Resources.EngineMissingOrInvalid);
                return;
            }
            Label_00EB:
            _secondaryEngine = engine;
            if (engine == null) {
                return;
            }

            _secondaryEngine.EngineError += SecondaryEngineError;
            _secondaryEngine.EngineStopped += SecondaryEngineStopped;
        }


        private void LogAudio(EventSequence sequence) {
            if (_isLoggingEnabled && (sequence.Audio != null)) {
                Host.LogAudio("Sequence", sequence.Name, sequence.Audio.FileName, sequence.Audio.Duration);
            }
        }


        private void EventTimerElapsed(object sender, ElapsedEventArgs e) {
            TimerTick(_engineContexts[_primaryContext]);
            if (((_engineContexts[_secondaryContext] != null) && (_engineContexts[_secondaryContext].RouterContext != null)) &&
                _engineContexts[_secondaryContext].RouterContext.Initialized) {
                TimerTick(_engineContexts[_secondaryContext]);
            }
        }


        private void OnProgramEnd() {
            if (ProgramEnd != null) {
                _host.DelegateNullMethod(ProgramEnd.Invoke);
            }
            var key = CurrentObject.Key.ToString(CultureInfo.InvariantCulture);
            Host.Communication.Remove("KeyInterceptor_" + key);
            Host.Communication.Remove("ExecutionContext_" + key);
        }


        private void OnSequenceChange() {
            if (SequenceChange != null) {
                SequenceChange();
            }
        }


        public void Pause() {
            if (((Mode == EngineMode.Asynchronous) || !IsRunning) || IsPaused) {
                return;
            }

            if (_secondaryEngine != null) {
                _secondaryEngine.Pause();
                IsPaused = true;
                _engineContexts[_primaryContext].Timekeeper.Stop();
                _isRunning = false;
            }
            else {
                _eventTimer.Stop();
                if (_engineContexts[_primaryContext].SoundChannel != null) {
                    _engineContexts[_primaryContext].SoundChannel.Paused = true;
                }
                _engineContexts[_primaryContext].Timekeeper.Stop();
                if (_engineContexts[_secondaryContext] != null) {
                    _engineContexts[_secondaryContext].Timekeeper.Stop();
                    if (_engineContexts[_secondaryContext].SoundChannel != null) {
                        _engineContexts[_secondaryContext].SoundChannel.Paused = true;
                    }
                }
                IsPaused = true;
                _isRunning = false;
            }
        }


        public bool Play(int startMillisecond, int endMillisecond, bool logAudio) {
            if (Mode == EngineMode.Asynchronous) {
                return false;
            }
            try {
                _isLoggingEnabled = logAudio;
                if (_eventTimer.Enabled) {
                    return false;
                }
                CreateScriptEngine(CurrentObject.EventSequences[0].Sequence);
                if (_secondaryEngine != null) {
                    if (IsPaused) {
                        IsPaused = false;
                    }
                    else {
                        ResetScriptEngineContext();
                        OnSequenceChange();
                        Host.Communication["CurrentObject"] = CurrentObject;
                        _plugInRouter.Startup(_engineContexts[_primaryContext].RouterContext);
                        Host.Communication["CurrentObject"] = null;
                    }
                    StartTimekeepers();
                    return _secondaryEngine.Play();
                }
                if (!IsPaused) {
                    InitEngineContext(ref _engineContexts[_primaryContext], CalcContainingSequence(startMillisecond));
                    LogAudio(_engineContexts[_primaryContext].CurrentSequence);
                    _engineContexts[_primaryContext].StartOffset = startMillisecond;
                    InitEngineContext(ref _engineContexts[_secondaryContext], DetermineSecondarySequenceIndex());
                    _engineContexts[_primaryContext].MaxEvent = (endMillisecond == 0)
                        ? _engineContexts[_primaryContext].CurrentSequence.TotalEventPeriods
                        : (endMillisecond / _engineContexts[_primaryContext].CurrentSequence.EventPeriod);
                }
                var millisecondPosition = (_engineContexts[_primaryContext].CurrentSequence.Audio != null) ? startMillisecond : -1;
                PrepareAudio(_engineContexts[_primaryContext], millisecondPosition);
                if (IsPaused) {
                    IsPaused = false;
                }
                else {
                    OnSequenceChange();
                    Host.Communication["CurrentObject"] = CurrentObject;
                    _plugInRouter.Startup(_engineContexts[_primaryContext].RouterContext);
                    Host.Communication["CurrentObject"] = null;
                }
                StartAudio(_engineContexts[_primaryContext]);
                StartTimekeepers();
                _eventTimer.Start();
                return true;
            }
            catch {
                return false;
            }
        }


        private void PrepareAudio(EngineContext context, int millisecondPosition) {
            if (((Mode == EngineMode.Asynchronous) || (context.SoundChannel == null)) || (millisecondPosition == -1)) {
                return;
            }
            _fmod.Play(context.SoundChannel, true);
            context.SoundChannel.Position = (uint) millisecondPosition;
            context.SoundChannel.Frequency = AudioSpeed;
        }

        private static byte[,] ReconfigureSourceData(EventSequence sequence) {
            var buffer = new byte[sequence.FullChannelCount,sequence.TotalEventPeriods];
            var list = sequence.FullChannels.Select(channel => channel.OutputChannel).ToList();
            for (var i = 0; i < sequence.FullChannelCount; i++) {
                var row = list[i];
                for (var column = 0; column < sequence.TotalEventPeriods; column++) {
                    buffer[row, column] = sequence.EventValues[i, column];
                }
            }
            return buffer;
        }


        private void ReleaseSecondaryEngine() {
            if (_secondaryEngine == null) {
                return;
            }
            lock (_secondaryEngine) {
                _secondaryEngine.Stop();
                _secondaryEngine.HardwareUpdate = null;
                _secondaryEngine.EngineError -= SecondaryEngineError;
                _secondaryEngine.EngineStopped -= SecondaryEngineStopped;
                _secondaryEngine.Dispose();
                _secondaryEngine = null;
                _secondaryContext = 0;
            }
        }


        private void ResetScriptEngineContext() {
            InitEngineContext(ref _engineContexts[_primaryContext], 0);
            LogAudio(_engineContexts[_primaryContext].CurrentSequence);
            if (_engineContexts[_primaryContext].SoundChannel != null) {
                _engineContexts[_primaryContext].SoundChannel.SetEntryFade(0);
            }
            _secondaryEngine.Initialize(_engineContexts[_primaryContext].CurrentSequence);
        }



        private void SecondaryEngineError(string message, string stackTrace) {
            Stop();
            MessageBox.Show(message, Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void SecondaryEngineStopped(object sender, EventArgs e) {
            if (_isRunning && IsLooping) {
                FinalizeEngineContext(_engineContexts[_primaryContext], false);
                FinalizeEngineContext(_engineContexts[_secondaryContext], false);
                ResetScriptEngineContext();
                StartTimekeepers();
                OnSequenceChange();
                _secondaryEngine.Play();
            }
            else {

                FinalizeEngineContext(_engineContexts[_primaryContext]);
                FinalizeEngineContext(_engineContexts[_secondaryContext]);
                OnProgramEnd();
            }
        }


        public void SetAudioDevice(int value) {
            _fmod.DeviceIndex = value;
        }


        private void StartAudio(EngineContext context) {
            if (((Mode != EngineMode.Asynchronous) && (context.SoundChannel != null)) && context.SoundChannel.Paused) {
                context.SoundChannel.Paused = false;
            }
        }


        private void StartContextAudio(EngineContext context) {
            if (context.CurrentSequence.Audio == null) {
                return;
            }
            if (Host.InvokeRequired) {
                MethodInvoker method = delegate {
                    PrepareAudio(context, context.StartOffset);
                    StartAudio(context);
                };
                Host.Invoke(method, new object[0]);
            }
            else {
                PrepareAudio(context, context.StartOffset);
                StartAudio(context);
            }
        }


        private void StartTimekeepers() {
            lock (_runLock) {
                _isRunning = true;
                _engineContexts[_primaryContext].Timekeeper.Start();
                if ((_engineContexts[_primaryContext].FadeStartTickCount != 0) &&
                    (_engineContexts[_primaryContext].TickCount >= _engineContexts[_primaryContext].FadeStartTickCount)) {
                    _engineContexts[_secondaryContext].Timekeeper.Start();
                }
            }
        }


        public void Stop() {
            if (_isStopping) {
                return;
            }
            _isStopping = true;
            if (Mode != EngineMode.Asynchronous) {
                new Thread(ExecutionStopThread).Start();
            }
            else {
                FinalizeEngineContext(_engineContexts[_primaryContext]);
                lock (_runLock) {
                    _isRunning = false;
                }
                _isStopping = false;
            }
        }


        private void StopExecution(bool shutdownPlugins = true) {
            lock (_runLock) {
                _isRunning = false;
            }
            if (_eventTimer != null) {
                _eventTimer.Stop();
            }
            _fmod.Stop(_engineContexts[_primaryContext].SoundChannel);
            if (_engineContexts[_secondaryContext] != null) {
                _fmod.Stop(_engineContexts[_secondaryContext].SoundChannel);
            }
            IsPaused = false;
            FinalizeEngineContext(_engineContexts[_primaryContext], shutdownPlugins);
            FinalizeEngineContext(_engineContexts[_secondaryContext], shutdownPlugins);
        }


        private void TimerTick(EngineContext context) {
            if (!_eventTimer.Enabled || _isStopping) {
                return;
            }
            context.TickCount = (context.SoundChannel != null) && context.SoundChannel.IsPlaying
                ? (int) context.SoundChannel.Position : context.StartOffset + ((int) context.Timekeeper.ElapsedMilliseconds);
            var num = context.TickCount / context.CurrentSequence.EventPeriod;
            if (((context.FadeStartTickCount != 0) && (context.TickCount >= context.FadeStartTickCount)) &&
                !_engineContexts[_secondaryContext].Timekeeper.IsRunning) {
                _eventTimer.Enabled = false;
                Host.Communication["CurrentObject"] = CurrentObject;
                _plugInRouter.Startup(_engineContexts[_secondaryContext].RouterContext);
                Host.Communication["CurrentObject"] = null;
                LogAudio(_engineContexts[_secondaryContext].CurrentSequence);
                StartContextAudio(_engineContexts[_secondaryContext]);
                if (_engineContexts[_secondaryContext].SoundChannel != null) {
                    _engineContexts[_secondaryContext].SoundChannel.Volume = 0f;
                }
                _engineContexts[_secondaryContext].Timekeeper.Start();
                _eventTimer.Enabled = true;
            }
            if ((context.TickCount >= context.SequenceTickLength) || (num >= context.MaxEvent)) {
                _fmod.Stop(context.SoundChannel);
                context.Timekeeper.Stop();
                context.Timekeeper.Reset();
                if ((_engineContexts[_secondaryContext] == null) || (_engineContexts[_secondaryContext].RouterContext == null)) {
                    if (IsLooping) {
                        LogAudio(_engineContexts[_primaryContext].CurrentSequence);
                        StartContextAudio(_engineContexts[_primaryContext]);
                        context.Timekeeper.Start();
                        OnSequenceChange();
                    }
                    else {
                        Host.Invoke(new MethodInvoker(Stop), new object[0]);
                    }
                }
                else {
                    if (_engineContexts[_secondaryContext].SoundChannel != null) {
                        _engineContexts[_secondaryContext].SoundChannel.Volume = 1f;
                    }
                    if (_engineContexts[_secondaryContext] != null) {
                        FinalizeEngineContext(_engineContexts[_primaryContext]);
                        _primaryContext ^= 1;
                        _secondaryContext ^= 1;
                        InitEngineContext(ref _engineContexts[_secondaryContext], DetermineSecondarySequenceIndex());
                    }
                    if (!_engineContexts[_primaryContext].Timekeeper.IsRunning) {
                        Host.Communication["CurrentObject"] = CurrentObject;
                        _plugInRouter.Startup(_engineContexts[_primaryContext].RouterContext);
                        Host.Communication["CurrentObject"] = null;
                        LogAudio(_engineContexts[_primaryContext].CurrentSequence);
                        StartContextAudio(_engineContexts[_primaryContext]);
                        _engineContexts[_primaryContext].Timekeeper.Start();
                    }
                    OnSequenceChange();
                }
            }
            else if (num != context.LastIndex) {
                context.LastIndex = num;
                FireEvent(context, context.LastIndex);
            }
        }


        internal enum EngineMode {
            Synchronous,
            Asynchronous
        }

        private delegate void InitEngineContextDelegate(ref EngineContext context, int sequenceIndex);
    }
}