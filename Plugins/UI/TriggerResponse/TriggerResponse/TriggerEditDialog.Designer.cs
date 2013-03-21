namespace TriggerResponse {
	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.ComponentModel;
	using System.Collections;

	internal partial class TriggerEditDialog {
		private IContainer components;

		#region Windows Form Designer generated code
		private Button buttonCancel;
		private Button buttonFindSequence;
		private Button buttonOK;
		private ComboBox comboBoxAudioDevice;
		private ComboBox comboBoxLines;
		private ComboBox comboBoxTriggers;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private OpenFileDialog openFileDialog;
		private TextBox textBoxDescription;
		private TextBox textBoxSequence;

		private void InitializeComponent() {
			this.label1 = new Label();
			this.comboBoxTriggers = new ComboBox();
			this.label2 = new Label();
			this.comboBoxLines = new ComboBox();
			this.label3 = new Label();
			this.textBoxDescription = new TextBox();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.label4 = new Label();
			this.textBoxSequence = new TextBox();
			this.buttonFindSequence = new Button();
			this.openFileDialog = new OpenFileDialog();
			this.groupBox1 = new GroupBox();
			this.groupBox2 = new GroupBox();
			this.comboBoxAudioDevice = new ComboBox();
			this.label5 = new Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(0x12, 0x1b);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0x3f, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Trigger type";
			this.comboBoxTriggers.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxTriggers.FormattingEnabled = true;
			this.comboBoxTriggers.Location = new Point(0x67, 0x18);
			this.comboBoxTriggers.Name = "comboBoxTriggers";
			this.comboBoxTriggers.Size = new Size(0xd0, 0x15);
			this.comboBoxTriggers.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(0x152, 0x1b);
			this.label2.Name = "label2";
			this.label2.Size = new Size(0x1b, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Line";
			this.comboBoxLines.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxLines.FormattingEnabled = true;
			this.comboBoxLines.Location = new Point(0x177, 0x18);
			this.comboBoxLines.Name = "comboBoxLines";
			this.comboBoxLines.Size = new Size(0x35, 0x15);
			this.comboBoxLines.TabIndex = 3;
			this.comboBoxLines.DropDown += new EventHandler(this.comboBoxLines_DropDown);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(0x12, 0x44);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Description";
			this.textBoxDescription.Location = new Point(0x67, 0x41);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new Size(0xd0, 20);
			this.textBoxDescription.TabIndex = 5;
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0x13a, 0xef);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 0x17);
			this.buttonOK.TabIndex = 9;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0x18b, 0xef);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 0x17);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(0x12, 0x22);
			this.label4.Name = "label4";
			this.label4.Size = new Size(0x38, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Sequence";
			this.textBoxSequence.Location = new Point(0x67, 0x1f);
			this.textBoxSequence.Name = "textBoxSequence";
			this.textBoxSequence.ReadOnly = true;
			this.textBoxSequence.Size = new Size(0x12e, 20);
			this.textBoxSequence.TabIndex = 7;
			this.buttonFindSequence.Location = new Point(0x194, 30);
			this.buttonFindSequence.Name = "buttonFindSequence";
			this.buttonFindSequence.Size = new Size(0x18, 0x15);
			this.buttonFindSequence.TabIndex = 8;
			this.buttonFindSequence.Text = "...";
			this.buttonFindSequence.UseVisualStyleBackColor = true;
			this.buttonFindSequence.Click += new EventHandler(this.buttonFindSequence_Click);
			this.openFileDialog.Title = "Select a sequence";
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBoxTriggers);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboBoxLines);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxDescription);
			this.groupBox1.Location = new Point(20, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0x1bd, 0x6a);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Trigger";
			this.groupBox2.Controls.Add(this.comboBoxAudioDevice);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBoxSequence);
			this.groupBox2.Controls.Add(this.buttonFindSequence);
			this.groupBox2.Location = new Point(20, 0x7c);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(0x1bd, 0x6d);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Response";
			this.comboBoxAudioDevice.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxAudioDevice.FormattingEnabled = true;
			this.comboBoxAudioDevice.Location = new Point(0x67, 0x48);
			this.comboBoxAudioDevice.Name = "comboBoxAudioDevice";
			this.comboBoxAudioDevice.Size = new Size(0x12e, 0x15);
			this.comboBoxAudioDevice.TabIndex = 10;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(0x12, 0x4b);
			this.label5.Name = "label5";
			this.label5.Size = new Size(0x45, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Audio device";
			base.AcceptButton = this.buttonOK;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x1e2, 0x112);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "TriggerEditDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Trigger Response Edit";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
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