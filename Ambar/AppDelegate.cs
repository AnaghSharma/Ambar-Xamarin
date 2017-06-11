using AppKit;
using Foundation;

namespace Ambar
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        NSStatusBar statusBar = new NSStatusBar();
       
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
			// Insert code here to initialize your application
			NSStatusItem statusItem = statusBar.CreateStatusItem(NSStatusItemLength.Variable);

            var button = statusItem.Button;
            button.Image = new NSImage("StatusBarIcon@2x.png");

        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
