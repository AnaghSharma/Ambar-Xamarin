﻿﻿﻿using System;
using AppKit;
using Foundation;

namespace Ambar
{
    public partial class ViewController : NSViewController
    {
        public static event EventHandler QuitButtonClicked;
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

        partial void SettingsButtonClick(NSObject sender)         {             var current = NSApplication.SharedApplication.CurrentEvent;              NSMenu settingsMenu = new NSMenu();              NSMenuItem launch = new NSMenuItem("Launch at Login", new ObjCRuntime.Selector("launch:"), "");             NSMenuItem quit = new NSMenuItem("Quit", new ObjCRuntime.Selector("quit:"), "q");              settingsMenu.AddItem(launch);             settingsMenu.AddItem(quit);              NSMenu.PopUpContextMenu(settingsMenu, current, sender as NSView);         }          [Export ("launch:")]         void Launch(NSObject sender)         {             //Use NSAppleScript to add this app to Login item list of macOS         }          [Export ("quit:")]         void Quit(NSObject sender)         {             QuitButtonClicked?.Invoke(this, null);         } 
    }
}
