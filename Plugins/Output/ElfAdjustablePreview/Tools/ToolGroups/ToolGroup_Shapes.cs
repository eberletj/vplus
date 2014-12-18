using System.Windows.Forms;
using ElfAdjustablePreview.Core.Interfaces;
using ElfAdjustablePreview.Core.Util;

namespace ElfAdjustablePreview.Tools.ToolGroups {
    [ElfToolGroup("Shape")]
    [ElfToolCore]
    public class ToolGroup_Shape : BaseToolGroup, IToolGroup {
        public ToolGroup_Shape() {
            ID = (int) ToolID.Shape_ToolGroup;
            MultiGestureKey1 = Keys.S;
        }
    }
}