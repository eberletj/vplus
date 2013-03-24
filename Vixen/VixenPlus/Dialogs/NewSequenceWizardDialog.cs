using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vixen.Dialogs
{
	public partial class NewSequenceWizardDialog : Form
	{
		private readonly string[,] m_explanations = new[,]
			{
				{string.Empty, string.Empty, string.Empty, string.Empty},
				{
					"The event period length is how long a single on/off event lasts.",
					"A sequence is made up of a series of events of all the same length.  At every event, the program updates the controller with new data if a change needs to be made."
					,
					"The smaller the event period, the finer the control you over the timing of the events.  Generally, you don't want to have the event period be any shorter than you need it to be in order to synchronize to your selected audio."
					, "100 milliseconds, or 10 updates/second, is adequate for synchronizing to most audio."
				},
				{
					"A profile contains information about channels and plugins.",
					"To reduce the otherwise repetitive task of setting up channels and plugins for every sequence you create.",
					"By selecting a profile, the channel count, channel names, channel colors, channel outputs, and plugin setup will all be done for you."
					,
					"Profiles are not required, but can really help you quickly create new sequences.  Profiles can be created by hand or from existing sequences."
				},
				{
					"A channel is an independently-controlled circuit of lights.",
					"For every area of your display that you want to control independently, you will want to create a channel.  Sometimes you may need multiple channels assigned to a specific area or structure to adequately meet power limitations."
					, "For every channel you define in your sequence there will be a row defined in the event grid.",
					"The channel count can be changed at any time.  If you try to reduce your channel count, you will be warned about the potential loss of data.  Channel names can be easily imported from a file by going to Sequence/Import, which also affects the channel count."
				},
				{
					"Names for the channels defined earlier.", "For easier identification of a channel's purpose and location.",
					string.Empty, string.Empty
				},
				{
					"The output plugins are what Vixen uses to communicate with the controllers.  They translate the data sent from Vixen into a format that the controllers can understand."
					, "Without specifying at least one plugin, Vixen cannot communicate with any controller.", string.Empty,
					"If you select plugins to use with this sequence, they need to be setup before they can be used.  The plugins and their respective setup can be changed at any time.  While Vixen supports using multiple plugins simultaneously, setting up one is adequate in most installations."
				},
				{
					"Here you can assign audio and create event patterns based on the music (or without music).  As the music plays, you tap a pattern on your keyboard on a channel-by-channel basis."
					,
					"The sequence can be authored to be synchronized with audio.  The music would be played by Vixen at the same time the sequence is being executed.\nEvent patterns can help set up the initial event timings which can later be cleaned up with manual editing.  It's much easier to establish the initial synchronized timings this way than by hand."
					, "The event grid will be populated with the created events.  The events are on/off values only.",
					"The audio can be added or removed at any time during editing.  The length of the sequence can be auto-sized to exactly fit the music, or it can be longer.  The sequence length cannot be shorter than any associated music.\nDefining event patterns can also be used to mark events of significance in the music.  The event patterns can be recreated at any time by going to Sequences/Music."
				},
				{
					"The length of the sequence in minutes and seconds.", string.Empty, string.Empty,
					"If there is audio assigned to a sequence, the sequence length cannot be shorter than the music length."
				}
			};

		private readonly Stack<int> m_history;
		private readonly Preference2 m_preferences;
		private readonly EventSequence m_sequence;
		private bool m_back;
		private bool m_skip;

		//ComponentResourceManager manager = new ComponentResourceManager(typeof(NewSequenceWizardDialog));
		//this.label2.Text = manager.GetString("label2.Text");
		//this.label13.Text = manager.GetString("label13.Text");

		public NewSequenceWizardDialog(Preference2 preferences)
		{
			InitializeComponent();
			openFileDialog.InitialDirectory = Paths.SequencePath;
			tabControl.SelectedIndex = 0;
			m_preferences = preferences;
			m_sequence = new EventSequence(preferences);
			PopulateProfileList();
			string str = string.Empty;
			if ((str = preferences.GetString("DefaultProfile")).Length > 0)
			{
				comboBoxProfiles.SelectedIndex = comboBoxProfiles.Items.IndexOf(str);
			}
			m_history = new Stack<int>();
			UpdateExplanations(0);
		}

		public EventSequence Sequence
		{
			get { return m_sequence; }
		}

		private void buttonAssignAudio_Click(object sender, EventArgs e)
		{
			int integer = m_preferences.GetInteger("SoundDevice");
			var dialog = new AudioDialog(m_sequence, m_preferences.GetBoolean("EventSequenceAutoSize"), integer);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				SetSequenceTime();
			}
			dialog.Dispose();
		}

		private void buttonImportChannels_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				var sequence = new EventSequence(openFileDialog.FileName);
				textBoxChannelCount.Text = sequence.ChannelCount.ToString();
				var builder = new StringBuilder();
				foreach (Channel channel in sequence.Channels)
				{
					builder.AppendLine(channel.Name);
				}
				textBoxChannelNames.Text = builder.ToString();
				m_sequence.Channels.Clear();
				m_sequence.Channels.AddRange(sequence.Channels);
			}
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			m_skip = false;
			m_back = false;
			if (tabControl.SelectedTab == tabPageProfile)
			{
				if (comboBoxProfiles.SelectedIndex == 0)
				{
					tabControl.SelectedTab = tabPageChannelCount;
				}
				else
				{
					tabControl.SelectedTab = tabPageAudio;
				}
			}
			else
			{
				tabControl.SelectedIndex++;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			tabControl_Deselecting(null,
			                       new TabControlCancelEventArgs(tabControl.SelectedTab, tabControl.SelectedIndex, false,
			                                                     TabControlAction.Deselecting));
		}

		private void buttonPrev_Click(object sender, EventArgs e)
		{
			m_back = true;
			tabControl.SelectedIndex = m_history.Pop();
			buttonPrev.Enabled = m_history.Count > 0;
		}

		private void buttonProfileManager_Click(object sender, EventArgs e)
		{
			var dialog = new ProfileManagerDialog(null);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				PopulateProfileList();
			}
			dialog.Dispose();
		}

		private void buttonSetupPlugins_Click(object sender, EventArgs e)
		{
			var dialog = new PluginListDialog(m_sequence);
			dialog.ShowDialog();
			dialog.Dispose();
		}

		private void buttonSkip_Click(object sender, EventArgs e)
		{
			m_skip = true;
			m_back = false;
			tabControl.SelectedIndex++;
		}


		private void labelEffect_Click(object sender, EventArgs e)
		{
			if (labelEffect.Enabled)
			{
				labelExplanation.Text = m_explanations[tabControl.SelectedIndex, 2];
			}
		}

		private void labelNotes_Click(object sender, EventArgs e)
		{
			if (labelNotes.Enabled)
			{
				labelExplanation.Text = m_explanations[tabControl.SelectedIndex, 3];
			}
		}

		private void labelWhat_Click(object sender, EventArgs e)
		{
			if (labelWhat.Enabled)
			{
				labelExplanation.Text = m_explanations[tabControl.SelectedIndex, 0];
			}
		}

		private void labelWhy_Click(object sender, EventArgs e)
		{
			if (labelWhy.Enabled)
			{
				labelExplanation.Text = m_explanations[tabControl.SelectedIndex, 1];
			}
		}

		private int ParseTimeString(string text)
		{
			int num2;
			int num3;
			int num4;
			string s = "0";
			string str2 = string.Empty;
			string str3 = "0";
			int index = text.IndexOf(':');
			if (index != -1)
			{
				s = text.Substring(0, index).Trim();
				text = text.Substring(index + 1);
			}
			index = text.IndexOf('.');
			if (index != -1)
			{
				str3 = text.Substring(index + 1).Trim();
				text = text.Substring(0, index);
			}
			str2 = text;
			try
			{
				num2 = int.Parse(s);
			}
			catch
			{
				num2 = 0;
			}
			try
			{
				num3 = int.Parse(str2);
			}
			catch
			{
				num3 = 0;
			}
			try
			{
				num4 = int.Parse(str3);
			}
			catch
			{
				num4 = 0;
			}
			num4 = (num4 + (num3*0x3e8)) + (num2*0xea60);
			if (num4 == 0)
			{
				MessageBox.Show(
					"Not a valid format for time.\nUse one of the following:\n\nSeconds\nMinutes:Seconds\nSeconds.Milliseconds\nMinutes:Seconds.Milliseconds",
					Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return 0;
			}
			return num4;
		}

		private void PopulateProfileList()
		{
			int selectedIndex = comboBoxProfiles.SelectedIndex;
			comboBoxProfiles.BeginUpdate();
			comboBoxProfiles.Items.Clear();
			comboBoxProfiles.Items.Add("None");
			foreach (string str in Directory.GetFiles(Paths.ProfilePath, "*.pro"))
			{
				comboBoxProfiles.Items.Add(Path.GetFileNameWithoutExtension(str));
			}
			if (selectedIndex < comboBoxProfiles.Items.Count)
			{
				comboBoxProfiles.SelectedIndex = selectedIndex;
			}
			comboBoxProfiles.EndUpdate();
		}

		private void SetSequenceTime()
		{
			textBoxTime.Text = string.Format("{0:d2}:{1:d2}.{2:d3}", m_sequence.Time/0xea60, (m_sequence.Time%0xea60)/0x3e8,
			                                 m_sequence.Time%0x3e8);
		}

		private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
		{
			if (!m_back)
			{
				m_history.Push(e.TabPageIndex);
				buttonPrev.Enabled = true;
			}
			if (m_skip)
			{
				return;
			}
			string text = string.Empty;
			switch (e.TabPageIndex)
			{
				case 1:
					{
						int num = 0;
						try
						{
							num = Convert.ToInt32(textBoxEventPeriod.Text);
							if (num < 0x19)
							{
								text = "While possible, event periods less than 25 ms aren't realistic or practical.";
								goto Label_0339;
							}
						}
						catch
						{
							text = textBoxChannelCount.Text + " is not a valid number for the event period length";
							goto Label_0339;
						}
						m_sequence.EventPeriod = num;
						goto Label_0339;
					}
				case 2:
					if (comboBoxProfiles.SelectedIndex == 0)
					{
						m_sequence.Profile = null;
					}
					else
					{
						m_sequence.Profile = new Profile(Path.Combine(Paths.ProfilePath, comboBoxProfiles.SelectedItem + ".pro"));
					}
					goto Label_0339;

				case 3:
					{
						int num2 = 0;
						try
						{
							num2 = Convert.ToInt32(textBoxChannelCount.Text);
							if (num2 < 1)
							{
								text = "The channel count must be 1 or more";
								goto Label_0339;
							}
						}
						catch
						{
							text = textBoxChannelCount.Text + " is not a valid number for the channel count";
							goto Label_0339;
						}
						if ((num2 > 0x400) &&
						    (MessageBox.Show(string.Format("Are you sure you really want {0} channels?", num2), Vendor.ProductName,
						                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes))
						{
							tabControl.TabIndex = 1;
						}
						else
						{
							Cursor = Cursors.WaitCursor;
							try
							{
								m_sequence.ChannelCount = num2;
							}
							finally
							{
								Cursor = Cursors.Default;
							}
						}
						goto Label_0339;
					}
				case 4:
					if (textBoxChannelNames.Lines.Length == Convert.ToInt32(textBoxChannelCount.Text))
					{
						foreach (string str2 in textBoxChannelNames.Lines)
						{
							if (str2.Trim() == string.Empty)
							{
								text = "Channel names cannot be blank";
								break;
							}
						}
						break;
					}
					text = "There must be an equal number of channel names as there are channels";
					goto Label_0339;

				case 7:
					{
						int num4 = ParseTimeString(textBoxTime.Text);
						if (num4 != 0)
						{
							try
							{
								m_sequence.Time = num4;
							}
							catch (Exception exception)
							{
								text = exception.Message;
							}
						}
						goto Label_0339;
					}
				default:
					goto Label_0339;
			}
			Cursor = Cursors.WaitCursor;
			try
			{
				for (int i = 0; i < m_sequence.ChannelCount; i++)
				{
					m_sequence.Channels[i].Name = textBoxChannelNames.Lines[i];
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
			Label_0339:
			if (text != string.Empty)
			{
				e.Cancel = true;
				MessageBox.Show(text, Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void tabControl_Selected(object sender, TabControlEventArgs e)
		{
			switch (e.TabPageIndex)
			{
				case 1:
					textBoxEventPeriod.Text = m_sequence.EventPeriod.ToString();
					break;

				case 2:
					if (m_sequence.Profile != null)
					{
						comboBoxProfiles.SelectedIndex = comboBoxProfiles.Items.IndexOf(m_sequence.Profile.Name);
						break;
					}
					comboBoxProfiles.SelectedIndex = 0;
					break;

				case 4:
					Cursor = Cursors.WaitCursor;
					try
					{
						string[] strArray;
						int num = Convert.ToInt32(textBoxChannelCount.Text);
						int length = textBoxChannelNames.Lines.Length;
						if (length < num)
						{
							strArray = new string[num];
							textBoxChannelNames.Lines.CopyTo(strArray, 0);
							while (length < num)
							{
								strArray[length] = string.Format("Channel {0}", length + 1);
								length++;
							}
							textBoxChannelNames.Lines = strArray;
						}
						else if (length > num)
						{
							strArray = new string[num];
							for (int i = 0; i < num; i++)
							{
								strArray[i] = textBoxChannelNames.Lines[i];
							}
							textBoxChannelNames.Lines = strArray;
						}
					}
					finally
					{
						Cursor = Cursors.Default;
					}
					break;

				case 7:
					SetSequenceTime();
					break;
			}
			UpdateExplanations(e.TabPageIndex);
			buttonSkip.Enabled = buttonNext.Enabled = e.TabPageIndex < (tabControl.TabCount - 1);
			base.AcceptButton = (e.TabPageIndex == 4) ? null : (buttonNext.Enabled ? (buttonNext) : (buttonOK));
		}

		private void textBoxChannelNames_TextChanged(object sender, EventArgs e)
		{
			labelNamesChannels.Text = string.Format("{0} names / {1} channels", textBoxChannelNames.Lines.Length,
			                                        textBoxChannelCount.Text);
		}

		private void UpdateExplanations(int pageIndex)
		{
			labelWhat.Enabled = m_explanations[pageIndex, 0] != string.Empty;
			labelWhy.Enabled = m_explanations[pageIndex, 1] != string.Empty;
			labelEffect.Enabled = m_explanations[pageIndex, 2] != string.Empty;
			labelNotes.Enabled = m_explanations[pageIndex, 3] != string.Empty;
			labelExplanation.Text = m_explanations[pageIndex, 0];
		}
	}
}