namespace VixenEditor {
    using System;
    using System.Windows.Forms;

    using VixenPlus;

    internal partial class ChannelCopyDialog : Form {
        private readonly AffectGridDelegate _affectGridDelegate;
        private readonly EventSequence _eventSequence;
        private readonly byte[,] _sequenceData;
        private readonly Channel[] _channels;


        public ChannelCopyDialog(AffectGridDelegate affectGridDelegate, EventSequence sequence) {
            InitializeComponent();
            _channels = new Channel[sequence.ChannelCount];
            for (var channel = 0; channel < sequence.ChannelCount; channel++) {
                _channels[channel] = sequence.Channels[channel];
            }
            // ReSharper disable CoVariantArrayConversion
            comboBoxSourceChannel.Items.AddRange(_channels);
            comboBoxDestinationChannel.Items.AddRange(_channels);
            // ReSharper restore CoVariantArrayConversion
            if (comboBoxSourceChannel.Items.Count > 0) {
                comboBoxSourceChannel.SelectedIndex = 0;
            }
            if (comboBoxDestinationChannel.Items.Count > 0) {
                comboBoxDestinationChannel.SelectedIndex = 0;
            }
            _eventSequence = sequence;
            _sequenceData = new byte[1,sequence.TotalEventPeriods];
            _affectGridDelegate = affectGridDelegate;
        }


        private void buttonCopy_Click(object sender, EventArgs e) {
            var sourceChannel = _eventSequence.Channels[comboBoxSourceChannel.SelectedIndex].OutputChannel;
            var destinationChannel = _eventSequence.Channels[comboBoxDestinationChannel.SelectedIndex].OutputChannel;
            for (var column = 0; column < _eventSequence.TotalEventPeriods; column++) {
                _sequenceData[0, column] = _eventSequence.EventValues[sourceChannel, column];
            }
            _affectGridDelegate(destinationChannel, 0, _sequenceData);
        }


        private void buttonDone_Click(object sender, EventArgs e) {
            Close();
        }


        private void comboBox_DrawItem(object sender, DrawItemEventArgs e) {
            var comboBox = sender as ComboBox;
            if (comboBox == null) {
                return;
            }

            Channel.DrawItem(e, _channels[e.Index]);
        }
    }
}
