﻿﻿﻿﻿using System;
using AppKit;
using Foundation;

namespace Ambar
{
    public partial class ViewController : NSViewController
    {
        public static event EventHandler QuitButtonClicked;
        public static event EventHandler AboutMenuItemClicked;
		NSTrackingArea hoverarea;
		NSCursor cursor;
        NSMenuItem launch;
        bool isLoginItem;

        NSAttributedString titleString = new NSAttributedString("Make\nEpic\nThings",
															   new NSStringAttributes()
															   {
																   ParagraphStyle = new NSMutableParagraphStyle()
																   {
																	   LineHeightMultiple = 0.75f
																   }
															   });

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Do any additional setup after loading the view

            titleText.AttributedStringValue = titleString;
			hoverarea = new NSTrackingArea(SettingsButton.Bounds, NSTrackingAreaOptions.MouseEnteredAndExited | NSTrackingAreaOptions.ActiveAlways, this, null);
			SettingsButton.AddTrackingArea(hoverarea);
			cursor = NSCursor.CurrentSystemCursor;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void SettingsButtonClick(NSObject sender)         {             var current = NSApplication.SharedApplication.CurrentEvent;              NSMenu settingsMenu = new NSMenu();              launch = new NSMenuItem("Launch at Login", new ObjCRuntime.Selector("launch:"), "");             NSMenuItem about = new NSMenuItem("About", new ObjCRuntime.Selector("about:"), "");
            NSMenuItem quit = new NSMenuItem("Quit", new ObjCRuntime.Selector("quit:"), "q");
              settingsMenu.AddItem(launch);
            settingsMenu.AddItem(about);
            settingsMenu.AddItem(NSMenuItem.SeparatorItem);             settingsMenu.AddItem(quit);

			var script = "tell application \"System Events\"\n get the name of every login item\n if login item \"Ambar\" exists then\n return true\n else\n return false\n end if\n end tell";
			NSAppleScript appleScript = new NSAppleScript(script);
			var errors = new NSDictionary();
			NSAppleEventDescriptor result = appleScript.ExecuteAndReturnError(out errors);
            isLoginItem = result.BooleanValue;

            if (!isLoginItem)
			{
				launch.State = NSCellStateValue.Off;
			}
            else if (isLoginItem)
				launch.State = NSCellStateValue.On;
                         NSMenu.PopUpContextMenu(settingsMenu, current, sender as NSView);         }          [Export ("launch:")]         void Launch(NSObject sender)         {             //Use NSAppleScript to add this app to Login item list of macOS.
            //The app must be in the Applications Folder

            String script;
            NSAppleScript login;
            NSDictionary errors = new NSDictionary();
            if (!isLoginItem)
            {
                script = "tell application \"System Events\"\n make new login item at end of login items with properties {name: \"Ambar\", path:\"/Applications/Ambar.app\", hidden:false}\n end tell";
                login = new NSAppleScript(script);
                login.ExecuteAndReturnError(out errors);
            }
            else
            {
				script = "tell application \"System Events\"\n delete login item \"Ambar\"\n end tell";
				login = new NSAppleScript(script);
				login.ExecuteAndReturnError(out errors);
            }         }            
        [Export ("about:")]
        void About(NSObject sender)
        {
            AboutMenuItemClicked?.Invoke(this, null);
        }
         [Export ("quit:")]         void Quit(NSObject sender)         {             QuitButtonClicked?.Invoke(this, null);         }

		public override void MouseEntered(NSEvent theEvent)
		{
			base.MouseEntered(theEvent);

			cursor = NSCursor.PointingHandCursor;
			cursor.Push();
		}

		public override void MouseExited(NSEvent theEvent)
		{
			base.MouseEntered(theEvent);

			cursor.Pop();
		}
    }
}
