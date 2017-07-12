using Foundation;
using AppKit;

namespace Ambar
{
    public class StatusBarController : NSObject
    {
        readonly NSStatusBar statusBar;
        readonly NSStatusItem statusItem;
        NSStatusBarButton button;
        NSPopover popOver;
        EventMonitor eventMonitor;
        NSWindow aboutWindow;
        NSStoryboard storyboard;
        NSWindowController windowController;

        public StatusBarController()
        {
            statusBar = new NSStatusBar();
            statusItem = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
            popOver = new NSPopover();
            ViewController.QuitButtonClicked += HandleQuitButtonClicked;
            ViewController.AboutMenuItemClicked += HandleAboutMenuItemClicked;
			storyboard = NSStoryboard.FromName("Main", null);
			windowController = storyboard.InstantiateControllerWithIdentifier("AboutWindow") as NSWindowController;
		}

        ~StatusBarController()
        {
            ViewController.QuitButtonClicked -= HandleQuitButtonClicked;
            ViewController.AboutMenuItemClicked -= HandleAboutMenuItemClicked;
        }

        /// <summary>
        /// Initialise a NSStatusItem instance with an image, popover and event handling.
        /// </summary>
        /// <param name="image">Image.</param>
        /// <param name="popOver">Pop over.</param>
        public void InitStatusBarItem(string image, NSPopover popOver)
        {
			button = statusItem.Button;
            NSImage _image = new NSImage(image)
			{
				Template = true
			};
			button.Image = _image;
			button.Action = new ObjCRuntime.Selector("toggle:");
			button.Target = this;

            this.popOver = popOver;

			eventMonitor = new EventMonitor((NSEventMask.LeftMouseDown | NSEventMask.RightMouseDown), MouseEventHandler);
			eventMonitor.Start();
		}

		[Export ("toggle:")]
		void Toggle(NSObject sender)
		{
            if (popOver.Shown)
                Close(sender);
            else Show(sender);
		}

        /// <summary>
        /// Shows the popover
        /// </summary>
        /// <param name="sender">Sender.</param>
		public void Show(NSObject sender)
		{
		    button = statusItem.Button;
		    popOver.Show(button.Bounds, button, NSRectEdge.MaxYEdge);
		    eventMonitor.Start();
		}

        /// <summary>
        /// Hides the popover
        /// </summary>
        /// <param name="sender">Sender.</param>
		public void Close(NSObject sender)
		{
		    popOver.PerformClose(sender);
		    eventMonitor.Stop();
		}

		void MouseEventHandler(NSEvent _event)
		{
		    if (popOver.Shown)
		        Close(_event);
		}

        void HandleQuitButtonClicked(object sender, System.EventArgs e)
        {
            Close(sender as NSObject);
            var alert = new NSAlert()
            {
                MessageText = "Are you sure you want to Quit Ambar?"
            };
            alert.AddButton("Quit");
			alert.AddButton("Cancel");
			var retValue = alert.RunModal();
			if(retValue == 1000)
                NSApplication.SharedApplication.Terminate((sender as NSObject));
		}

        void HandleAboutMenuItemClicked(object sender, System.EventArgs e)
        {
            Close(sender as NSObject);
			
            aboutWindow = windowController.Window;
            aboutWindow.Title = "";
            aboutWindow.TitlebarAppearsTransparent = true;
			aboutWindow.MovableByWindowBackground = true;

            windowController.ShowWindow(sender as NSObject);
        }
    }
}
