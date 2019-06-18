using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace Medio
{
	public partial class ListOfMedicationsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {
		MockTableData tableData = AppDelegate.DataStore;
		int selectedIndex = -1;
		public IList<Medication> Items { get; set; }
		public string ViewTitle { get; set; }
		public string PaymentUrl { get; set; }
		public bool IsMedication { get; set; }
		public int MedicationIndex { get; set; }
		public ListOfMedicationsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = ViewTitle;
			tblListOfBills.WeakDataSource = this;
			tblListOfBills.WeakDelegate = this;
			tblListOfBills.TableHeaderView = null;
		}

		public override void ViewWillAppear(bool animated)
		{
			this.NavigationController.TabBarController.TabBar.Hidden = true;
			if (NavigationController.TabBarController.TabBar.SelectedItem.Title == "Medications")
			{
				btnNewAppointment.Title = "";
				btnNewAppointment.Enabled = false;
			}
			else if (NavigationController.TabBarController.TabBar.SelectedItem.Title == "Appointements") {
				btnAddMedication.Title = "";
				btnAddMedication.Enabled = false;
			}
			tblListOfBills.TableHeaderView = null;
			tblListOfBills.ReloadData();
			base.ViewWillAppear(animated);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			var i = NavigationController.TabBarController.TabBar.SelectedItem;
			if (segue.Identifier == "BillDetailsSegue") {
				var ctrl = segue.DestinationViewController as MedicationDetailsViewController;
				ctrl.Item = Items[selectedIndex];
				ctrl.BillIndex = this.MedicationIndex;
				ctrl.Payment = this.PaymentUrl;
				ctrl.Category = this.ViewTitle;
				ctrl.IsMedication = this.IsMedication;
				ctrl.SelectedIndex = this.selectedIndex;
			}
			if (segue.Identifier == "NewMedicationSegue" && i.Title == "Medications")
			{
				var ctrl = segue.DestinationViewController as NewMedicationViewController;
				ctrl.MedicationIndex = this.MedicationIndex;
				ctrl.Category = this.ViewTitle;
				ctrl.PaymentUrl = this.PaymentUrl;
			}
			if (segue.Identifier == "NewAppointment" && i.Title == "Appointements") { 
				var ctrl = segue.DestinationViewController as CreateAppointmentViewController;

			}
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			var count = 0;
			foreach (var b in Items)
			{
				if (b.isMedication && this.IsMedication)
					count++;
				else
					count++;
			}
			return count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = new UITableViewCell(CGRect.Empty);
			var item = new Medication();
			var i = NavigationController.TabBarController.TabBar.SelectedItem;
			if (i.Title == "Medications")
			{
				if (Items[indexPath.Row].isMedication)
					item = Items[indexPath.Row];
			}
			else {
				if (!Items[indexPath.Row].isMedication)
					item = Items[indexPath.Row];
			}
			cell.TextLabel.Text = item.MedicationName;
			return cell;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			selectedIndex = indexPath.Row;
			PerformSegue("BillDetailsSegue", this);
		}
	}
}