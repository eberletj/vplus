using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace EZ_8_Transfer
{
	public partial class EZ8_UI
	{
		private GroupBox groupBox1;
		private GroupBox groupBoxTransfer;
		private Label label1;
		private Label labelCodeProtect;
		private Label labelErasing;
		private Label labelPort;
		private Label labelRevision;
		private Label labelState;
		private System.Windows.Forms.Timer animationTimer;
		private Button buttonClose;
		private Button buttonPort;
		private Button buttonTransfer;
		private CheckBox checkBoxCodeProtect;
		private IContainer components;
		private System.Windows.Forms.Timer connectivityTimer;

		#region Windows Form Designer generated code
		
		private void InitializeComponent()
        {
            this.components = new Container();
			this.buttonPort = new Button();
            this.labelPort = new Label();
            this.connectivityTimer = new System.Windows.Forms.Timer(this.components);
            this.labelState = new Label();
            this.panel1 = new Panel();
            this.pictureBoxComputer = new PictureBox();
            this.pictureBoxArrow = new PictureBox();
            this.pictureBoxDevice = new PictureBox();
            this.groupBox1 = new GroupBox();
            this.labelRevision = new Label();
            this.groupBoxTransfer = new GroupBox();
            this.labelErasing = new Label();
            this.checkBoxCodeProtect = new CheckBox();
            this.labelCodeProtect = new Label();
            this.buttonTransfer = new Button();
            this.radioButtonToDevice = new RadioButton();
            this.radioButtonFromDevice = new RadioButton();
            this.label1 = new Label();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonClose = new Button();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxComputer).BeginInit();
            ((ISupportInitialize) this.pictureBoxArrow).BeginInit();
            ((ISupportInitialize) this.pictureBoxDevice).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxTransfer.SuspendLayout();
            base.SuspendLayout();
            this.buttonPort.Location = new Point(15, 0x1d);
            this.buttonPort.Name = "buttonPort";
            this.buttonPort.Size = new Size(0x4b, 0x17);
            this.buttonPort.TabIndex = 0;
            this.buttonPort.Text = "Port";
            this.buttonPort.UseVisualStyleBackColor = true;
            this.buttonPort.Click += new EventHandler(this.buttonPort_Click);
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new Point(0x60, 0x22);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new Size(0x43, 13);
            this.labelPort.TabIndex = 1;
            this.labelPort.Text = "Not selected";
            this.connectivityTimer.Interval = 0x7d0;
            this.connectivityTimer.Tick += new EventHandler(this.connectivityTimer_Tick);
            this.labelState.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.labelState.ForeColor = Color.Red;
            this.labelState.Location = new Point(0x107, 0x22);
            this.labelState.Name = "labelState";
            this.labelState.Size = new Size(0x80, 13);
            this.labelState.TabIndex = 2;
            this.labelState.Text = "Disconnected";
            this.labelState.TextAlign = ContentAlignment.TopRight;
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.panel1.BackColor = Color.White;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxComputer);
            this.panel1.Controls.Add(this.pictureBoxArrow);
            this.panel1.Controls.Add(this.pictureBoxDevice);
            this.panel1.Location = new Point(14, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x178, 0x4e);
            this.panel1.TabIndex = 6;
			this.pictureBoxComputer.Location = new Point(310, 14);
            this.pictureBoxComputer.Name = "pictureBoxComputer";
            this.pictureBoxComputer.Size = new Size(0x30, 0x30);
            this.pictureBoxComputer.TabIndex = 2;
            this.pictureBoxComputer.TabStop = false;
			this.pictureBoxArrow.Location = new Point(0x67, 0x17);
            this.pictureBoxArrow.Name = "pictureBoxArrow";
            this.pictureBoxArrow.Size = new Size(0xa8, 30);
            this.pictureBoxArrow.TabIndex = 1;
            this.pictureBoxArrow.TabStop = false;
            this.pictureBoxArrow.Paint += new PaintEventHandler(this.pictureBoxArrow_Paint);
            this.pictureBoxDevice.Location = new Point(15, 14);
            this.pictureBoxDevice.Name = "pictureBoxDevice";
            this.pictureBoxDevice.Size = new Size(0x30, 0x30);
            this.pictureBoxDevice.TabIndex = 0;
            this.pictureBoxDevice.TabStop = false;
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.labelRevision);
            this.groupBox1.Controls.Add(this.buttonPort);
            this.groupBox1.Controls.Add(this.labelPort);
            this.groupBox1.Controls.Add(this.labelState);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x194, 0x4d);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connectivity";
            this.labelRevision.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.labelRevision.Location = new Point(260, 0x35);
            this.labelRevision.Name = "labelRevision";
            this.labelRevision.Size = new Size(0x83, 13);
            this.labelRevision.TabIndex = 3;
            this.labelRevision.TextAlign = ContentAlignment.TopRight;
            this.groupBoxTransfer.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBoxTransfer.Controls.Add(this.labelErasing);
            this.groupBoxTransfer.Controls.Add(this.checkBoxCodeProtect);
            this.groupBoxTransfer.Controls.Add(this.labelCodeProtect);
            this.groupBoxTransfer.Controls.Add(this.buttonTransfer);
            this.groupBoxTransfer.Controls.Add(this.radioButtonToDevice);
            this.groupBoxTransfer.Controls.Add(this.radioButtonFromDevice);
            this.groupBoxTransfer.Controls.Add(this.label1);
            this.groupBoxTransfer.Controls.Add(this.panel1);
            this.groupBoxTransfer.Enabled = false;
            this.groupBoxTransfer.Location = new Point(13, 0x5f);
            this.groupBoxTransfer.Name = "groupBoxTransfer";
            this.groupBoxTransfer.Size = new Size(0x193, 0x108);
            this.groupBoxTransfer.TabIndex = 1;
            this.groupBoxTransfer.TabStop = false;
            this.groupBoxTransfer.Text = "Upload/Download";
            this.labelErasing.AutoSize = true;
            this.labelErasing.ForeColor = Color.Blue;
            this.labelErasing.Location = new Point(0x11, 0x9d);
            this.labelErasing.Name = "labelErasing";
            this.labelErasing.Size = new Size(0x33, 13);
            this.labelErasing.TabIndex = 7;
            this.labelErasing.Text = "Erasing...";
            this.labelErasing.Visible = false;
            this.checkBoxCodeProtect.AutoSize = true;
            this.checkBoxCodeProtect.Enabled = false;
            this.checkBoxCodeProtect.Location = new Point(0xb5, 0x4c);
            this.checkBoxCodeProtect.Name = "checkBoxCodeProtect";
            this.checkBoxCodeProtect.Size = new Size(140, 0x11);
            this.checkBoxCodeProtect.TabIndex = 3;
            this.checkBoxCodeProtect.Text = "Turn on code protection";
            this.checkBoxCodeProtect.UseVisualStyleBackColor = true;
            this.checkBoxCodeProtect.CheckedChanged += new EventHandler(this.checkBoxCodeProtect_CheckedChanged);
            this.labelCodeProtect.AutoSize = true;
            this.labelCodeProtect.Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelCodeProtect.ForeColor = Color.Red;
            this.labelCodeProtect.Location = new Point(0x7a, 0x93);
            this.labelCodeProtect.Name = "labelCodeProtect";
            this.labelCodeProtect.Size = new Size(0x9f, 0x10);
            this.labelCodeProtect.TabIndex = 5;
            this.labelCodeProtect.Text = "CODE PROTECT IS ON";
            this.labelCodeProtect.Visible = false;
            this.buttonTransfer.Location = new Point(0xa4, 0x79);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new Size(0x4b, 0x17);
            this.buttonTransfer.TabIndex = 4;
            this.buttonTransfer.Text = "Start";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new EventHandler(this.buttonTransfer_Click);
            this.radioButtonToDevice.AutoSize = true;
            this.radioButtonToDevice.Location = new Point(0xa2, 0x39);
            this.radioButtonToDevice.Name = "radioButtonToDevice";
            this.radioButtonToDevice.Size = new Size(0xb5, 0x11);
            this.radioButtonToDevice.TabIndex = 2;
            this.radioButtonToDevice.Text = "From the sequence to the device";
            this.radioButtonToDevice.UseVisualStyleBackColor = true;
            this.radioButtonToDevice.CheckedChanged += new EventHandler(this.radioButtonToDevice_CheckedChanged);
            this.radioButtonFromDevice.AutoSize = true;
            this.radioButtonFromDevice.Checked = true;
            this.radioButtonFromDevice.Location = new Point(0xa2, 0x22);
            this.radioButtonFromDevice.Name = "radioButtonFromDevice";
            this.radioButtonFromDevice.Size = new Size(0xb5, 0x11);
            this.radioButtonFromDevice.TabIndex = 1;
            this.radioButtonFromDevice.TabStop = true;
            this.radioButtonFromDevice.Text = "From the device to the sequence";
            this.radioButtonFromDevice.UseVisualStyleBackColor = true;
            this.radioButtonFromDevice.CheckedChanged += new EventHandler(this.radioButtonFromDevice_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1b, 0x24);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "I want to transfer data:";
            this.animationTimer.Interval = 50;
            this.animationTimer.Tick += new EventHandler(this.animationTimer_Tick);
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new Point(0x155, 0x16d);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(0x4b, 0x17);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x1ac, 400);
            base.Controls.Add(this.buttonClose);
            base.Controls.Add(this.groupBoxTransfer);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "EZ8_UI";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EZ-8 Upload/Download";
            base.VisibleChanged += new EventHandler(this.EZ8_UI_VisibleChanged);
            base.FormClosing += new FormClosingEventHandler(this.EZ8_UI_FormClosing);
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.pictureBoxComputer).EndInit();
            ((ISupportInitialize) this.pictureBoxArrow).EndInit();
            ((ISupportInitialize) this.pictureBoxDevice).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxTransfer.ResumeLayout(false);
            this.groupBoxTransfer.PerformLayout();
            base.ResumeLayout(false);
        }
		#endregion

		protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}