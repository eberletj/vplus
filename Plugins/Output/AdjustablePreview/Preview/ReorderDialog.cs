using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using AdjustablePreview.Properties;

using VixenPlus;

namespace Preview {
    internal partial class ReorderDialog : Form {

        private readonly Dictionary<int, List<uint>> _channelDictionary = new Dictionary<int, List<uint>>();


        public ReorderDialog(List<Channel> channels, Dictionary<int, List<uint>> channelDictionary) {
            InitializeComponent();
            ResetLabel();
            UpdateButtons();
            foreach (var pair in channelDictionary) {
                List<uint> list;
                _channelDictionary[pair.Key] = list = new List<uint>();
                list.AddRange(pair.Value);
            }
            var items = channels.ToArray();
            comboBoxFrom.Items.AddRange(items);
            comboBoxTo.Items.AddRange(items);
        }


        private void buttonClear_Click(object sender, EventArgs e) {
            _channelDictionary.Remove(comboBoxTo.SelectedIndex);
            SetLabel(Resources.ChannelCleared);
        }


        private void buttonCopy_Click(object sender, EventArgs e) {
            timerFade.Stop();
            ResetLabel();
            List<uint> list;
            if (!_channelDictionary.TryGetValue(comboBoxFrom.SelectedIndex, out list)) {
                SetLabel(Resources.NothingToCopy);
            }
            else {
                _channelDictionary[comboBoxTo.SelectedIndex] = list;
                SetLabel(Resources.ChannelCopied);
            }
        }


        private void SetLabel(string text) {
            timerFade.Start();
            lblChannelCopied.Text = text;
        }


        private void ResetLabel() {
            lblChannelCopied.Text = "";
            lblChannelCopied.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
        }


        public Dictionary<int, List<uint>> ChannelDictionary {
            get { return _channelDictionary; }
        }


        //todo figure out why the invoke doesn't update the forecolor. Probably Delay.Task in .Net 4.5 instead of sleep
        private void timerFade_Tick(object sender, EventArgs e) {
            timerFade.Stop();
            for (var i = 15; i > 0; i--) {
                var color = Color.FromArgb(i * 16, Color.FromKnownColor(KnownColor.ControlText));
                //Invoke((MethodInvoker) delegate {
                    lblChannelCopied.ForeColor = color;
                    Application.DoEvents(); // this is one of those times where doevents is proper and the only thing that worked.
                //});
                    Thread.Sleep(33); //todo replace with Task.Delay() when using 4.5
            }
            ResetLabel();
        }


        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateButtons();
        }


        private void UpdateButtons() {
            buttonCopy.Enabled = (comboBoxFrom.SelectedIndex != -1) && (comboBoxTo.SelectedIndex != -1);
            buttonClear.Enabled = (comboBoxTo.SelectedIndex != -1);
        }
    }
}
