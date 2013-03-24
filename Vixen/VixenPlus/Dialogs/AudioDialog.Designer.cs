namespace VixenPlus.Dialogs{
	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.ComponentModel;
	using System.Collections;

	public partial class AudioDialog{
		private IContainer components;

		#region Windows Form Designer generated code
		private Button buttonCancel;
private Button buttonClear;
private Button buttonLoad;
private Button buttonOK;
private Button buttonPlayPause;
private Button buttonRemoveAudio;
private Button buttonStop;
private ToolStripComboBox channel0ToolStripMenuItem;
private ToolStripComboBox channel1ToolStripMenuItem;
private ToolStripComboBox channel2ToolStripMenuItem;
private ToolStripComboBox channel3ToolStripMenuItem;
private ToolStripComboBox channel4ToolStripMenuItem;
private ToolStripComboBox channel5ToolStripMenuItem;
private ToolStripComboBox channel6ToolStripMenuItem;
private ToolStripComboBox channel7ToolStripMenuItem;
private ToolStripComboBox channel8ToolStripMenuItem;
private ToolStripComboBox channel9ToolStripMenuItem;
private CheckBox checkBoxAutoSize;
private ComboBox comboBoxAudioDevice;
private ContextMenuStrip contextMenuStrip;
private GroupBox groupBox1;
private GroupBox groupBox2;
private GroupBox groupBox3;
private Label label1;
private Label label2;
private Label labelAudioFileName;
private Label labelAudioLength;
private Label labelAudioName;
private Label labelTime;
private Label labelTotalTime;
private LinkLabel linkLabelAssignedKeys;
private ListBox listBoxChannels;
private OpenFileDialog openFileDialog1;
private PictureBox pictureBoxPause;
private PictureBox pictureBoxPlay;
private PictureBox pictureBoxPlayBlue;
private ProgressBar progressBarCountdown;
private RadioButton radioButtonMultipleEvents;
private RadioButton radioButtonSingleEvent;
private ToolStripMenuItem toolStripMenuItem10;
private ToolStripMenuItem toolStripMenuItem11;
private ToolStripMenuItem toolStripMenuItem2;
private ToolStripMenuItem toolStripMenuItem3;
private ToolStripMenuItem toolStripMenuItem4;
private ToolStripMenuItem toolStripMenuItem5;
private ToolStripMenuItem toolStripMenuItem6;
private ToolStripMenuItem toolStripMenuItem7;
private ToolStripMenuItem toolStripMenuItem8;
private ToolStripMenuItem toolStripMenuItem9;
private TrackBar trackBarPosition;

		private void InitializeComponent()
		{
			this.components = new Container();
			this.openFileDialog1 = new OpenFileDialog();
			this.groupBox1 = new GroupBox();
			this.comboBoxAudioDevice = new ComboBox();
			this.label2 = new Label();
			this.checkBoxAutoSize = new CheckBox();
			this.buttonRemoveAudio = new Button();
			this.labelAudioLength = new Label();
			this.labelAudioFileName = new Label();
			this.labelAudioName = new Label();
			this.buttonLoad = new Button();
			this.groupBox2 = new GroupBox();
			this.trackBarPosition = new TrackBar();
			this.progressBarCountdown = new ProgressBar();
			this.linkLabelAssignedKeys = new LinkLabel();
			this.pictureBoxPlay = new PictureBox();
			this.pictureBoxPlayBlue = new PictureBox();
			this.pictureBoxPause = new PictureBox();
			this.labelTotalTime = new Label();
			this.labelTime = new Label();
			this.buttonClear = new Button();
			this.buttonStop = new Button();
			this.buttonPlayPause = new Button();
			this.label1 = new Label();
			this.listBoxChannels = new ListBox();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.toolStripMenuItem2 = new ToolStripMenuItem();
			this.channel1ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem3 = new ToolStripMenuItem();
			this.channel2ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem4 = new ToolStripMenuItem();
			this.channel3ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem5 = new ToolStripMenuItem();
			this.channel4ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem6 = new ToolStripMenuItem();
			this.channel5ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem7 = new ToolStripMenuItem();
			this.channel6ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem8 = new ToolStripMenuItem();
			this.channel7ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem9 = new ToolStripMenuItem();
			this.channel8ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem10 = new ToolStripMenuItem();
			this.channel9ToolStripMenuItem = new ToolStripComboBox();
			this.toolStripMenuItem11 = new ToolStripMenuItem();
			this.channel0ToolStripMenuItem = new ToolStripComboBox();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.groupBox3 = new GroupBox();
			this.radioButtonMultipleEvents = new RadioButton();
			this.radioButtonSingleEvent = new RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.trackBarPosition.BeginInit();
			((ISupportInitialize) this.pictureBoxPlay).BeginInit();
			((ISupportInitialize) this.pictureBoxPlayBlue).BeginInit();
			((ISupportInitialize) this.pictureBoxPause).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.openFileDialog1.DefaultExt = "wma";
			this.openFileDialog1.Filter = "Windows Media Audio | *.wma";
			this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.comboBoxAudioDevice);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.checkBoxAutoSize);
			this.groupBox1.Controls.Add(this.buttonRemoveAudio);
			this.groupBox1.Controls.Add(this.labelAudioLength);
			this.groupBox1.Controls.Add(this.labelAudioFileName);
			this.groupBox1.Controls.Add(this.labelAudioName);
			this.groupBox1.Controls.Add(this.buttonLoad);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(420, 0xab);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select audio";
			this.comboBoxAudioDevice.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxAudioDevice.FormattingEnabled = true;
			this.comboBoxAudioDevice.Location = new Point(0x84, 0x87);
			this.comboBoxAudioDevice.Name = "comboBoxAudioDevice";
			this.comboBoxAudioDevice.Size = new Size(0xce, 0x15);
			this.comboBoxAudioDevice.TabIndex = 7;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(0x39, 0x8a);
			this.label2.Name = "label2";
			this.label2.Size = new Size(0x45, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Audio device";
			this.checkBoxAutoSize.AutoSize = true;
			this.checkBoxAutoSize.CheckAlign = ContentAlignment.TopLeft;
			this.checkBoxAutoSize.Location = new Point(30, 0x1c);
			this.checkBoxAutoSize.Name = "checkBoxAutoSize";
			this.checkBoxAutoSize.Size = new Size(0xd9, 0x11);
			this.checkBoxAutoSize.TabIndex = 0;
			this.checkBoxAutoSize.Text = "Resize the sequence to the audio length";
			this.checkBoxAutoSize.UseVisualStyleBackColor = true;
			this.checkBoxAutoSize.CheckedChanged += new EventHandler(this.checkBoxAutoSize_CheckedChanged);
			this.buttonRemoveAudio.Enabled = false;
			this.buttonRemoveAudio.Location = new Point(30, 0x5f);
			this.buttonRemoveAudio.Name = "buttonRemoveAudio";
			this.buttonRemoveAudio.Size = new Size(0x60, 0x17);
			this.buttonRemoveAudio.TabIndex = 2;
			this.buttonRemoveAudio.Text = "Remove audio";
			this.buttonRemoveAudio.UseVisualStyleBackColor = true;
			this.buttonRemoveAudio.Click += new EventHandler(this.buttonRemoveAudio_Click);
			this.labelAudioLength.AutoSize = true;
			this.labelAudioLength.Location = new Point(0x84, 0x69);
			this.labelAudioLength.Name = "labelAudioLength";
			this.labelAudioLength.Size = new Size(0x24, 13);
			this.labelAudioLength.TabIndex = 5;
			this.labelAudioLength.Text = "length";
			this.labelAudioFileName.AutoSize = true;
			this.labelAudioFileName.Location = new Point(0x84, 0x42);
			this.labelAudioFileName.Name = "labelAudioFileName";
			this.labelAudioFileName.Size = new Size(0x2e, 13);
			this.labelAudioFileName.TabIndex = 3;
			this.labelAudioFileName.Text = "filename";
			this.labelAudioName.AutoSize = true;
			this.labelAudioName.Location = new Point(0x84, 0x55);
			this.labelAudioName.Name = "labelAudioName";
			this.labelAudioName.Size = new Size(0x21, 13);
			this.labelAudioName.TabIndex = 4;
			this.labelAudioName.Text = "name";
			this.buttonLoad.Location = new Point(30, 0x42);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new Size(0x60, 0x17);
			this.buttonLoad.TabIndex = 1;
			this.buttonLoad.Text = "Assign audio";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new EventHandler(this.buttonLoad_Click);
			this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
			this.groupBox2.Controls.Add(this.trackBarPosition);
			this.groupBox2.Controls.Add(this.progressBarCountdown);
			this.groupBox2.Controls.Add(this.linkLabelAssignedKeys);
			this.groupBox2.Controls.Add(this.pictureBoxPlay);
			this.groupBox2.Controls.Add(this.pictureBoxPlayBlue);
			this.groupBox2.Controls.Add(this.pictureBoxPause);
			this.groupBox2.Controls.Add(this.labelTotalTime);
			this.groupBox2.Controls.Add(this.labelTime);
			this.groupBox2.Controls.Add(this.buttonClear);
			this.groupBox2.Controls.Add(this.buttonStop);
			this.groupBox2.Controls.Add(this.buttonPlayPause);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.listBoxChannels);
			this.groupBox2.Location = new Point(12, 0x138);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(420, 0xe1);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Channel events";
			this.trackBarPosition.LargeChange = 30;
			this.trackBarPosition.Location = new Point(0x83, 0xb1);
			this.trackBarPosition.Name = "trackBarPosition";
			this.trackBarPosition.Size = new Size(0x113, 0x2d);
			this.trackBarPosition.TabIndex = 0x13;
			this.trackBarPosition.TickStyle = TickStyle.TopLeft;
			this.trackBarPosition.Scroll += new EventHandler(this.trackBarPosition_Scroll);
			this.progressBarCountdown.Location = new Point(0x8d, 0xa4);
			this.progressBarCountdown.Name = "progressBarCountdown";
			this.progressBarCountdown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.progressBarCountdown.RightToLeftLayout = true;
			this.progressBarCountdown.Size = new Size(0x109, 13);
			this.progressBarCountdown.TabIndex = 0x12;
			this.progressBarCountdown.Visible = false;
			this.linkLabelAssignedKeys.LinkArea = new LinkArea(11, 11);
			this.linkLabelAssignedKeys.Location = new Point(0x8d, 0x4b);
			this.linkLabelAssignedKeys.Name = "linkLabelAssignedKeys";
			this.linkLabelAssignedKeys.Size = new Size(0xf2, 0x1d);
			this.linkLabelAssignedKeys.TabIndex = 0x10;
			this.linkLabelAssignedKeys.TabStop = true;
			this.linkLabelAssignedKeys.Text = "Or use the number keys to create the pattern for specific channels simultaneously.";
			this.linkLabelAssignedKeys.UseCompatibleTextRendering = true;
			this.linkLabelAssignedKeys.VisitedLinkColor = Color.Blue;
			this.linkLabelAssignedKeys.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelAssignedKeys_LinkClicked);
			this.pictureBoxPlay.Location = new Point(0x162, 0x8e);
			this.pictureBoxPlay.Name = "pictureBoxPlay";
			this.pictureBoxPlay.Size = new Size(0x10, 0x10);
			this.pictureBoxPlay.TabIndex = 15;
			this.pictureBoxPlay.TabStop = false;
			this.pictureBoxPlay.Visible = false;
			this.pictureBoxPlayBlue.Location = new Point(0x14c, 0x8e);
			this.pictureBoxPlayBlue.Name = "pictureBoxPlayBlue";
			this.pictureBoxPlayBlue.Size = new Size(0x10, 0x10);
			this.pictureBoxPlayBlue.TabIndex = 14;
			this.pictureBoxPlayBlue.TabStop = false;
			this.pictureBoxPlayBlue.Visible = false;
			this.pictureBoxPause.Location = new Point(310, 0x8e);
			this.pictureBoxPause.Name = "pictureBoxPause";
			this.pictureBoxPause.Size = new Size(0x10, 0x10);
			this.pictureBoxPause.TabIndex = 13;
			this.pictureBoxPause.TabStop = false;
			this.pictureBoxPause.Visible = false;
			this.labelTotalTime.AutoSize = true;
			this.labelTotalTime.Location = new Point(0xbf, 0x93);
			this.labelTotalTime.Name = "labelTotalTime";
			this.labelTotalTime.Size = new Size(0x3f, 13);
			this.labelTotalTime.TabIndex = 7;
			this.labelTotalTime.Text = "/ 00:00.000";
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new Point(0x8a, 0x93);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new Size(0x37, 13);
			this.labelTime.TabIndex = 6;
			this.labelTime.Text = "00:00.000";
			this.buttonClear.Enabled = false;
			this.buttonClear.Location = new Point(0xc1, 0x73);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new Size(0x57, 0x17);
			this.buttonClear.TabIndex = 4;
			this.buttonClear.Text = "Reset channel";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
			this.buttonStop.Location = new Point(0xa7, 0x74);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new Size(20, 20);
			this.buttonStop.TabIndex = 3;
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new EventHandler(this.buttonStop_Click);
			this.buttonPlayPause.Location = new Point(0x8d, 0x74);
			this.buttonPlayPause.Name = "buttonPlayPause";
			this.buttonPlayPause.Size = new Size(20, 20);
			this.buttonPlayPause.TabIndex = 2;
			this.buttonPlayPause.UseVisualStyleBackColor = true;
			this.buttonPlayPause.Click += new EventHandler(this.buttonPlayPause_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(0x8a, 0x1a);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0xe1, 0x27);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select a channel and use the left and/or right\r\nControl keys (CTRL) to create the pattern after\r\nclicking the play button.";
			this.listBoxChannels.FormattingEnabled = true;
			this.listBoxChannels.Location = new Point(11, 0x1a);
			this.listBoxChannels.Name = "listBoxChannels";
			this.listBoxChannels.Size = new Size(0x73, 0xba);
			this.listBoxChannels.TabIndex = 0;
			this.listBoxChannels.SelectedIndexChanged += new EventHandler(this.listBoxChannels_SelectedIndexChanged);
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[] { this.toolStripMenuItem2, this.toolStripMenuItem3, this.toolStripMenuItem4, this.toolStripMenuItem5, this.toolStripMenuItem6, this.toolStripMenuItem7, this.toolStripMenuItem8, this.toolStripMenuItem9, this.toolStripMenuItem10, this.toolStripMenuItem11 });
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(0x57, 0xe0);
			this.toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { this.channel1ToolStripMenuItem });
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem2.Text = "'1'";
			this.channel1ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel1ToolStripMenuItem.Name = "channel1ToolStripMenuItem";
			this.channel1ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel1ToolStripMenuItem.Tag = "1";
			this.channel1ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { this.channel2ToolStripMenuItem });
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem3.Text = "'2'";
			this.channel2ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel2ToolStripMenuItem.Name = "channel2ToolStripMenuItem";
			this.channel2ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel2ToolStripMenuItem.Tag = "2";
			this.channel2ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { this.channel3ToolStripMenuItem });
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem4.Text = "'3'";
			this.channel3ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel3ToolStripMenuItem.Name = "channel3ToolStripMenuItem";
			this.channel3ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel3ToolStripMenuItem.Tag = "3";
			this.channel3ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { this.channel4ToolStripMenuItem });
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem5.Text = "'4'";
			this.channel4ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel4ToolStripMenuItem.Name = "channel4ToolStripMenuItem";
			this.channel4ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel4ToolStripMenuItem.Tag = "4";
			this.channel4ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem6.DropDownItems.AddRange(new ToolStripItem[] { this.channel5ToolStripMenuItem });
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem6.Text = "'5'";
			this.channel5ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel5ToolStripMenuItem.Name = "channel5ToolStripMenuItem";
			this.channel5ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel5ToolStripMenuItem.Tag = "5";
			this.channel5ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem7.DropDownItems.AddRange(new ToolStripItem[] { this.channel6ToolStripMenuItem });
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem7.Text = "'6'";
			this.channel6ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel6ToolStripMenuItem.Name = "channel6ToolStripMenuItem";
			this.channel6ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel6ToolStripMenuItem.Tag = "6";
			this.channel6ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem8.DropDownItems.AddRange(new ToolStripItem[] { this.channel7ToolStripMenuItem });
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem8.Text = "'7'";
			this.channel7ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel7ToolStripMenuItem.Name = "channel7ToolStripMenuItem";
			this.channel7ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel7ToolStripMenuItem.Tag = "7";
			this.channel7ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem9.DropDownItems.AddRange(new ToolStripItem[] { this.channel8ToolStripMenuItem });
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem9.Text = "'8'";
			this.channel8ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel8ToolStripMenuItem.Name = "channel8ToolStripMenuItem";
			this.channel8ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel8ToolStripMenuItem.Tag = "8";
			this.channel8ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem10.DropDownItems.AddRange(new ToolStripItem[] { this.channel9ToolStripMenuItem });
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem10.Text = "'9'";
			this.channel9ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel9ToolStripMenuItem.Name = "channel9ToolStripMenuItem";
			this.channel9ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel9ToolStripMenuItem.Tag = "9";
			this.channel9ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.toolStripMenuItem11.DropDownItems.AddRange(new ToolStripItem[] { this.channel0ToolStripMenuItem });
			this.toolStripMenuItem11.Name = "toolStripMenuItem11";
			this.toolStripMenuItem11.Size = new Size(0x56, 0x16);
			this.toolStripMenuItem11.Text = "'0'";
			this.channel0ToolStripMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.channel0ToolStripMenuItem.Name = "channel0ToolStripMenuItem";
			this.channel0ToolStripMenuItem.Size = new Size(0x98, 0x17);
			this.channel0ToolStripMenuItem.Tag = "10";
			this.channel0ToolStripMenuItem.SelectedIndexChanged += new EventHandler(this.channelMapItem_SelectedIndexChanged);
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0x114, 0x21f);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 0x17);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0x165, 0x21f);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 0x17);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
			this.groupBox3.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.groupBox3.Controls.Add(this.radioButtonMultipleEvents);
			this.groupBox3.Controls.Add(this.radioButtonSingleEvent);
			this.groupBox3.Location = new Point(12, 0xc6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(420, 0x63);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Key behavior";
			this.radioButtonMultipleEvents.AutoSize = true;
			this.radioButtonMultipleEvents.Location = new Point(0x17, 0x3a);
			this.radioButtonMultipleEvents.Name = "radioButtonMultipleEvents";
			this.radioButtonMultipleEvents.Size = new Size(0x11b, 0x11);
			this.radioButtonMultipleEvents.TabIndex = 1;
			this.radioButtonMultipleEvents.Text = "Create events while a key is pressed, until it is released";
			this.radioButtonMultipleEvents.UseVisualStyleBackColor = true;
			this.radioButtonSingleEvent.AutoSize = true;
			this.radioButtonSingleEvent.Checked = true;
			this.radioButtonSingleEvent.Location = new Point(0x17, 0x1d);
			this.radioButtonSingleEvent.Name = "radioButtonSingleEvent";
			this.radioButtonSingleEvent.Size = new Size(0xe9, 0x11);
			this.radioButtonSingleEvent.TabIndex = 0;
			this.radioButtonSingleEvent.TabStop = true;
			this.radioButtonSingleEvent.Text = "Create a single event when a key is pressed";
			this.radioButtonSingleEvent.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x1bc, 0x23e);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AudioDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Event Sequence Audio";
			base.KeyUp += new KeyEventHandler(this.AudioDialog_KeyUp);
			base.FormClosing += new FormClosingEventHandler(this.AudioDialog_FormClosing);
			base.KeyDown += new KeyEventHandler(this.AudioDialog_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.trackBarPosition.EndInit();
			((ISupportInitialize) this.pictureBoxPlay).EndInit();
			((ISupportInitialize) this.pictureBoxPlayBlue).EndInit();
			((ISupportInitialize) this.pictureBoxPause).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			base.ResumeLayout(false);
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
