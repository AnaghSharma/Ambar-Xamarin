using AppKit;
using Foundation;

namespace Ambar
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
            
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application

            StatusBarController statusBar = new StatusBarController();
            statusBar.InitStatusBar("StatusBarIcon.png");

            //var storyboard = NSStoryboard.FromName("Main", null);
            //var controller = storyboard.InstantiateControllerWithIdentifier("PopupController") as ViewController;

            //popOver.ContentViewController = controller;

            //eventMonitor = new EventMonitor((NSEventMask.LeftMouseDown|NSEventMask.RightMouseDown), MouseEventHandler);
            //eventMonitor.Start();
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        //public void Show(NSObject sender)
        //{
        //    var button = statusItem.Button;
        //    popOver.Show(button.Bounds, button, NSRectEdge.MaxYEdge);
        //    eventMonitor.Start();
        //}

        //public void Close(NSObject sender)
        //{
        //    popOver.PerformClose(sender);
        //    eventMonitor.Stop();
        //}

        //void MouseEventHandler(NSEvent _event)
        //{
        //    if (popOver.Shown)
        //        Close(_event);
        //}
    }
}
