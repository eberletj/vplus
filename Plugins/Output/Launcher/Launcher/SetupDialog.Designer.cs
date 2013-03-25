namespace Launcher {
	using System;
	using System.Drawing;
	using System.Windows.Forms;

	public partial class SetupDialog {
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonAdd;
		private Button buttonCancel;
		private Button buttonFileDialog;
		private Button buttonOK;
		private Button buttonRemove;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private GroupBox groupBox1;
		private ListView listViewPrograms;
		private OpenFileDialog openFileDialog;
		private TextBox textBoxParameters;
		private TextBox textBoxPath;
		private TextBox textBoxTriggerValue;

		private void InitializeComponent() {
			this.groupBox1 = new GroupBox();
			this.textBoxPath = new TextBox();
			this.textBoxTriggerValue = new TextBox();
			this.textBoxParameters = new TextBox();
			this.buttonRemove = new Button();
			this.buttonAdd = new Button();
			this.buttonFileDialog = new Button();
			this.listViewPrograms = new ListView();
			this.columnHeader1 = new ColumnHeader();
			this.columnHeader2 = new ColumnHeader();
			this.columnHeader3 = new ColumnHeader();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.openFileDialog = new OpenFileDialog();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.textBoxPath);
			this.groupBox1.Controls.Add(this.textBoxTriggerValue);
			this.groupBox1.Controls.Add(this.textBoxParameters);
			this.groupBox1.Controls.Add(this.buttonRemove);
			this.groupBox1.Controls.Add(this.buttonAdd);
			this.groupBox1.Controls.Add(this.buttonFileDialog);
			this.groupBox1.Controls.Add(this.listViewPrograms);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0x287, 0xb0);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Programs to launch";
			this.textBoxPath.BorderStyle = BorderStyle.None;
			this.textBoxPath.Location = new Point(0x80, 0x7e);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new Size(100, 13);
			this.textBoxPath.TabIndex = 6;
			this.textBoxPath.Visible = false;
			this.textBoxPath.Leave += new EventHandler(this.textBoxPath_Leave);
			this.textBoxPath.KeyDown += new KeyEventHandler(this.textBoxPath_KeyDown);
			this.textBoxTriggerValue.BorderStyle = BorderStyle.None;
			this.textBoxTriggerValue.Location = new Point(0x1b7, 0x7e);
			this.textBoxTriggerValue.Name = "textBoxTriggerValue";
			this.textBoxTriggerValue.Size = new Size(100, 13);
			this.textBoxTriggerValue.TabIndex = 8;
			this.textBoxTriggerValue.Visible = false;
			this.textBoxTriggerValue.Leave += new EventHandler(this.textBoxPath_Leave);
			this.textBoxTriggerValue.KeyDown += new KeyEventHandler(this.textBoxPath_KeyDown);
			this.textBoxParameters.BorderStyle = BorderStyle.None;
			this.textBoxParameters.Location = new Point(290, 0x33);
			this.textBoxParameters.Name = "textBoxParameters";
			this.textBoxParameters.Size = new Size(0x91, 13);
			this.textBoxParameters.TabIndex = 7;
			this.textBoxParameters.Visible = false;
			this.textBoxParameters.Leave += new EventHandler(this.textBoxPath_Leave);
			this.textBoxParameters.KeyDown += new KeyEventHandler(this.textBoxPath_KeyDown);
			this.buttonRemove.Enabled = false;
			this.buttonRemove.Location = new Point(0x22d, 0x33);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new Size(0x4b, 23);
			this.buttonRemove.TabIndex = 5;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new EventHandler(this.buttonRemove_Click);
			this.buttonAdd.Location = new Point(0x22d, 22);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new Size(0x4b, 23);
			this.buttonAdd.TabIndex = 4;
			this.buttonAdd.Text = "Add New";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new EventHandler(this.buttonAdd_Click);
			this.buttonFileDialog.Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.buttonFileDialog.Location = new Point(15, 0x81);
			this.buttonFileDialog.Name = "buttonFileDialog";
			this.buttonFileDialog.Size = new Size(24, 0x12);
			this.buttonFileDialog.TabIndex = 3;
			this.buttonFileDialog.Text = "...";
			this.buttonFileDialog.UseVisualStyleBackColor = true;
			this.buttonFileDialog.Visible = false;
			this.buttonFileDialog.Click += new EventHandler(this.buttonFileDialog_Click);
			this.listViewPrograms.Columns.AddRange(new ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
			this.listViewPrograms.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			this.listViewPrograms.LabelWrap = false;
			this.listViewPrograms.Location = new Point(13, 22);
			this.listViewPrograms.MultiSelect = false;
			this.listViewPrograms.Name = "listViewPrograms";
			this.listViewPrograms.OwnerDraw = true;
			this.listViewPrograms.Size = new Size(0x20f, 0x8b);
			this.listViewPrograms.TabIndex = 0;
			this.listViewPrograms.UseCompatibleStateImageBehavior = false;
			this.listViewPrograms.View = View.Details;
			this.listViewPrograms.DrawItem += new DrawListViewItemEventHandler(this.listViewPrograms_DrawItem);
			this.listViewPrograms.SelectedIndexChanged += new EventHandler(this.listViewPrograms_SelectedIndexChanged);
			this.listViewPrograms.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.listViewPrograms_DrawColumnHeader);
			this.listViewPrograms.ColumnWidthChanging += new ColumnWidthChangingEventHandler(this.listViewPrograms_ColumnWidthChanging);
			this.listViewPrograms.MouseDown += new MouseEventHandler(this.listViewPrograms_MouseDown);
			this.columnHeader1.Text = "Program executable path";
			this.columnHeader1.Width = 0x113;
			this.columnHeader2.Text = "Parameters";
			this.columnHeader2.Width = 0x91;
			this.columnHeader3.Text = "Trigger level (%)";
			this.columnHeader3.Width = 90;
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0x1f7, 0xcb);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0x248, 0xcb);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.openFileDialog.DefaultExt = "exe";
			this.openFileDialog.Filter = "Executable files | *.exe";
			this.openFileDialog.Title = "Select Program To Launch";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x29f, 0xee);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "SetupDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Setup";
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