namespace VixenPlus.Dialogs{
	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.Collections;

	public partial class TextQueryDialog{
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonCancel;
private Button buttonOK;
private Label labelQuery;
private TextBox textBoxResponse;

		private void InitializeComponent()
        {
            this.labelQuery = new Label();
            this.textBoxResponse = new TextBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            base.SuspendLayout();
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new Point(11, 12);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new Size(35, 13);
            this.labelQuery.TabIndex = 0;
            this.labelQuery.Text = "label1";
            this.textBoxResponse.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.textBoxResponse.Location = new Point(10, 33);
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.Size = new Size(396, 20);
            this.textBoxResponse.TabIndex = 1;
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new Point(246, 68);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new Point(327, 68);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(414, 99);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.textBoxResponse);
            base.Controls.Add(this.labelQuery);
            base.Name = "TextQueryDialog";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.ResumeLayout(false);
            base.PerformLayout();
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
