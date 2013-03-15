namespace Spectrum
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class TranscribeDialog : Form
    {
        private IContainer components = null;
        private ProgressBar progressBar;

        public TranscribeDialog(int maximum)
        {
            this.InitializeComponent();
            this.progressBar.Maximum = maximum;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.progressBar = new ProgressBar();
            base.SuspendLayout();
            this.progressBar.Location = new Point(12, 0x16);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(0x13a, 0x17);
            this.progressBar.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x152, 0x42);
            base.ControlBox = false;
            base.Controls.Add(this.progressBar);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Name = "TranscribeDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Transcribing...";
            base.ResumeLayout(false);
        }

        public int Progress
        {
            set
            {
                this.progressBar.Value = value;
                this.Refresh();
            }
        }
    }
}

