using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenPlusServerUI
{
	public partial class PasswordDialog {

		private IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonCancel;
private Button buttonOK;
private Button buttonReset;
private GroupBox groupBox1;
private Label label1;
private TextBox textBoxPassword;

		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.buttonReset = new Button();
			this.textBoxPassword = new TextBox();
			this.label1 = new Label();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.buttonReset);
			this.groupBox1.Controls.Add(this.textBoxPassword);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0x137, 0xdb);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Control Client Password";
			this.buttonReset.Location = new Point(0x69, 0xa8);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new Size(0x65, 23);
			this.buttonReset.TabIndex = 2;
			this.buttonReset.Text = "Reset to blank";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new EventHandler(this.buttonReset_Click);
			this.textBoxPassword.Location = new Point(0x3b, 0x8e);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new Size(0xc1, 20);
			this.textBoxPassword.TabIndex = 1;
			this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.label1.Location = new Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0x12b, 0x6c);
			this.label1.TabIndex = 0;
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0xa7, 0xed);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0xf8, 0xed);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x14f, 0x10c);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "PasswordDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Password";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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
