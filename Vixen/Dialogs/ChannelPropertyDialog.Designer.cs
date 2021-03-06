using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenPlus.Dialogs {
    public partial class ChannelPropertyDialog {
        private IContainer components = null;

        #region Windows Form Designer generated code

        private Button buttonClose;
        private Button buttonColor;
        private Button buttonDimmingCurve;
        private Button buttonNext;
        private Button buttonPrev;
        private CheckBox checkBoxEnabled;
        private ColorDialog colorDialog;
        private ComboBox comboBoxChannels;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelOutputChannel;
        private TextBox textBoxName;


        private void InitializeComponent() {
            this.groupBox1 = new GroupBox();
            this.buttonDimmingCurve = new Button();
            this.checkBoxEnabled = new CheckBox();
            this.labelOutputChannel = new Label();
            this.label3 = new Label();
            this.buttonColor = new Button();
            this.label2 = new Label();
            this.textBoxName = new TextBox();
            this.label1 = new Label();
            this.buttonClose = new Button();
            this.buttonPrev = new Button();
            this.buttonNext = new Button();
            this.comboBoxChannels = new ComboBox();
            this.colorDialog = new ColorDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonDimmingCurve);
            this.groupBox1.Controls.Add(this.checkBoxEnabled);
            this.groupBox1.Controls.Add(this.labelOutputChannel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(268, 192);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel";
            // 
            // buttonDimmingCurve
            // 
            this.buttonDimmingCurve.Location = new Point(17, 149);
            this.buttonDimmingCurve.Name = "buttonDimmingCurve";
            this.buttonDimmingCurve.Size = new Size(106, 23);
            this.buttonDimmingCurve.TabIndex = 7;
            this.buttonDimmingCurve.Text = "Dimming Curve";
            this.buttonDimmingCurve.UseVisualStyleBackColor = true;
            this.buttonDimmingCurve.Click += new EventHandler(this.buttonDimmingCurve_Click);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Location = new Point(112, 105);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new Size(65, 17);
            this.checkBoxEnabled.TabIndex = 6;
            this.checkBoxEnabled.Text = "Enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // labelOutputChannel
            // 
            this.labelOutputChannel.AutoSize = true;
            this.labelOutputChannel.Location = new Point(109, 83);
            this.labelOutputChannel.Name = "labelOutputChannel";
            this.labelOutputChannel.Size = new Size(100, 13);
            this.labelOutputChannel.TabIndex = 5;
            this.labelOutputChannel.Text = "labelOutputChannel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output channel:";
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new Point(112, 51);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new Size(75, 23);
            this.buttonColor.TabIndex = 3;
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new EventHandler(this.buttonColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new Point(112, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new Size(150, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.buttonClose.DialogResult = DialogResult.OK;
            this.buttonClose.Location = new Point(205, 239);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new Point(12, 12);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new Size(23, 23);
            this.buttonPrev.TabIndex = 0;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new Point(41, 12);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new Size(23, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new EventHandler(this.buttonNext_Click);
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.DrawMode = DrawMode.OwnerDrawFixed;
            this.comboBoxChannels.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new Point(70, 14);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new Size(198, 21);
            this.comboBoxChannels.TabIndex = 2;
            this.comboBoxChannels.DrawItem += new DrawItemEventHandler(this.comboBoxChannels_DrawItem);
            this.comboBoxChannels.SelectedIndexChanged += new EventHandler(this.comboBoxChannels_SelectedIndexChanged);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // ChannelPropertyDialog
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new Size(292, 274);
            this.Controls.Add(this.comboBoxChannels);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelPropertyDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Channel Properties";
            this.Load += new EventHandler(this.ChannelPropertyDialog_Load);
            this.KeyPress += new KeyPressEventHandler(this.ChannelPropertyDialog_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
