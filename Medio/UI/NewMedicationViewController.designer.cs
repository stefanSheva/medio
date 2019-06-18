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
    [Register ("NewMedicationViewController")]
    partial class NewMedicationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnDone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker dtDeadline { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView tvNotes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtMedicationName { get; set; }

        [Action ("BtnDone_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDone_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDone != null) {
                btnDone.Dispose ();
                btnDone = null;
            }

            if (dtDeadline != null) {
                dtDeadline.Dispose ();
                dtDeadline = null;
            }

            if (tvNotes != null) {
                tvNotes.Dispose ();
                tvNotes = null;
            }

            if (txtCategory != null) {
                txtCategory.Dispose ();
                txtCategory = null;
            }

            if (txtDose != null) {
                txtDose.Dispose ();
                txtDose = null;
            }

            if (txtMedicationName != null) {
                txtMedicationName.Dispose ();
                txtMedicationName = null;
            }
        }
    }
}