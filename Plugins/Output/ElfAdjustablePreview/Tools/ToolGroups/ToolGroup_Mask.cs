using System.Windows.Forms;
using ElfAdjustablePreview.Core.Interfaces;
using ElfAdjustablePreview.Core.Util;

namespace ElfAdjustablePreview.Tools.ToolGroups {
    [ElfToolGroup("Mask")]
    [ElfToolCore]
    public class ToolGroup_Mask : BaseToolGroup, IToolGroup {
        public ToolGroup_Mask() {
            ID = (int) ToolID.Mask_ToolGroup;
            MultiGestureKey1 = Keys.M;
        }
    }
}