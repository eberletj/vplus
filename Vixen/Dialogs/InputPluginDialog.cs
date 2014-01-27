using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using VixenPlus.Properties;

namespace Dialogs
{
    internal partial class InputPluginDialog : Form
    {
        private readonly MappingSets _editingMappingSets;
        private readonly Dictionary<string, Channel> _idChannel;
        private readonly InputPlugin _inputPlugin;
        private readonly bool _isInit;
        private bool _isInternal;

        public InputPluginDialog(InputPlugin plugin, EventSequence sequence)
        {
            InitializeComponent();
            Icon = Resources.VixenPlus;
            _idChannel = new Dictionary<string, Channel>();
            _inputPlugin = plugin;
            var eventSequence = sequence;
            plugin.SetupDataToPlugin();
            _isInit = true;
            listBoxInputs.DisplayMember = "Name";
            listBoxInputs.ValueMember = "OutputChannelId";
            listBoxInputs.DataSource = _inputPlugin.Inputs;
            foreach (var channel in eventSequence.Channels)
            {
                _idChannel[channel.Id.ToString(CultureInfo.InvariantCulture)] = channel;
            }
            listBoxChannels.Items.AddRange(eventSequence.Channels.ToArray());
            _editingMappingSets = (MappingSets) _inputPlugin.MappingSets.Clone();
            _isInit = false;
            if (listBoxInputs.SelectedItem != null)
            {
                ReflectInput((Input) listBoxInputs.SelectedItem);
            }
            checkBoxLiveUpdate.Checked = _inputPlugin.LiveUpdate;
            checkBoxRecord.Checked = _inputPlugin.Record;
            foreach (var set in _editingMappingSets)
            {
                AddMappingSetListViewItem(set);
            }
            var iterators = _inputPlugin.GetIterators();
            comboBoxSingleIteratorInput.Items.AddRange(iterators);
            listBoxIteratorInputs.Items.AddRange(iterators);
            switch (_inputPlugin.MappingIteratorType) {
                case InputPlugin.MappingIterator.SingleInput:
                    radioButtonSingleIterator.Checked = true;
                    comboBoxSingleIteratorInput.SelectedItem = _inputPlugin.SingleIterator;
                    break;
                case InputPlugin.MappingIterator.MultiInput:
                    radioButtonMultipleIterators.Checked = true;
                    tabControlIterators.SelectedTab = tabPageMultipleIterators;
                    break;
                default:
                    radioButtonNoIterator.Checked = true;
                    break;
            }
        }

        private void AddMappingSetListViewItem(MappingSet mappingSet)
        {
            listViewMappingSets.Items.Add(mappingSet.Name);
        }

        private static void AssignMappingSetToInput(MappingSet mappingSet, Input input)
        {
            if (input != null)
            {
                input.AssignedMappingSet = mappingSet;
            }
        }

        private void buttonAddMappingSet_Click(object sender, EventArgs e)
        {
            AddMappingSetListViewItem(_editingMappingSets.AddMapping());
        }

