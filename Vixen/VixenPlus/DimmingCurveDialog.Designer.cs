using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace VixenPlus
{
	internal partial class DimmingCurveDialog
	{
		private IContainer components;

		#region Windows Form Designer generated code
		private Button buttonCancel;
private Button buttonExportToLibrary;
private Button buttonImportFromLibrary;
private Button buttonOK;
private Button buttonResetToLinear;
private Button buttonSwitchDisplay;
private ComboBox comboBoxChannels;
private ComboBox comboBoxExport;
private ComboBox comboBoxImport;
private Label label1;
private Label label2;
private Label labelChannelValue;
private Label labelMessage;
private Label labelSequenceChannels;
private Panel panel1;
private PictureBox pictureBoxCurve;
private PictureBox pbMini;

		private void InitializeComponent()
		{
			this.pbMini = new PictureBox();
			this.pictureBoxCurve = new PictureBox();
			this.labelChannelValue = new Label();
			this.buttonResetToLinear = new Button();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.comboBoxChannels = new ComboBox();
			this.labelSequenceChannels = new Label();
			this.buttonSwitchDisplay = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.buttonImportFromLibrary = new Button();
			this.buttonExportToLibrary = new Button();
			this.labelMessage = new Label();
			this.panel1 = new Panel();
			this.comboBoxImport = new ComboBox();
			this.comboBoxExport = new ComboBox();
			((ISupportInitialize) this.pbMini).BeginInit();
			((ISupportInitialize) this.pictureBoxCurve).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.pbMini.BackColor = Color.White;
			this.pbMini.Location = new Point(0, 0);
			this.pbMini.Name = "pictureBoxMini";
			this.pbMini.Size = new Size(0x100, 0x100);
			this.pbMini.TabIndex = 0;
			this.pbMini.TabStop = false;
			this.pbMini.MouseMove += new MouseEventHandler(this.pictureBoxMini_MouseMove);
			this.pbMini.MouseDown += new MouseEventHandler(this.pictureBoxMini_MouseDown);
			this.pbMini.Paint += new PaintEventHandler(this.pictureBoxMini_Paint);
			this.pictureBoxCurve.BackColor = Color.FloralWhite;
			this.pictureBoxCurve.Location = new Point(0x112, 0x1f);
			this.pictureBoxCurve.Name = "pictureBoxCurve";
			this.pictureBoxCurve.Size = new Size(0x1c1, 0x1c1);
			this.pictureBoxCurve.TabIndex = 1;
			this.pictureBoxCurve.TabStop = false;
			this.pictureBoxCurve.MouseLeave += new EventHandler(this.pictureBoxCurve_MouseLeave);
			this.pictureBoxCurve.MouseMove += new MouseEventHandler(this.pictureBoxCurve_MouseMove);
			this.pictureBoxCurve.Paint += new PaintEventHandler(this.pictureBoxCurve_Paint);
			this.pictureBoxCurve.MouseUp += new MouseEventHandler(this.pictureBoxCurve_MouseUp);
			this.labelChannelValue.AutoSize = true;
			this.labelChannelValue.Location = new Point(0x115, 13);
			this.labelChannelValue.Name = "labelChannelValue";
			this.labelChannelValue.Size = new Size(0, 13);
			this.labelChannelValue.TabIndex = 13;
			this.buttonResetToLinear.Enabled = false;
			this.buttonResetToLinear.Location = new Point(12, 0x125);
			this.buttonResetToLinear.Name = "buttonResetToLinear";
			this.buttonResetToLinear.Size = new Size(0x63, 0x17);
			this.buttonResetToLinear.TabIndex = 6;
			this.buttonResetToLinear.Text = "Reset to linear";
			this.buttonResetToLinear.UseVisualStyleBackColor = true;
			this.buttonResetToLinear.Click += new EventHandler(this.buttonResetToLinear_Click);
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0x238, 0x1eb);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 0x17);
			this.buttonOK.TabIndex = 7;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0x289, 0x1eb);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 0x17);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.comboBoxChannels.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxChannels.FormattingEnabled = true;
			this.comboBoxChannels.Location = new Point(15, 0x161);
			this.comboBoxChannels.Name = "comboBoxChannels";
			this.comboBoxChannels.Size = new Size(0xfd, 0x15);
			this.comboBoxChannels.TabIndex = 1;
			this.comboBoxChannels.SelectedIndexChanged += new EventHandler(this.comboBoxChannels_SelectedIndexChanged);
			this.labelSequenceChannels.AutoSize = true;
			this.labelSequenceChannels.Location = new Point(12, 0x151);
			this.labelSequenceChannels.Name = "labelSequenceChannels";
			this.labelSequenceChannels.Size = new Size(0x66, 13);
			this.labelSequenceChannels.TabIndex = 0;
			this.labelSequenceChannels.Text = "Sequence channels";
			this.buttonSwitchDisplay.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
			this.buttonSwitchDisplay.Location = new Point(0x164, 0x1f5);
			this.buttonSwitchDisplay.Name = "buttonSwitchDisplay";
			this.buttonSwitchDisplay.Size = new Size(120, 0x17);
			this.buttonSwitchDisplay.TabIndex = 14;
			this.buttonSwitchDisplay.Text = "Show";
			this.buttonSwitchDisplay.UseVisualStyleBackColor = true;
			this.buttonSwitchDisplay.Visible = false;
			this.buttonSwitchDisplay.Click += new EventHandler(this.buttonSwitchDisplay_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(0x115, 0x1e3);
			this.label1.Name = "label1";
			this.label1.Size = new Size(40, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Input >";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(0x102, 0x1df);
			this.label2.Name = "label2";
			this.label2.Size = new Size(0, 13);
			this.label2.TabIndex = 9;
			this.buttonImportFromLibrary.Location = new Point(15, 0x18c);
			this.buttonImportFromLibrary.Name = "buttonImportFromLibrary";
			this.buttonImportFromLibrary.Size = new Size(0x4b, 0x17);
			this.buttonImportFromLibrary.TabIndex = 2;
			this.buttonImportFromLibrary.Text = "Import";
			this.buttonImportFromLibrary.UseVisualStyleBackColor = true;
			this.buttonImportFromLibrary.Click += new EventHandler(this.buttonImportFromLibrary_Click);
			this.buttonExportToLibrary.Location = new Point(15, 0x1a9);
			this.buttonExportToLibrary.Name = "buttonExportToLibrary";
			this.buttonExportToLibrary.Size = new Size(0x4b, 0x17);
			this.buttonExportToLibrary.TabIndex = 4;
			this.buttonExportToLibrary.Text = "Export";
			this.buttonExportToLibrary.UseVisualStyleBackColor = true;
			this.buttonExportToLibrary.Click += new EventHandler(this.buttonExportToLibrary_Click);
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new Point(12, 0x1f0);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new Size(0, 13);
			this.labelMessage.TabIndex = 12;
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pbMini);
			this.panel1.Location = new Point(12, 0x1f);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(0x102, 0x102);
			this.panel1.TabIndex = 11;
			this.comboBoxImport.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxImport.FormattingEnabled = true;
			this.comboBoxImport.Items.AddRange(new object[] { "curve from the library", "curves from a file" });
			this.comboBoxImport.Location = new Point(0x60, 0x18e);
			this.comboBoxImport.Name = "comboBoxImport";
			this.comboBoxImport.Size = new Size(0x85, 0x15);
			this.comboBoxImport.TabIndex = 3;
			this.comboBoxExport.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxExport.FormattingEnabled = true;
			this.comboBoxExport.Items.AddRange(new object[] { "curve to the library", "curves to a file" });
			this.comboBoxExport.Location = new Point(0x60, 0x1ab);
			this.comboBoxExport.Name = "comboBoxExport";
			this.comboBoxExport.Size = new Size(0x85, 0x15);
			this.comboBoxExport.TabIndex = 5;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x2e0, 0x20e);
			base.Controls.Add(this.comboBoxExport);
			base.Controls.Add(this.comboBoxImport);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.labelMessage);
			base.Controls.Add(this.buttonExportToLibrary);
			base.Controls.Add(this.buttonImportFromLibrary);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.buttonSwitchDisplay);
			base.Controls.Add(this.labelSequenceChannels);
			base.Controls.Add(this.comboBoxChannels);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.buttonResetToLinear);
			base.Controls.Add(this.labelChannelValue);
			base.Controls.Add(this.pictureBoxCurve);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DimmingCurveDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Dimming Curve";
			base.Paint += new PaintEventHandler(this.DimmingCurveDialog_Paint);
			((ISupportInitialize) this.pbMini).EndInit();
			((ISupportInitialize) this.pictureBoxCurve).EndInit();
			this.panel1.ResumeLayout(false);
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
			this.m_miniBackBrush.Dispose();
			this.m_curveBackBrush.Dispose();
			this.m_miniBoxPen.Dispose();
			this.m_miniLinePen.Dispose();
			this.m_curveGridPen.Dispose();
			this.m_curveLinePen.Dispose();
			this.m_curvePointBrush.Dispose();
			base.Dispose(disposing);
		}
	}
}
