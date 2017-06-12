using AppKit;
using Foundation;
using System;

namespace Ambar
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        NSStatusBar statusBar = new NSStatusBar();
        NSPopover popOver = new NSPopover();

        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
			// Insert code here to initialize your application
			NSStatusItem statusItem = statusBar.CreateStatusItem(NSStatusItemLength.Variable);

            var button = statusItem.Button;
            button.Image = new NSImage("StatusBarIcon.png");
            button.Action = new ObjCRuntime.Selector("toggle:");
            button.Target = this;
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        [Export ("toggle:")]
        public void Toggle(NSObject sender)
        {
            Console.WriteLine("Be Awesome");
        }
    }
}
