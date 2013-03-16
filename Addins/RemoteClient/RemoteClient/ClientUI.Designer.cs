using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace RemoteClient {
	public partial class ClientUI {
		private IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonControlClientControlPanel;
		private Button buttonDone;
		private Button buttonExecutionClientControlPanel;
		private Button buttonRefresh;
		private Button buttonTest;
		private CheckBox checkBoxLocal;
		private CheckBox checkBoxRemote;
		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private GroupBox groupBoxControlClient;
		private GroupBox groupBoxExecutionClient;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label labelServerStatus;
		private OpenFileDialog openFileDialog1;
		private SaveFileDialog saveFileDialog1;
		private TextBox textBoxServer;
		private ToolTip toolTip;

		private void InitializeComponent() {
			this.components = new Container();
			this.saveFileDialog1 = new SaveFileDialog();
			this.openFileDialog1 = new OpenFileDialog();
			this.labelServerStatus = new Label();
			this.buttonDone = new Button();
			this.groupBoxExecutionClient = new GroupBox();
			this.buttonExecutionClientControlPanel = new Button();
			this.label2 = new Label();
			this.groupBox3 = new GroupBox();
			this.label1 = new Label();
			this.buttonTest = new Button();
			this.textBoxServer = new TextBox();
			this.label3 = new Label();
			this.groupBoxControlClient = new GroupBox();
			this.label4 = new Label();
			this.buttonControlClientControlPanel = new Button();
			this.toolTip = new ToolTip(this.components);
			this.groupBox1 = new GroupBox();
			this.buttonRefresh = new Button();
			this.label5 = new Label();
			this.checkBoxRemote = new CheckBox();
			this.checkBoxLocal = new CheckBox();
			this.groupBoxExecutionClient.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBoxControlClient.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.labelServerStatus.AutoSize = true;
			this.labelServerStatus.Location = new Point(0x10, 0x250);
			this.labelServerStatus.Name = "labelServerStatus";
			this.labelServerStatus.Size = new Size(0, 13);
			this.labelServerStatus.TabIndex = 15;
			this.buttonDone.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonDone.Location = new Point(0x155, 0x1bb);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new Size(0x4b, 0x17);
			this.buttonDone.TabIndex = 4;
			this.buttonDone.Text = "Done";
			this.buttonDone.UseVisualStyleBackColor = true;
			this.groupBoxExecutionClient.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBoxExecutionClient.Controls.Add(this.buttonExecutionClientControlPanel);
			this.groupBoxExecutionClient.Controls.Add(this.label2);
			this.groupBoxExecutionClient.Enabled = false;
			this.groupBoxExecutionClient.Location = new Point(12, 0x12a);
			this.groupBoxExecutionClient.Name = "groupBoxExecutionClient";
			this.groupBoxExecutionClient.Size = new Size(0x195, 0x40);
			this.groupBoxExecutionClient.TabIndex = 2;
			this.groupBoxExecutionClient.TabStop = false;
			this.groupBoxExecutionClient.Text = "Remote Execution Client";
			this.buttonExecutionClientControlPanel.Location = new Point(0x89, 0x1a);
			this.buttonExecutionClientControlPanel.Name = "buttonExecutionClientControlPanel";
			this.buttonExecutionClientControlPanel.Size = new Size(0x6c, 0x17);
			this.buttonExecutionClientControlPanel.TabIndex = 0x17;
			this.buttonExecutionClientControlPanel.Text = "Control Panel";
			this.buttonExecutionClientControlPanel.UseVisualStyleBackColor = true;
			this.buttonExecutionClientControlPanel.Click += new EventHandler(this.buttonExecutionClientControlPanel_Click);
			this.label2.AutoSize = true;
			this.label2.ForeColor = SystemColors.ActiveCaption;
			this.label2.Location = new Point(12, 0x1f);
			this.label2.Name = "label2";
			this.label2.Size = new Size(60, 13);
			this.label2.TabIndex = 0x16;
			this.label2.Text = "Explain this";
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.buttonTest);
			this.groupBox3.Controls.Add(this.textBoxServer);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new Point(12, 160);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(0x195, 0x84);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Server Configuration";
			this.label1.Location = new Point(0x7d, 0x4b);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0x112, 0x2b);
			this.label1.TabIndex = 3;
			this.label1.Text = "Anytime you specify a new server, the server must be contacted before you can use the remote client with the new server.";
			this.buttonTest.Location = new Point(0x80, 0x2d);
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Size = new Size(0x4b, 0x17);
			this.buttonTest.TabIndex = 2;
			this.buttonTest.Text = "Contact";
			this.buttonTest.UseVisualStyleBackColor = true;
			this.buttonTest.Click += new EventHandler(this.buttonTest_Click);
			this.textBoxServer.Location = new Point(0x80, 0x13);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new Size(0xf9, 20);
			this.textBoxServer.TabIndex = 1;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(10, 0x16);
			this.label3.Name = "label3";
			this.label3.Size = new Size(0x70, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Server name/address:";
			this.groupBoxControlClient.Controls.Add(this.label4);
			this.groupBoxControlClient.Controls.Add(this.buttonControlClientControlPanel);
			this.groupBoxControlClient.Enabled = false;
			this.groupBoxControlClient.Location = new Point(13, 0x170);
			this.groupBoxControlClient.Name = "groupBoxControlClient";
			this.groupBoxControlClient.Size = new Size(0x194, 0x41);
			this.groupBoxControlClient.TabIndex = 3;
			this.groupBoxControlClient.TabStop = false;
			this.groupBoxControlClient.Text = "Control Client";
			this.label4.AutoSize = true;
			this.label4.ForeColor = SystemColors.ActiveCaption;
			this.label4.Location = new Point(11, 30);
			this.label4.Name = "label4";
			this.label4.Size = new Size(60, 13);
			this.label4.TabIndex = 0x15;
			this.label4.Text = "Explain this";
			this.toolTip.SetToolTip(this.label4, "The control client allows you limited control over registered clients.\r\nIt also allows you to upload sequences and programs to be\r\ndownloaded and executed by execution clients.");
			this.buttonControlClientControlPanel.Location = new Point(0x88, 0x19);
			this.buttonControlClientControlPanel.Name = "buttonControlClientControlPanel";
			this.buttonControlClientControlPanel.Size = new Size(0x6c, 0x17);
			this.buttonControlClientControlPanel.TabIndex = 0x13;
			this.buttonControlClientControlPanel.Text = "Control Panel";
			this.buttonControlClientControlPanel.UseVisualStyleBackColor = true;
			this.buttonControlClientControlPanel.Click += new EventHandler(this.buttonControlClientControlPanel_Click);
			this.toolTip.AutomaticDelay = 250;
			this.toolTip.AutoPopDelay = 0x3a98;
			this.toolTip.InitialDelay = 250;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 50;
			this.toolTip.ToolTipIcon = ToolTipIcon.Info;
			this.toolTip.Popup += new PopupEventHandler(this.toolTip_Popup);
			this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.buttonRefresh);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.checkBoxRemote);
			this.groupBox1.Controls.Add(this.checkBoxLocal);
			this.groupBox1.Location = new Point(13, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0x194, 0x8e);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Allowed Connections";
			this.buttonRefresh.Location = new Point(0x23, 0x61);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new Size(0x4b, 0x17);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);
			this.label5.Location = new Point(0x74, 0x59);
			this.label5.Name = "label5";
			this.label5.Size = new Size(0x11a, 0x29);
			this.label5.TabIndex = 2;
			this.label5.Text = "If you've made any changes to profiles used by the remote client (in here or the application preferences), you need to refresh it so it can reload that data.";
			this.checkBoxRemote.AutoSize = true;
			this.checkBoxRemote.Location = new Point(0x10, 0x33);
			this.checkBoxRemote.Name = "checkBoxRemote";
			this.checkBoxRemote.Size = new Size(0xe9, 0x11);
			this.checkBoxRemote.TabIndex = 1;
			this.checkBoxRemote.Text = "Allow remote network connections (Internet)";
			this.checkBoxRemote.UseVisualStyleBackColor = true;
			this.checkBoxRemote.CheckedChanged += new EventHandler(this.checkBoxRemote_CheckedChanged);
			this.checkBoxLocal.AutoSize = true;
			this.checkBoxLocal.Location = new Point(0x10, 0x1c);
			this.checkBoxLocal.Name = "checkBoxLocal";
			this.checkBoxLocal.Size = new Size(0xb2, 0x11);
			this.checkBoxLocal.TabIndex = 0;
			this.checkBoxLocal.Text = "Allow local network connections";
			this.checkBoxLocal.UseVisualStyleBackColor = true;
			this.checkBoxLocal.CheckedChanged += new EventHandler(this.checkBoxLocal_CheckedChanged);
			base.AcceptButton = this.buttonDone;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(0x1ad, 0x1dc);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBoxControlClient);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBoxExecutionClient);
			base.Controls.Add(this.buttonDone);
			base.Controls.Add(this.labelServerStatus);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "ClientUI";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Vixen Remote Client";
			base.Load += new EventHandler(this.ClientUI_Load);
			this.groupBoxExecutionClient.ResumeLayout(false);
			this.groupBoxExecutionClient.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBoxControlClient.ResumeLayout(false);
			this.groupBoxControlClient.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
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