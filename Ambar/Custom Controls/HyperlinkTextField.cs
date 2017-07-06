using System;
using System.ComponentModel;
using AppKit;
using Foundation;

namespace Ambar.CustomControls
{
	[Register("HyperlinkTextField"), DesignTimeVisible(true)]
	public class HyperlinkTextField : NSTextField
	{
        String href = "";

		[Export("Href"), Browsable(true)]
		public String Href
		{
			get
			{
				return href;
			}

			set => href = value;
		}

		public HyperlinkTextField(IntPtr p) : base(p)
		{
			
		}

		public HyperlinkTextField()
		{
            
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			AttributedStringValue = new NSAttributedString(StringValue, new NSStringAttributes()
			{
				//ForegroundColor = NSColor.Blue,
				UnderlineStyle = NSUnderlineStyle.Single.GetHashCode()
			});
		}

		public override void MouseDown(NSEvent theEvent)
		{
			NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl(href));
		}

	}
}
