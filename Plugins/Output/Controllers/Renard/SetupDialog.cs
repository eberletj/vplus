using System;
using System.IO.Ports;
using System.Windows.Forms;

using Controllers.Common;

namespace Controllers.Renard {
    public partial class SetupDialog : Form {
        public SetupDialog(SerialPort selectedPort, bool holdPort) {
            InitializeComponent();
            SelectedPort = selectedPort;
            checkBoxHoldPort.Checked = holdPort;
        }


        private void buttonSerialSetup_Click(object sender, EventArgs e) {
            using (var dialog = new SerialSetupDialog(SelectedPort)) {
                dialog.Show();
                //if (dialog.Show() == DialogResult.OK) {
                //    SelectedPort = dialog.SelectedPort;
                //}
            }
        }


        public bool HoldPort {
            get { return checkBoxHoldPort.Checked; }
        }


        public SerialPort SelectedPort { get; private set; }
    }
}
