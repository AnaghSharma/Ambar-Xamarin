using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using Ambar.CustomControls;

namespace Ambar
{
    public partial class AboutViewController : NSViewController
    {
        
        #region Constructors

        // Called when created from unmanaged code
        public AboutViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AboutViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AboutViewController() : base("AboutView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			
        }

        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			GitHubLink.Href = "https://github.com/AnaghSharma/Ambar";
            TwitterLink.Href = "https://twitter.com/AnaghSharma";
        }

    }
}
