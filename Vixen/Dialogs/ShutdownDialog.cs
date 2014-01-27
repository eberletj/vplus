using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dialogs
{
    internal partial class ShutdownDialog : Form
    {
        public ShutdownDialog()
        {
            InitializeComponent();
            labelShutdownMessage.Text =
                string.Format(
                    "{0} is shutting down your computer in 30 seconds.\n\nYou can stop this by clicking the Abort button below.",
                    Vendor.ProductName);
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/a");
            Close();
        }
    }
}