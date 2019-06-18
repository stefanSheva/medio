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
	[Register("CreateAppointmentViewController")]
	partial class CreateAppointmentViewController
    {
        [Outlet]
        UIKit.UIBarButtonItem btnDone { get; set; }


        [Outlet]
        UIKit.UINavigationItem NewTemplateNavigationItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker dtDeadline { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView txtAppointmentDetails { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDoctorsName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtHospital { get; set; }

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

            if (NewTemplateNavigationItem != null) {
                NewTemplateNavigationItem.Dispose ();
                NewTemplateNavigationItem = null;
            }

            if (txtAppointmentDetails != null) {
                txtAppointmentDetails.Dispose ();
                txtAppointmentDetails = null;
            }

            if (txtDoctorsName != null) {
                txtDoctorsName.Dispose ();
                txtDoctorsName = null;
            }

            if (txtHospital != null) {
                txtHospital.Dispose ();
                txtHospital = null;
            }
        }
    }
}