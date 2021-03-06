using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using VixenPlus;

using VixenPlusCommon;
using VixenPlusCommon.Annotations;

namespace Controllers.Launcher {

    [UsedImplicitly]
    public class Launcher : IEventDrivenOutputPlugIn {
        private SetupDialog _dialog;

        private XmlNode _setupNode;
        private readonly Dictionary<byte, string[]> _targets = new Dictionary<byte, string[]>();


        public void Event(byte[] channelValues) {
            foreach (var channelValue in channelValues) {
                string[] strArray;
                if (!_targets.TryGetValue(channelValue, out strArray)) {
                    continue;
                }

                var process = new Process {StartInfo = new ProcessStartInfo(strArray[0], strArray[1])};
                process.Start();
            }
        }


        public void Initialize(IExecutable executableObject, SetupData setupData, XmlNode setupNode) {
            _setupNode = setupNode;
            if (_setupNode.SelectSingleNode("Programs") == null) {
                Xml.GetNodeAlways(_setupNode, "Programs");
            }
        }


        public Control Setup() {
            var programList = _setupNode.SelectNodes("Programs/Program");
            if (programList == null) {
                return null;
            }

            var num = 0;
            var programs = new string[programList.Count][];
            foreach (var node in programList.Cast<XmlNode>().Where(node => node.Attributes != null)) {
                // Already checked in the LINQ
                // ReSharper disable PossibleNullReferenceException
                programs[num++] = new[]
                    {node.InnerText, node.Attributes["params"].Value, node.Attributes["trigger"].Value};
                // ReSharper restore PossibleNullReferenceException
            }

            _dialog = new SetupDialog(programs);

            return _dialog;
        }


        public void GetSetup() {
            if (null == _dialog) {
                return;
            }

            var contextNode = _setupNode.SelectSingleNode("Programs");
            if (contextNode == null) {
                return;
            }

            contextNode.RemoveAll();
            foreach (var parameters in _dialog.Programs) {
                var programNode = Xml.SetNewValue(contextNode, "Program", parameters[0]);
                Xml.SetAttribute(programNode, "params", parameters[1]);
                Xml.SetAttribute(programNode, "trigger", parameters[2]);
            }
        }


        public void CloseSetup() {
            if (_dialog == null) {
                return;
            }

            _dialog.Dispose();
            _dialog = null;
        }


        public bool SupportsLiveSetup() {
            return true;
        }


        public void Shutdown() {}


        public void Startup() {
            _targets.Clear();
            var programsNode = _setupNode.SelectNodes("Programs/Program");
            if (programsNode == null) {
                return;
            }

            foreach (XmlNode programNode in programsNode) {
                if (programNode.Attributes == null) {
                    continue;
                }
                var num = (byte) Convert.ToSingle(programNode.Attributes["trigger"].Value).ToValue();
                if (File.Exists(programNode.InnerText)) {
                    _targets[num] = new[] {programNode.InnerText, programNode.Attributes["params"].Value};
                }
            }
        }


        public override string ToString() {
            return Name;
        }


        [UsedImplicitly]
        public string Author {
            get { return "Vixen and VixenPlus Developers"; }
        }

        [UsedImplicitly]
        public string Description {
            get { return "External program launcher"; }
        }

        public string HardwareMap {
            get {
                var res = "Nothing Setup Yet";
                var programList = _setupNode.SelectNodes("Programs/Program");

                if (null == programList) {
                    return res;
                }

                var config = new StringBuilder();
                foreach (var node in programList.Cast<XmlNode>().Where(node => node.Attributes != null)) {
                    // Already checked in the LINQ
                    // ReSharper disable PossibleNullReferenceException
                    config.Append(string.Format("Launch '{0}' with '{1}' at {2}%", node.InnerText,
                        node.Attributes["params"].Value, node.Attributes["trigger"].Value))
                        .Append(Environment.NewLine);
                    // ReSharper restore PossibleNullReferenceException
                }

                res = config.ToString();
                if (res.Length >= Environment.NewLine.Length) {
                    res = res.Substring(0, res.Length - Environment.NewLine.Length);
                }

                return res;
            }
        }

        public string Name {
            get { return "Launcher"; }
        }
    }
}
