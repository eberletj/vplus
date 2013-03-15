namespace Vixen.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO.Ports;
    using System.Text;
    using System.Windows.Forms;
    using Vixen;

    public class SerialSetupDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private ComboBox comboBoxBaudRate;
        private ComboBox comboBoxParity;
        private ComboBox comboBoxPortName;
        private ComboBox comboBoxStop;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDownPort;
        private TextBox textBoxData;

        public SerialSetupDialog(SerialPort serialPort)
        {
            this.components = null;
            this.InitializeComponent();
            this.comboBoxPortName.Items.AddRange(SerialPort.GetPortNames());
            this.Init(serialPort);
        }

        public SerialSetupDialog(SerialPort serialPort, bool allowPortEdit, bool allowBaudEdit, bool allowParityEdit, bool allowDataEdit, bool allowStopEdit)
        {
            this.components = null;
            this.InitializeComponent();
            this.comboBoxPortName.Items.AddRange(SerialPort.GetPortNames());
            this.comboBoxPortName.Enabled = allowPortEdit;
            this.comboBoxBaudRate.Enabled = allowBaudEdit;
            this.comboBoxParity.Enabled = allowParityEdit;
            this.textBoxData.Enabled = allowDataEdit;
            this.comboBoxStop.Enabled = allowStopEdit;
            this.Init(serialPort);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.None;
            StringBuilder builder = new StringBuilder();
            if (this.comboBoxPortName.SelectedIndex == -1)
            {
                builder.AppendLine("* Port name has not been selected.");
            }
            if (this.comboBoxBaudRate.SelectedIndex == -1)
            {
                builder.AppendLine("* Baud rate has not been selected.");
            }
            if (this.comboBoxParity.SelectedIndex == -1)
            {
                builder.AppendLine("* Parity has not been selected.");
            }
            int result = 0;
            if (!int.TryParse(this.textBoxData.Text, out result))
            {
                builder.AppendLine("* Invalid numeric value for data bits.");
            }
            if (this.comboBoxStop.SelectedIndex == -1)
            {
                builder.AppendLine("* Stop bits have not been selected.");
            }
            if (builder.Length > 0)
            {
                MessageBox.Show("The following items need to be resolved:\n\n" + builder.ToString(), Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                base.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void Init(SerialPort serialPort)
        {
            this.comboBoxParity.Items.Add(Parity.Even);
            this.comboBoxParity.Items.Add(Parity.Mark);
            this.comboBoxParity.Items.Add(Parity.None);
            this.comboBoxParity.Items.Add(Parity.Odd);
            this.comboBoxParity.Items.Add(Parity.Space);
            this.comboBoxStop.Items.Add(StopBits.None);
            this.comboBoxStop.Items.Add(StopBits.One);
            this.comboBoxStop.Items.Add(StopBits.OnePointFive);
            this.comboBoxStop.Items.Add(StopBits.Two);
            if (serialPort == null)
            {
                serialPort = new SerialPort("COM1", 0x9600, Parity.None, 8, StopBits.One);
            }
            this.comboBoxPortName.SelectedIndex = this.comboBoxPortName.Items.IndexOf(serialPort.PortName);
            this.comboBoxBaudRate.SelectedItem = serialPort.BaudRate.ToString();
            this.comboBoxParity.SelectedItem = serialPort.Parity;
            this.textBoxData.Text = serialPort.DataBits.ToString();
            this.comboBoxStop.SelectedItem = serialPort.StopBits;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.comboBoxBaudRate = new ComboBox();
            this.numericUpDownPort = new NumericUpDown();
            this.comboBoxStop = new ComboBox();
            this.label6 = new Label();
            this.comboBoxParity = new ComboBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.textBoxData = new TextBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.comboBoxPortName = new ComboBox();
            this.groupBox1.SuspendLayout();
            this.numericUpDownPort.BeginInit();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.comboBoxPortName);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.numericUpDownPort);
            this.groupBox1.Controls.Add(this.comboBoxStop);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxParity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxData);
            this.groupBox1.Location = new Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x131, 0x7d);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            this.comboBoxBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] { "2400", "4800", "9600", "19200", "38400", "57600", "115200" });
            this.comboBoxBaudRate.Location = new Point(0x41, 0x3f);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new Size(0x4b, 0x15);
            this.comboBoxBaudRate.TabIndex = 2;
            this.numericUpDownPort.Location = new Point(0x2d, 14);
            int[] bits = new int[4];
            bits[0] = 0x63;
            this.numericUpDownPort.Maximum = new decimal(bits);
            bits = new int[4];
            bits[0] = 1;
            this.numericUpDownPort.Minimum = new decimal(bits);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new Size(0x27, 20);
            this.numericUpDownPort.TabIndex = 10;
            bits = new int[4];
            bits[0] = 1;
            this.numericUpDownPort.Value = new decimal(bits);
            this.numericUpDownPort.Visible = false;
            this.comboBoxStop.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStop.FormattingEnabled = true;
            this.comboBoxStop.Location = new Point(200, 0x58);
            this.comboBoxStop.Name = "comboBoxStop";
            this.comboBoxStop.Size = new Size(0x5f, 0x15);
            this.comboBoxStop.TabIndex = 8;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(8, 0x10);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1f, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "COM";
            this.label6.Visible = false;
            this.comboBoxParity.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new Point(0x41, 0x58);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new Size(0x4b, 0x15);
            this.comboBoxParity.TabIndex = 4;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 0x42);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud rate";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(6, 0x5c);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x21, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Parity";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x92, 0x42);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data bits";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x92, 0x5c);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stop bits";
            this.textBoxData.Location = new Point(0xc9, 0x3f);
            this.textBoxData.MaxLength = 1;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new Size(0x27, 20);
            this.textBoxData.TabIndex = 6;
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new Point(0x9e, 0x90);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0xef, 0x90);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.comboBoxPortName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new Point(0x7a, 0x13);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new Size(0x48, 0x15);
            this.comboBoxPortName.TabIndex = 0;
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x146, 0xb3);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Name = "SerialSetupDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.numericUpDownPort.EndInit();
            base.ResumeLayout(false);
        }

        public SerialPort SelectedPort
        {
            get
            {
                return new SerialPort(this.comboBoxPortName.SelectedItem.ToString(), int.Parse(this.comboBoxBaudRate.SelectedItem.ToString()), (Parity) this.comboBoxParity.SelectedItem, int.Parse(this.textBoxData.Text), (StopBits) this.comboBoxStop.SelectedItem);
            }
        }
    }
}

