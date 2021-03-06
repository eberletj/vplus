using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenPlus.Dialogs {
    internal partial class ShutdownDialog {
        private IContainer components = null;

        #region Windows Form Designer generated code

        private Button buttonAbort;
        private Label label1;
        private Label labelShutdownMessage;
        private Panel panel1;
        private PictureBox pictureBox1;


        private void InitializeComponent() {
            this.pictureBox1 = new PictureBox();
            this.label1 = new Label();
            this.panel1 = new Panel();
            this.labelShutdownMessage = new Label();
            this.buttonAbort = new Button();
            ((ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Point(13, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(36, 36);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point,
                                                       ((byte) (0)));
            this.label1.Location = new Point(83, 14);
            this.label1.Name = "label1";
            this.label1.Size = new Size(109, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shutdown!";
            // 
            // panel1
            // 
            this.panel1.BackColor = Color.White;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(276, 54);
            this.panel1.TabIndex = 2;
            // 
            // labelShutdownMessage
            // 
            this.labelShutdownMessage.Location = new Point(22, 78);
            this.labelShutdownMessage.Name = "labelShutdownMessage";
            this.labelShutdownMessage.Size = new Size(275, 49);
            this.labelShutdownMessage.TabIndex = 3;
            this.labelShutdownMessage.Text = "Vixen is shutting down your computer in 30 seconds.\r\n\r\nYou can stop this by click" +
                                             "ing the Abort button below.";
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new Point(123, 135);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new Size(75, 23);
            this.buttonAbort.TabIndex = 4;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new EventHandler(this.buttonAbort_Click);
            // 
            // ShutdownDialog
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(321, 172);
            this.ControlBox = false;
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.labelShutdownMessage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "ShutdownDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Shutdown!";
            this.TopMost = true;
            ((ISupportInitialize) (this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
