﻿﻿﻿﻿using System;
using AppKit;
using Foundation;

namespace Ambar
{
    public partial class ViewController : NSViewController
    {
        #region Data Members

        public static event EventHandler QuitButtonClicked;
        public static event EventHandler AboutMenuItemClicked;
		NSTrackingArea hoverarea;
		NSCursor cursor;
        NSMenu settingsMenu;
        NSMenuItem launch;
        bool isLoginItem;

        //This is just to adjust the character spacing of Title Text and is not necessary at all
        NSAttributedString titleString = new NSAttributedString("Make\nEpic\nThings",
															   new NSStringAttributes()
															   {
																   ParagraphStyle = new NSMutableParagraphStyle()
																   {
																	   LineHeightMultiple = 0.75f
																   }
															   });

        #endregion


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

            //Contextual Menu for settings
			settingsMenu = new NSMenu();

			launch = new NSMenuItem("Launch at Login", new ObjCRuntime.Selector("launch:"), "");
			NSMenuItem about = new NSMenuItem("About", new ObjCRuntime.Selector("about:"), "");
			NSMenuItem quit = new NSMenuItem("Quit", new ObjCRuntime.Selector("quit:"), "q");


			settingsMenu.AddItem(launch);
			settingsMenu.AddItem(about);
			settingsMenu.AddItem(NSMenuItem.SeparatorItem);
			settingsMenu.AddItem(quit);

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

        partial void SettingsButtonClick(NSObject sender)         {             var current = NSApplication.SharedApplication.CurrentEvent; 
            //Checking if the app is in the login items or not
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
                //AppleScript to add app to login items
                script = "tell application \"System Events\"\n make new login item at end of login items with properties {name: \"Ambar\", path:\"/Applications/Ambar.app\", hidden:false}\n end tell";
                login = new NSAppleScript(script);
                login.ExecuteAndReturnError(out errors);
            }
            else
            {
                //AppleScript to delete app from login items
				script = "tell application \"System Events\"\n delete login item \"Ambar\"\n end tell";
				login = new NSAppleScript(script);
				login.ExecuteAndReturnError(out errors);
            }         } 
        //Delegating the About Menu Item click event to StatusBarController.cs
        [Export ("about:")]
        void About(NSObject sender)
        {
            AboutMenuItemClicked?.Invoke(this, null);
        }

        //Delegating the Quit Menu Item click event to StatusBarController.cs         [Export ("quit:")]         void Quit(NSObject sender)         {             QuitButtonClicked?.Invoke(this, null);         }

		//Method override to change cursor to pointing hand on Mouse Enter (Hover)
		public override void MouseEntered(NSEvent theEvent)
		{
			base.MouseEntered(theEvent);

			cursor = NSCursor.PointingHandCursor;
			cursor.Push();
		}
		//Method override to change cursor to pointing hand on Mouse Exit
		public override void MouseExited(NSEvent theEvent)
		{
			base.MouseEntered(theEvent);

			cursor.Pop();
		}
    }
}
