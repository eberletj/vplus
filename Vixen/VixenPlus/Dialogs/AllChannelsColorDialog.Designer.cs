namespace Vixen.Dialogs{
	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.ComponentModel;
	using System.Collections;

	public partial class AllChannelsColorDialog{
		private IContainer components;

		#region Windows Form Designer generated code
		private Button buttonCancel;
private Button buttonNewColor;
private Button buttonOK;
private ColorDialog colorDialog;
private GroupBox groupBox1;
private GroupBox groupBox2;
private ListBox listBoxChannels;
private ListBox listBoxColorsInUse;

		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.listBoxChannels = new ListBox();
			this.groupBox2 = new GroupBox();
			this.listBoxColorsInUse = new ListBox();
			this.buttonNewColor = new Button();
			this.buttonCancel = new Button();
			this.buttonOK = new Button();
			this.colorDialog = new ColorDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.listBoxChannels);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0xd4, 0x1ad);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Channels";
			this.listBoxChannels.AllowDrop = true;
			this.listBoxChannels.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.listBoxChannels.DrawMode = DrawMode.OwnerDrawFixed;
			this.listBoxChannels.FormattingEnabled = true;
			this.listBoxChannels.ItemHeight = 20;
			this.listBoxChannels.Location = new Point(0x10, 0x13);
			this.listBoxChannels.Name = "listBoxChannels";
			this.listBoxChannels.SelectionMode = SelectionMode.MultiExtended;
			this.listBoxChannels.Size = new Size(0xb7, 0x180);
			this.listBoxChannels.TabIndex = 0;
			this.listBoxChannels.DragEnter += new DragEventHandler(this.listBoxChannels_DragEnter);
			this.listBoxChannels.DragDrop += new DragEventHandler(this.listBoxChannels_DragDrop);
			this.listBoxChannels.DrawItem += new DrawItemEventHandler(this.listBoxChannels_DrawItem);
			this.groupBox2.Controls.Add(this.listBoxColorsInUse);
			this.groupBox2.Location = new Point(0xf3, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(0x84, 0x187);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Colors in use";
			this.listBoxColorsInUse.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.listBoxColorsInUse.DrawMode = DrawMode.OwnerDrawFixed;
			this.listBoxColorsInUse.FormattingEnabled = true;
			this.listBoxColorsInUse.ItemHeight = 20;
			this.listBoxColorsInUse.Location = new Point(15, 0x13);
			this.listBoxColorsInUse.Name = "listBoxColorsInUse";
			this.listBoxColorsInUse.ScrollAlwaysVisible = true;
			this.listBoxColorsInUse.Size = new Size(0x68, 0x158);
			this.listBoxColorsInUse.TabIndex = 0;
			this.listBoxColorsInUse.DrawItem += new DrawItemEventHandler(this.listBoxColorsInUse_DrawItem);
			this.listBoxColorsInUse.MouseMove += new MouseEventHandler(this.listBoxColorsInUse_MouseMove);
			this.listBoxColorsInUse.MouseDown += new MouseEventHandler(this.listBoxColorsInUse_MouseDown);
			this.buttonNewColor.Location = new Point(0x110, 0x1a2);
			this.buttonNewColor.Name = "buttonNewColor";
			this.buttonNewColor.Size = new Size(0x4b, 0x17);
			this.buttonNewColor.TabIndex = 3;
			this.buttonNewColor.Text = "New Color";
			this.buttonNewColor.UseVisualStyleBackColor = true;
			this.buttonNewColor.Click += new EventHandler(this.buttonNewColor_Click);
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0x130, 0x1db);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 0x17);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0xdf, 0x1db);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 0x17);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x187, 510);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.buttonNewColor);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AllChannelsColorDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Channel Colors";
			base.HelpButtonClicked += new CancelEventHandler(this.AllChannelsColorDialog_HelpButtonClicked);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		#endregion

		protected override void Dispose(bool disposing)
		{
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
			}
			this.m_brush.Dispose();
			base.Dispose(disposing);
		}
	}
}