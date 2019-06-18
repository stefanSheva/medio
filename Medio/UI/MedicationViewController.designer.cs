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

namespace Medio
{
    [Register ("MedicationViewController")]
    partial class MedicationViewController
    {
        [Outlet]
        UIKit.UITableView tblPaidBills { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnLogOut { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLogOut != null) {
                btnLogOut.Dispose ();
                btnLogOut = null;
            }

            if (tblPaidBills != null) {
                tblPaidBills.Dispose ();
                tblPaidBills = null;
            }
        }
    }
}