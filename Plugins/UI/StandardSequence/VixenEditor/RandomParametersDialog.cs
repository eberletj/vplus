namespace VixenEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class RandomParametersDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private CheckBox checkBoxIntensityLevel;
        private CheckBox checkBoxUseSaturation;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private bool m_actualLevels;
        private NumericUpDown numericUpDownIntensityMax;
        private NumericUpDown numericUpDownIntensityMin;
        private NumericUpDown numericUpDownPeriodLength;
        private NumericUpDown numericUpDownSaturationLevel;

        public RandomParametersDialog(int minLevel, int maxLevel, bool actualLevels)
        {
            this.InitializeComponent();
            this.m_actualLevels = actualLevels;
            if (actualLevels)
            {
                this.label7.Visible = this.label8.Visible = false;
                this.numericUpDownIntensityMin.Minimum = this.numericUpDownIntensityMax.Minimum = minLevel;
                this.numericUpDownIntensityMin.Maximum = this.numericUpDownIntensityMax.Maximum = maxLevel;
            }
            else
            {
                this.numericUpDownIntensityMin.Minimum = this.numericUpDownIntensityMax.Minimum = (minLevel * 100) / 0xff;
                this.numericUpDownIntensityMin.Maximum = this.numericUpDownIntensityMax.Maximum = (maxLevel * 100) / 0xff;
            }
            this.numericUpDownIntensityMax.Value = this.numericUpDownIntensityMax.Maximum;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.numericUpDownSaturationLevel = new NumericUpDown();
            this.label2 = new Label();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox1 = new GroupBox();
            this.checkBoxUseSaturation = new CheckBox();
            this.label3 = new Label();
            this.groupBox2 = new GroupBox();
            this.numericUpDownPeriodLength = new NumericUpDown();
            this.label4 = new Label();
            this.groupBox3 = new GroupBox();
            this.label9 = new Label();
            this.label8 = new Label();
            this.numericUpDownIntensityMax = new NumericUpDown();
            this.label7 = new Label();
            this.numericUpDownIntensityMin = new NumericUpDown();
            this.label6 = new Label();
            this.label5 = new Label();
            this.checkBoxIntensityLevel = new CheckBox();
            this.numericUpDownSaturationLevel.BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.numericUpDownPeriodLength.BeginInit();
            this.groupBox3.SuspendLayout();
            this.numericUpDownIntensityMax.BeginInit();
            this.numericUpDownIntensityMin.BeginInit();
            base.SuspendLayout();
            this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.label1.Location = new Point(0x10, 0x17);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xec, 0x37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adjust the saturation level to determine how many channels are on during a given event period.  The default is 50%, meaning half of the channels will be on.";
            this.numericUpDownSaturationLevel.Location = new Point(0x62, 0x5e);
            this.numericUpDownSaturationLevel.Name = "numericUpDownSaturationLevel";
            this.numericUpDownSaturationLevel.Size = new Size(0x2e, 20);
            this.numericUpDownSaturationLevel.TabIndex = 2;
            int[] bits = new int[4];
            bits[0] = 50;
            this.numericUpDownSaturationLevel.Value = new decimal(bits);
            this.numericUpDownSaturationLevel.Enter += new EventHandler(this.UpDownEnter);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x94, 0x60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new Point(0x7c, 0x1b1);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0xcd, 0x1b1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.checkBoxUseSaturation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownSaturationLevel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x10c, 0x89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.checkBoxUseSaturation.ForeColor = Color.FromArgb(0, 70, 0xd5);
            this.checkBoxUseSaturation.Location = new Point(8, -4);
            this.checkBoxUseSaturation.Name = "checkBoxUseSaturation";
            this.checkBoxUseSaturation.Size = new Size(110, 0x18);
            this.checkBoxUseSaturation.TabIndex = 0;
            this.checkBoxUseSaturation.Text = "Ensure Saturation";
            this.checkBoxUseSaturation.UseVisualStyleBackColor = true;
            this.label3.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.label3.Location = new Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x10c, 0x30);
            this.label3.TabIndex = 0;
            this.label3.Text = "If you want a truly random result with no intensity variation, you can press Enter or click OK right now.  Or you can adjust the parameters below.";
            this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.numericUpDownPeriodLength);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new Point(12, 0xcb);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x10c, 0x6c);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period length";
            this.numericUpDownPeriodLength.Location = new Point(0x62, 0x43);
            bits = new int[4];
            bits[0] = 1;
            this.numericUpDownPeriodLength.Minimum = new decimal(bits);
            this.numericUpDownPeriodLength.Name = "numericUpDownPeriodLength";
            this.numericUpDownPeriodLength.Size = new Size(0x2e, 20);
            this.numericUpDownPeriodLength.TabIndex = 1;
            bits = new int[4];
            bits[0] = 1;
            this.numericUpDownPeriodLength.Value = new decimal(bits);
            this.numericUpDownPeriodLength.Enter += new EventHandler(this.UpDownEnter);
            this.label4.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.label4.Location = new Point(0x10, 0x1b);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0xec, 0x21);
            this.label4.TabIndex = 0;
            this.label4.Text = "How many event periods would you like each 'on' event to last?";
            this.groupBox3.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numericUpDownIntensityMax);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDownIntensityMin);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.checkBoxIntensityLevel);
            this.groupBox3.Location = new Point(12, 0x13d);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x10c, 110);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Intensity levels";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x7d, 0x4b);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x19, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "and";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0xc7, 0x4b);
            this.label8.Name = "label8";
            this.label8.Size = new Size(15, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "%";
            this.numericUpDownIntensityMax.Location = new Point(0x9f, 0x49);
            this.numericUpDownIntensityMax.Name = "numericUpDownIntensityMax";
            this.numericUpDownIntensityMax.Size = new Size(40, 20);
            this.numericUpDownIntensityMax.TabIndex = 6;
            this.numericUpDownIntensityMax.Enter += new EventHandler(this.UpDownEnter);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x6f, 0x4b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(15, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "%";
            this.numericUpDownIntensityMin.Location = new Point(0x47, 0x49);
            this.numericUpDownIntensityMin.Name = "numericUpDownIntensityMin";
            this.numericUpDownIntensityMin.Size = new Size(40, 20);
            this.numericUpDownIntensityMin.TabIndex = 3;
            this.numericUpDownIntensityMin.Enter += new EventHandler(this.UpDownEnter);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x10, 0x4b);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x31, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Between";
            this.label5.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.label5.Location = new Point(0x10, 0x1d);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0xec, 0x21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Randomly adjust the intensity level of the activated cells within a specified range.";
            this.checkBoxIntensityLevel.AutoSize = true;
            this.checkBoxIntensityLevel.ForeColor = Color.FromArgb(0, 70, 0xd5);
            this.checkBoxIntensityLevel.Location = new Point(8, 0);
            this.checkBoxIntensityLevel.Name = "checkBoxIntensityLevel";
            this.checkBoxIntensityLevel.Size = new Size(0x7b, 0x11);
            this.checkBoxIntensityLevel.TabIndex = 0;
            this.checkBoxIntensityLevel.Text = "Vary Intensity Levels";
            this.checkBoxIntensityLevel.UseVisualStyleBackColor = true;
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x124, 0x1d4);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "RandomParametersDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Random Parameters";
            this.numericUpDownSaturationLevel.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.numericUpDownPeriodLength.EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.numericUpDownIntensityMax.EndInit();
            this.numericUpDownIntensityMin.EndInit();
            base.ResumeLayout(false);
        }

        private void UpDownEnter(object sender, EventArgs e)
        {
            ((NumericUpDown) sender).Select(0, ((NumericUpDown) sender).Value.ToString().Length);
        }

        public int IntensityMax
        {
            get
            {
                if (this.m_actualLevels)
                {
                    return (int) this.numericUpDownIntensityMax.Value;
                }
                return ((((int) this.numericUpDownIntensityMax.Value) * 0xff) / 100);
            }
        }

        public int IntensityMin
        {
            get
            {
                if (this.m_actualLevels)
                {
                    return (int) this.numericUpDownIntensityMin.Value;
                }
                return ((((int) this.numericUpDownIntensityMin.Value) * 0xff) / 100);
            }
        }

        public int PeriodLength
        {
            get
            {
                return (int) this.numericUpDownPeriodLength.Value;
            }
        }

        public float SaturationLevel
        {
            get
            {
                return (((float) this.numericUpDownSaturationLevel.Value) / 100f);
            }
        }

        public bool UseSaturation
        {
            get
            {
                return this.checkBoxUseSaturation.Checked;
            }
        }

        public bool VaryIntensity
        {
            get
            {
                return this.checkBoxIntensityLevel.Checked;
            }
        }
    }
}

