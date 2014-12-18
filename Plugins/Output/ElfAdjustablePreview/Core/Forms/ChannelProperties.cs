using System.Windows.Forms;
using ElfAdjustablePreview.Core.Channels;

namespace ElfAdjustablePreview.Core.Forms
{
	public partial class ChannelProperties : Form
	{
		private ElfRawChannel _channelProperties;
		//private Channels.RasterChannel _channel;

		public ChannelProperties()
		{
			InitializeComponent();
		}

		public ElfRawChannel Properties
		{
			get { return _channelProperties; }
			set
			{
				_channelProperties = value;
				propertyGrid1.SelectedObject = _channelProperties;
			}
		}

		//public Channels.RasterChannel Channel
		//{
		//    get { return _channel; }
		//    set
		//    {
		//        _channel = value;
		//        this.propertyGrid1.SelectedObject = _channel;
		//    }
		//}
		
	}
}
