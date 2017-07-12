using System;
using System.ComponentModel;
using AppKit;
using Foundation;

namespace Ambar.CustomControls
{
	[Register("HyperlinkTextField"), DesignTimeVisible(true)]
	public class HyperlinkTextField : NSTextField
	{
        #region Private Members

        String href = "";
		NSTrackingArea hoverarea;
		NSCursor cursor;

        #endregion

		[Export("Href"), Browsable(true)]
		public String Href
		{
			get
			{
				return href;
			}

			set => href = value;
		}

        #region Constructors

        public HyperlinkTextField(IntPtr p) : base(p)
		{
			
		}

		public HyperlinkTextField()
		{
            
		}

        #endregion

        public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			AttributedStringValue = new NSAttributedString(StringValue, new NSStringAttributes()
			{
                //Uncomment follwing statement and you will be able to change the color of HyperlinkTextField
				//ForegroundColor = NSColor.Blue,
				UnderlineStyle = NSUnderlineStyle.Single.GetHashCode()
			});

			hoverarea = new NSTrackingArea(Bounds, NSTrackingAreaOptions.MouseEnteredAndExited | NSTrackingAreaOptions.ActiveAlways, this, null);
            AddTrackingArea(hoverarea);
			cursor = NSCursor.CurrentSystemCursor;
		}

        //Method override to open url on click of HyperlinkTextField
		public override void MouseDown(NSEvent theEvent)
		{
			NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl(href));
		}

        //Method override to change cursor to pointing hand on Mouse Enter (Hover)
		public override void MouseEntered(NSEvent theEvent)
		{
			base.MouseEntered(theEvent);

			cursor = NSCursor.PointingHandCursor;
			cursor.Push();
		}

        //Method override to change cursor back to pointing arrow on Mouse Exit
		public override void MouseExited(NSEvent theEvent)
		{
			base.MouseEntered(theEvent);

			cursor.Pop();
		}

	}
}
