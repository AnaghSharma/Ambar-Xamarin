using AppKit;
using Foundation;

namespace Ambar
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
		NSStatusBar statusBar = new NSStatusBar();
        NSStatusItem statusItem;
        readonly NSPopover popOver = new NSPopover();

        public AppDelegate()
        {
            statusItem = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
			// Insert code here to initialize your application

            var button = statusItem.Button;

            NSImage image = new NSImage("StatusBarIcon.png")
            {
                Template = true
            };

            button.Image = image;
            button.Action = new ObjCRuntime.Selector("toggle:");
            button.Target = this;


            var storyboard = NSStoryboard.FromName("Main", null);
            var controller = storyboard.InstantiateControllerWithIdentifier("PopupController") as ViewController;

            popOver.ContentViewController = controller;
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        [Export ("toggle:")]
        public void Toggle(NSObject sender)
        {
            if (popOver.Shown)
                Close(sender);
            else Show(sender);
        }

        public void Show(NSObject sender)
        {
            var button = statusItem.Button;
            popOver.Show(button.Bounds, button, NSRectEdge.MaxYEdge);

        }

        public void Close(NSObject sender)
        {
            popOver.PerformClose(sender);
        }
    }
}
