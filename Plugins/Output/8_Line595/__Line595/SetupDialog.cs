namespace __Line595
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Vixen.Dialogs;

    public class SetupDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private Button buttonPortSetup;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private int m_portAddress;
        private TextBox textBoxChannels;

        public SetupDialog(int channelCount, int portAddress, byte linesUsed)
        {
            this.InitializeComponent();
            this.textBoxChannels.Text = channelCount.ToString();
            this.checkBox1.Checked = (linesUsed & 1) > 0;
            this.checkBox2.Checked = (linesUsed & 2) > 0;
            this.checkBox3.Checked = (linesUsed & 4) > 0;
            this.checkBox4.Checked = (linesUsed & 8) > 0;
            this.checkBox5.Checked = (linesUsed & 0x10) > 0;
            this.checkBox6.Checked = (linesUsed & 0x20) > 0;
            this.checkBox7.Checked = (linesUsed & 0x40) > 0;
            this.checkBox8.Checked = (linesUsed & 0x80) > 0;
            this.m_portAddress = portAddress;
        }

        private void buttonPortSetup_Click(object sender, EventArgs e)
        {
            ParallelSetupDialog dialog = new ParallelSetupDialog(this.m_portAddress);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.m_portAddress = dialog.PortAddress;
            }
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
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.checkBox8 = new CheckBox();
            this.checkBox7 = new CheckBox();
            this.checkBox6 = new CheckBox();
            this.checkBox5 = new CheckBox();
            this.checkBox4 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.textBoxChannels = new TextBox();
            this.label1 = new Label();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox2 = new GroupBox();
            this.buttonPortSetup = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBoxChannels);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 0x4d);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xe9, 0x117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel Distribution";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x15, 0x3a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(130, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data lines with controllers:";
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new Point(0x4e, 0xf4);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new Size(0x4d, 0x11);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Text = "Data line 7";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new Point(0x4e, 0xdd);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new Size(0x4d, 0x11);
            this.checkBox7.TabIndex = 9;
            this.checkBox7.Text = "Data line 6";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new Point(0x4e, 0xc6);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new Size(0x4d, 0x11);
            this.checkBox6.TabIndex = 8;
            this.checkBox6.Text = "Data line 5";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new Point(0x4e, 0xaf);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(0x4d, 0x11);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.Text = "Data line 4";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new Point(0x4e, 0x98);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(0x4d, 0x11);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "Data line 3";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new Point(0x4e, 0x81);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(0x4d, 0x11);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Data line 2";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new Point(0x4e, 0x6a);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(0x4d, 0x11);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Data line 1";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(0x4e, 0x53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x4d, 0x11);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Data line 0";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.textBoxChannels.Location = new Point(0xa1, 0x1a);
            this.textBoxChannels.MaxLength = 4;
            this.textBoxChannels.Name = "textBoxChannels";
            this.textBoxChannels.Size = new Size(0x24, 20);
            this.textBoxChannels.TabIndex = 2;
            this.textBoxChannels.Text = "0";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x15, 0x1d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channels per controller:";
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new Point(0x59, 0x16d);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new Point(170, 0x16d);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.buttonPortSetup);
            this.groupBox2.Location = new Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xe9, 0x3b);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port";
            this.buttonPortSetup.Location = new Point(0x3b, 0x13);
            this.buttonPortSetup.Name = "buttonPortSetup";
            this.buttonPortSetup.Size = new Size(0x73, 0x17);
            this.buttonPortSetup.TabIndex = 0;
            this.buttonPortSetup.Text = "Parallel Port Setup";
            this.buttonPortSetup.UseVisualStyleBackColor = true;
            this.buttonPortSetup.Click += new EventHandler(this.buttonPortSetup_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x101, 400);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Name = "SetupDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public int ChannelCount
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.textBoxChannels.Text);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public byte LinesUsed
        {
            get
            {
                byte num = 0;
                for (int i = 0; i < 8; i++)
                {
                    int num4 = i + 1;
                    num = (byte) (num | ((byte) (((((CheckBox) base.Controls.Find("checkBox" + num4.ToString(), 1)[0]).Checked != null) ? 1 : 0) << i)));
                }
                return num;
            }
        }

        public int PortAddress
        {
            get
            {
                return this.m_portAddress;
            }
        }
    }
}

