﻿using System;

using AppKit;
using Foundation;

namespace Ambar
{
    public partial class ViewController : NSViewController
    {
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

        partial void QuitApplication(NSObject sender)
        {
            NSApplication.SharedApplication.Terminate((sender));
        }
    }
}