        private void buttonClearInputChannels_Click(object sender, EventArgs e)
        {
            if (listBoxInputs.SelectedItem == null) {
                return;
            }
            var selectedItem = (Input) listBoxInputs.SelectedItem;
            _editingMappingSets.GetOutputChannelIdList(selectedItem).Clear();
            ReflectInput(selectedItem);
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            var oldIndex = listViewMappingSets.SelectedIndices[0];
            _editingMappingSets.MoveMappingTo(oldIndex, oldIndex + 1);
            var item = listViewMappingSets.Items[oldIndex];
            listViewMappingSets.Items.RemoveAt(oldIndex);
            listViewMappingSets.Items.Insert(oldIndex + 1, item);
            listViewMappingSets.Items[oldIndex].Selected = false;
            listViewMappingSets.Items[oldIndex + 1].Selected = true;
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            var oldIndex = listViewMappingSets.SelectedIndices[0];
            _editingMappingSets.MoveMappingTo(oldIndex, oldIndex - 1);
            var item = listViewMappingSets.Items[oldIndex];
            listViewMappingSets.Items.RemoveAt(oldIndex);
            listViewMappingSets.Items.Insert(oldIndex - 1, item);
            listViewMappingSets.Items[oldIndex].Selected = false;
            listViewMappingSets.Items[oldIndex - 1].Selected = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (radioButtonSingleIterator.Checked && (comboBoxSingleIteratorInput.SelectedItem == null))
            {
                if (_inputPlugin.GetIterators().Length > 0)
                {
                    MessageBox.Show(
                        Resources.NoInputChosen,
                        Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabControlPlugin.SelectedTab = tabPageMappingIteration;
                }
                else
                {
                    MessageBox.Show(
                        Resources.NoInputSet,
                        Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                DialogResult = DialogResult.None;
            }
            else
            {
                _inputPlugin.MappingSets = _editingMappingSets;
                _inputPlugin.LiveUpdate = checkBoxLiveUpdate.Checked;
                _inputPlugin.Record = checkBoxRecord.Checked;
                if (radioButtonSingleIterator.Checked)
                {
                    _inputPlugin.MappingIteratorType = InputPlugin.MappingIterator.SingleInput;
                }
                else if (radioButtonMultipleIterators.Checked)
                {
                    _inputPlugin.MappingIteratorType = InputPlugin.MappingIterator.MultiInput;
                }
                else
                {
                    _inputPlugin.MappingIteratorType = InputPlugin.MappingIterator.None;
                }
                if (_inputPlugin.MappingIteratorType == InputPlugin.MappingIterator.SingleInput)
                {
                    _inputPlugin.SingleIterator = (Input) comboBoxSingleIteratorInput.SelectedItem;
                }
                else
                {
                    _inputPlugin.SingleIterator = null;
                }
                _inputPlugin.PluginToSetupData();
            }
        }

        private void buttonRemoveMappingSet_Click(object sender, EventArgs e)
        {
            _editingMappingSets.RemoveMappingAt(listViewMappingSets.SelectedIndices[0]);
            listViewMappingSets.Items.RemoveAt(listViewMappingSets.SelectedIndices[0]);
            buttonRemoveMappingSet.Enabled = buttonMoveUp.Enabled = buttonMoveDown.Enabled = false;
            UpdateIteratorType();
        }

        private void buttonRenameMappingSet_Click(object sender, EventArgs e)
        {
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxEnabled.Text = checkBoxEnabled.Checked ? Resources.InputEnabled : Resources.InputDisabled;
            listBoxChannels.Enabled = checkBoxEnabled.Checked;
        }

        private void checkBoxEnabled_Click(object sender, EventArgs e)
        {
            if (listBoxInputs.SelectedItem != null)
            {
                ((Input) listBoxInputs.SelectedItem).Enabled = checkBoxEnabled.Checked;
            }
        }

        private void comboBoxMappingSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            _editingMappingSets.CurrentMappingSet = (MappingSet) comboBoxMappingSet.SelectedItem;
            listBoxInputs.SelectedIndex = -1;
            listBoxMappedChannels.Items.Clear();
            listBoxChannels.ClearSelected();
            groupBoxIOMapping.Enabled = comboBoxMappingSet.SelectedIndex != -1;
        }


        private void listBoxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInternal) {
                return;
            }
            var list = listBoxMappedChannels.Items.Cast<Channel>().ToList();
            foreach (var channel in listBoxMappedChannels.Items.Cast<Channel>().Where(channel => !listBoxChannels.SelectedItems.Contains(channel))) {
                list.Remove(channel);
            }
            foreach (Channel channel in listBoxChannels.SelectedItems)
            {
                if (!list.Contains(channel))
                {
                    list.Add(channel);
                }
            }
            if (listBoxInputs.SelectedItem != null)
            {
                var outputChannelIdList = _editingMappingSets.GetOutputChannelIdList((Input) listBoxInputs.SelectedItem);
                outputChannelIdList.Clear();
                outputChannelIdList.AddRange(list.Select(channel => channel.Id.ToString(CultureInfo.InvariantCulture)));
            }
            listBoxMappedChannels.BeginUpdate();
            listBoxMappedChannels.Items.Clear();
            listBoxMappedChannels.Items.AddRange(list.ToArray());
            listBoxMappedChannels.EndUpdate();
        }

