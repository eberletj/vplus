namespace Olsen595
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class SetupDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private CheckBox checkBoxParallel1;
        private CheckBox checkBoxParallel2;
        private CheckBox checkBoxParallel3;
        private IContainer components = null;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private XmlNode m_setupNode;
        private TextBox textBoxParallel1From;
        private TextBox textBoxParallel1To;
        private TextBox textBoxParallel2From;
        private TextBox textBoxParallel2To;
        private TextBox textBoxParallel3From;
        private TextBox textBoxParallel3To;

        public SetupDialog(XmlNode setupNode)
        {
            this.InitializeComponent();
            this.m_setupNode = setupNode;
            XmlNode node = this.m_setupNode.SelectSingleNode("parallel1");
            this.textBoxParallel1From.Text = node.Attributes["from"].Value;
            this.textBoxParallel1To.Text = node.Attributes["to"].Value;
            node = this.m_setupNode.SelectSingleNode("parallel2");
            this.textBoxParallel2From.Text = node.Attributes["from"].Value;
            this.textBoxParallel2To.Text = node.Attributes["to"].Value;
            node = this.m_setupNode.SelectSingleNode("parallel3");
            this.textBoxParallel3From.Text = node.Attributes["from"].Value;
            this.textBoxParallel3To.Text = node.Attributes["to"].Value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            XmlNode node = this.m_setupNode.SelectSingleNode("parallel1");
            node.Attributes["from"].Value = this.textBoxParallel1From.Text;
            node.Attributes["to"].Value = this.textBoxParallel1To.Text;
            node = this.m_setupNode.SelectSingleNode("parallel2");
            node.Attributes["from"].Value = this.textBoxParallel2From.Text;
            node.Attributes["to"].Value = this.textBoxParallel2To.Text;
            node = this.m_setupNode.SelectSingleNode("parallel3");
            node.Attributes["from"].Value = this.textBoxParallel3From.Text;
            node.Attributes["to"].Value = this.textBoxParallel3To.Text;
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
            this.textBoxParallel3To = new TextBox();
            this.label4 = new Label();
            this.textBoxParallel3From = new TextBox();
            this.checkBoxParallel3 = new CheckBox();
            this.textBoxParallel2To = new TextBox();
            this.label3 = new Label();
            this.textBoxParallel2From = new TextBox();
            this.checkBoxParallel2 = new CheckBox();
            this.textBoxParallel1To = new TextBox();
            this.label2 = new Label();
            this.textBoxParallel1From = new TextBox();
            this.label1 = new Label();
            this.checkBoxParallel1 = new CheckBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxParallel3To);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxParallel3From);
            this.groupBox1.Controls.Add(this.checkBoxParallel3);
            this.groupBox1.Controls.Add(this.textBoxParallel2To);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxParallel2From);
            this.groupBox1.Controls.Add(this.checkBoxParallel2);
            this.groupBox1.Controls.Add(this.textBoxParallel1To);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxParallel1From);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxParallel1);
            this.groupBox1.Location = new Point(14, 0x12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x116, 0xa1);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port mappings";
            this.textBoxParallel3To.Location = new Point(0xd8, 0x75);
            this.textBoxParallel3To.Name = "textBoxParallel3To";
            this.textBoxParallel3To.Size = new Size(40, 20);
            this.textBoxParallel3To.TabIndex = 12;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xc2, 120);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x10, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "to";
            this.textBoxParallel3From.Location = new Point(0x94, 0x75);
            this.textBoxParallel3From.Name = "textBoxParallel3From";
            this.textBoxParallel3From.Size = new Size(40, 20);
            this.textBoxParallel3From.TabIndex = 10;
            this.checkBoxParallel3.AutoSize = true;
            this.checkBoxParallel3.Location = new Point(13, 0x5d);
            this.checkBoxParallel3.Name = "checkBoxParallel3";
            this.checkBoxParallel3.Size = new Size(0x5b, 0x11);
            this.checkBoxParallel3.TabIndex = 9;
            this.checkBoxParallel3.Text = "Use Parallel 3";
            this.checkBoxParallel3.UseVisualStyleBackColor = true;
            this.checkBoxParallel3.Visible = false;
            this.textBoxParallel2To.Location = new Point(0xd8, 80);
            this.textBoxParallel2To.Name = "textBoxParallel2To";
            this.textBoxParallel2To.Size = new Size(40, 20);
            this.textBoxParallel2To.TabIndex = 8;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xc2, 0x53);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x10, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "to";
            this.textBoxParallel2From.Location = new Point(0x94, 80);
            this.textBoxParallel2From.Name = "textBoxParallel2From";
            this.textBoxParallel2From.Size = new Size(40, 20);
            this.textBoxParallel2From.TabIndex = 6;
            this.checkBoxParallel2.AutoSize = true;
            this.checkBoxParallel2.Location = new Point(13, 0x38);
            this.checkBoxParallel2.Name = "checkBoxParallel2";
            this.checkBoxParallel2.Size = new Size(0x5b, 0x11);
            this.checkBoxParallel2.TabIndex = 5;
            this.checkBoxParallel2.Text = "Use Parallel 2";
            this.checkBoxParallel2.UseVisualStyleBackColor = true;
            this.checkBoxParallel2.Visible = false;
            this.textBoxParallel1To.Location = new Point(0xd8, 0x2b);
            this.textBoxParallel1To.Name = "textBoxParallel1To";
            this.textBoxParallel1To.Size = new Size(40, 20);
            this.textBoxParallel1To.TabIndex = 4;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xc2, 0x2e);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "to";
            this.textBoxParallel1From.Location = new Point(0x94, 0x2b);
            this.textBoxParallel1From.Name = "textBoxParallel1From";
            this.textBoxParallel1From.Size = new Size(40, 20);
            this.textBoxParallel1From.TabIndex = 2;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xa5, 0x10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel Range";
            this.checkBoxParallel1.AutoSize = true;
            this.checkBoxParallel1.Location = new Point(13, 0x13);
            this.checkBoxParallel1.Name = "checkBoxParallel1";
            this.checkBoxParallel1.Size = new Size(0x5b, 0x11);
            this.checkBoxParallel1.TabIndex = 0;
            this.checkBoxParallel1.Text = "Use Parallel 1";
            this.checkBoxParallel1.UseVisualStyleBackColor = true;
            this.checkBoxParallel1.Visible = false;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new Point(0x88, 0xc0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0xd9, 0xc0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(10, 0x2e);
            this.label5.Name = "label5";
            this.label5.Size = new Size(50, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Parallel 1";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(10, 0x53);
            this.label6.Name = "label6";
            this.label6.Size = new Size(50, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Parallel 2";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(10, 120);
            this.label7.Name = "label7";
            this.label7.Size = new Size(50, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Parallel 3";
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x12e, 0xe3);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "SetupDialog";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

