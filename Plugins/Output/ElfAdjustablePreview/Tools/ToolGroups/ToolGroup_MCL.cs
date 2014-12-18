using System.Windows.Forms;
using ElfAdjustablePreview.Core.Interfaces;
using ElfAdjustablePreview.Core.Util;

namespace ElfAdjustablePreview.Tools.ToolGroups {
    [ElfToolGroup("MultiChannelLine")]
    [ElfToolCore]
    public class ToolGroup_MultiChannelLine : BaseToolGroup, IToolGroup {
        public ToolGroup_MultiChannelLine() {
            base.ID = (int) ToolID.MultiChannel_ToolGroup;
            MultiGestureKey1 = Keys.H;
        }
    }
}