        private void listBoxInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isInit && (listBoxInputs.SelectedItem != null))
            {
                ReflectInput((Input) listBoxInputs.SelectedItem);
            }
        }

        private void listBoxIteratorInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (Input) listBoxIteratorInputs.SelectedItem;
            if (selectedItem.AssignedMappingSet == null)
            {
                listBoxMappingSets.SelectedIndex = 0;
            }
            else
            {
                listBoxMappingSets.SelectedItem = selectedItem.AssignedMappingSet;
            }
        }

        private void listBoxMappingSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBoxMappingSets.SelectedItem is MappingSet))
            {
                AssignMappingSetToInput(null, (Input) listBoxIteratorInputs.SelectedItem);
            }
            else
            {
                AssignMappingSetToInput((MappingSet) listBoxMappingSets.SelectedItem, (Input) listBoxIteratorInputs.SelectedItem);
            }
        }

        private void listViewMappingSets_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if ((e.Label != null) && (e.Label.Trim().Length > 0))
            {
                _editingMappingSets[listViewMappingSets.SelectedIndices[0]].Name = e.Label;
            }
        }

        private void listViewMappingSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveMappingSet.Enabled = listViewMappingSets.SelectedItems.Count > 0;
            buttonMoveUp.Enabled = (listViewMappingSets.SelectedItems.Count > 0) && (listViewMappingSets.SelectedIndices[0] != 0);
            buttonMoveDown.Enabled = (listViewMappingSets.SelectedItems.Count > 0) &&
                                     (listViewMappingSets.SelectedIndices[0] < (listViewMappingSets.Items.Count - 1));
        }

        private void radioButtonMultipleIterators_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMultipleIterators.Checked)
            {
                tabControlIterators.SelectedTab = tabPageMultipleIterators;
            }
        }

        private void radioButtonSingleIterator_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSingleIterator.Checked)
            {
                tabControlIterators.SelectedTab = tabPageSingleIterator;
            }
        }

        private void ReflectInput(Input input)
        {
            if (!groupBoxIOMapping.Enabled) {
                return;
            }
            _isInternal = true;
            listBoxChannels.ClearSelected();
            _isInternal = false;
            listBoxMappedChannels.Items.Clear();
            if (listBoxInputs.SelectedValue == null) {
                return;
            }
            listBoxChannels.BeginUpdate();
            listBoxMappedChannels.BeginUpdate();
            _isInternal = true;
            foreach (var str in _editingMappingSets.GetOutputChannelIdList(input))
            {
                Channel channel;
                if (!_idChannel.TryGetValue(str, out channel)) {
                    continue;
                }
                listBoxMappedChannels.Items.Add(channel);
                listBoxChannels.SetSelected(listBoxChannels.Items.IndexOf(channel), true);
            }
            _isInternal = false;
            listBoxMappedChannels.EndUpdate();
            listBoxChannels.EndUpdate();
            checkBoxEnabled.Checked = input.Enabled;
        }

        private void tabControlMappingSets_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != tabPageInputOutputMapping) {
                return;
            }
            MappingSet selectedItem = null;
            if (comboBoxMappingSet.SelectedItem != null)
            {
                selectedItem = (MappingSet) comboBoxMappingSet.SelectedItem;
            }
            comboBoxMappingSet.BeginUpdate();
            comboBoxMappingSet.Items.Clear();
            comboBoxMappingSet.Items.AddRange(_editingMappingSets.AllSets);
            comboBoxMappingSet.EndUpdate();
            if ((selectedItem != null) && comboBoxMappingSet.Items.Contains(selectedItem))
            {
                comboBoxMappingSet.SelectedItem = selectedItem;
            }
            else if (comboBoxMappingSet.Items.Count > 0)
            {
                comboBoxMappingSet.SelectedIndex = 0;
            }
            else
            {
                groupBoxIOMapping.Enabled = false;
            }
        }

        private void tabControlPlugin_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != tabPageMappingIteration) {
                return;
            }
            var selectedIndex = comboBoxSingleIteratorInput.SelectedIndex;
            comboBoxSingleIteratorInput.Items.Clear();
            comboBoxSingleIteratorInput.Items.AddRange(_inputPlugin.GetIterators());
            listBoxIteratorInputs.Items.Clear();
            listBoxIteratorInputs.Items.AddRange(_inputPlugin.GetIterators());
            comboBoxSingleIteratorInput.SelectedIndex = selectedIndex;
            listBoxMappingSets.Items.Clear();
            listBoxMappingSets.Items.Add("(none)");
            listBoxMappingSets.Items.AddRange(_editingMappingSets.AllSets);
        }

        private void UpdateIteratorType()
        {
            if (listViewMappingSets.Items.Count <= 1)
            {
                radioButtonNoIterator.Checked = true;
            }
            else if (radioButtonNoIterator.Checked)
            {
                radioButtonSingleIterator.Checked = true;
            }
        }
    }
}