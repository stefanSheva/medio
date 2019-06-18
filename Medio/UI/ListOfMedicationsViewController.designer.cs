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
    [Register ("ListOfMedicationsViewController")]
    partial class ListOfMedicationsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnAddMedication { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnNewAppointment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblListOfBills { get; set; }

        [Action ("BtnAddNewBill_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAddNewBill_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAddMedication != null) {
                btnAddMedication.Dispose ();
                btnAddMedication = null;
            }

            if (btnNewAppointment != null) {
                btnNewAppointment.Dispose ();
                btnNewAppointment = null;
            }

            if (tblListOfBills != null) {
                tblListOfBills.Dispose ();
                tblListOfBills = null;
            }
        }
    }
}