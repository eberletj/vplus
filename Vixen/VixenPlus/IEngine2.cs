﻿namespace Vixen
{
    using System;
    using System.Runtime.CompilerServices;

    internal interface IEngine2 : IObjectQuery, IDisposable
    {
        event EngineErrorHandler EngineError;

        event EventHandler ProgramEnd;

        event EventHandler SequenceChange;

        void Initialize(object obj);
        void Initialize(EventSequence obj);
        void Initialize(Profile obj);
        void Initialize(SequenceProgram obj);

        int MediaOutputDevice { get; set; }

        string Name { get; }

        ITickSource TimingSource { get; set; }
    }
}
