// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Ambar
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSButton QuitButton { get; set; }

        [Outlet]
        AppKit.NSTextFieldCell titleText { get; set; }

        [Action ("QuitApplication:")]
        partial void QuitApplication (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (QuitButton != null) {
                QuitButton.Dispose ();
                QuitButton = null;
            }

            if (titleText != null) {
                titleText.Dispose ();
                titleText = null;
            }
        }
    }
}
