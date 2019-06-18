// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BillManager
{
    [Register ("InitialViewController")]
    partial class InitialViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGoToTab { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnGoToTab != null) {
                btnGoToTab.Dispose ();
                btnGoToTab = null;
            }
        }
    }
}