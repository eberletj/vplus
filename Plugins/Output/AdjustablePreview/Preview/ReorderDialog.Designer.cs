namespace Preview {
	using System;
	using System.Drawing;
	using System.Windows.Forms;

	internal partial class ReorderDialog {
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonCancel;
		private Button buttonClear;
		private Button buttonCopy;
		private Button buttonOK;
		private ComboBox comboBoxFrom;
		private ComboBox comboBoxTo;
		private GroupBox groupBox1;
		private Label label1;
		private Label label2;
		private Label label3;

		private void InitializeComponent() {
			this.label1 = new Label();
			this.label2 = new Label();
			this.comboBoxFrom = new ComboBox();
			this.label3 = new Label();
			this.comboBoxTo = new ComboBox();
			this.buttonClear = new Button();
			this.buttonCopy = new Button();
			this.groupBox1 = new GroupBox();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(20, 26);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0xf1, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Copy the cells drawn from one channel to another";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(20, 0x41);
			this.label2.Name = "label2";
			this.label2.Size = new Size(30, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "From";
			this.comboBoxFrom.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxFrom.FormattingEnabled = true;
			this.comboBoxFrom.Location = new Point(0x4c, 0x3e);
			this.comboBoxFrom.Name = "comboBoxFrom";
			this.comboBoxFrom.Size = new Size(0xb9, 0x15);
			this.comboBoxFrom.TabIndex = 2;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(25, 0x67);
			this.label3.Name = "label3";
			this.label3.Size = new Size(20, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "To";
			this.comboBoxTo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxTo.FormattingEnabled = true;
			this.comboBoxTo.Location = new Point(0x4c, 100);
			this.comboBoxTo.Name = "comboBoxTo";
			this.comboBoxTo.Size = new Size(0xb9, 0x15);
			this.comboBoxTo.TabIndex = 4;
			this.buttonClear.Location = new Point(0x4c, 160);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new Size(0x75, 23);
			this.buttonClear.TabIndex = 5;
			this.buttonClear.Text = "Clear this channel";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
			this.buttonCopy.Location = new Point(0x4c, 0x83);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new Size(0x75, 23);
			this.buttonCopy.TabIndex = 6;
			this.buttonCopy.Text = "Copy to this channel";
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Click += new EventHandler(this.buttonCopy_Click);
			this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.buttonCopy);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.buttonClear);
			this.groupBox1.Controls.Add(this.comboBoxFrom);
			this.groupBox1.Controls.Add(this.comboBoxTo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0x11d, 0xc9);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Copy Cells";
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0x8d, 0xe2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 23);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0xde, 0xe2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 23);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x135, 0x105);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ReorderDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Copy";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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