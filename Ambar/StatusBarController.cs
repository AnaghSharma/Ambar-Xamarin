using System;
using Foundation;
using AppKit;

namespace Ambar
{
    public class StatusBarController : NSObject
    {
        readonly NSStatusBar statusBar;
        readonly NSStatusItem statusItem;
        NSStatusBarButton button;

        public StatusBarController()
        {
            statusBar = new NSStatusBar();
            statusItem = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
		}

        public void InitStatusBar(string image)
        {
			button = statusItem.Button;
            NSImage _image = new NSImage(image)
			{
				Template = true
			};
			button.Image = _image;
			button.Action = new ObjCRuntime.Selector("toggle:");
			button.Target = this;
        }

		[Export ("toggle:")]
		void Toggle(NSObject sender)
		{
            Console.WriteLine("Be Awesome");
		}
	}
}
