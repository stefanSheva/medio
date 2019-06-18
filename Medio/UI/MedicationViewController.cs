using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace Medio
{
	public partial class MedicationViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {
		MockTableData tableData = AppDelegate.DataStore;
		int selectedIndex = -1;
		public bool IsPaid = false;
	public MedicationViewController (IntPtr handle) : base (handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//this.NavigationController.NavigationBar.TintColor = new UIColor(256, 0, 0, 0);
			tblPaidBills.WeakDataSource = this;
			tblPaidBills.WeakDelegate = this;
			tblPaidBills.TableHeaderView = null;

			btnLogOut.Clicked += LogOut;
		}

		public override void ViewDidAppear(bool animated)
		{
			this.NavigationController.TabBarController.TabBar.Hidden = false;
			tblPaidBills.ReloadData();
			base.ViewWillAppear(animated);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			Console.WriteLine($"Just executing segue {segue.Identifier}");
			if (segue.Identifier == "BillDetailsSegue")
			{
				var ctrl = segue.DestinationViewController as ListOfMedicationsViewController;
				ctrl.Items = tableData.Medications[selectedIndex].Months;
				ctrl.MedicationIndex = this.selectedIndex;
				ctrl.ViewTitle = tableData.Medications[selectedIndex].Dose;
				ctrl.PaymentUrl = tableData.Medications[selectedIndex].Category;
				ctrl.IsMedication = true;
			}
			else if (segue.Identifier == "UnpaidBillDetailsSegue") { 
				var ctrl = segue.DestinationViewController as ListOfMedicationsViewController;
				ctrl.Items = tableData.Appointments[selectedIndex].Months;
				ctrl.MedicationIndex = this.selectedIndex;
				ctrl.ViewTitle = tableData.Appointments[selectedIndex].Dose;
				ctrl.PaymentUrl = tableData.Appointments[selectedIndex].Category;
				ctrl.IsMedication = false;
			}
			NavigationController.TabBarController.TabBar.Hidden = true;
			base.PrepareForSegue(segue, sender);
		}

		void LogOut(object sender, EventArgs e)
		{
			var alert = UIAlertController.Create("Warning", "Are you sure you want to log out?", UIAlertControllerStyle.Alert);

			alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
			alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, action => { 
				var sb = UIStoryboard.FromName("Main", null);
				var login = sb.InstantiateViewController("LoginViewController");
				this.NavigationController.NavigationBarHidden = false;
				NavigationController.TabBarController.TabBar.Hidden = true;
				this.NavigationController.PushViewController(login, true); 
			}));
			PresentViewController(alert, animated: true, completionHandler: null);
		}

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return tableData.Medications.Count;
		}

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var i = NavigationController.TabBarController.TabBar.SelectedItem;
			if (i.Title == "Medications")
			{
				UITableViewCell cell = new UITableViewCell(CGRect.Empty);
				var item = tableData.Medications[indexPath.Row];

				cell.TextLabel.Text = item.Dose;
				return cell;
			}
			else { 
				UITableViewCell cell = new UITableViewCell(CGRect.Empty);
				var item = tableData.Appointments[indexPath.Row];

				cell.TextLabel.Text = item.Dose;
				return cell;
			}
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			selectedIndex = indexPath.Row;
			if (this.RestorationIdentifier == "UnpaidBillViewController")
				PerformSegue("UnpaidBillDetailsSegue", this);
			else
				PerformSegue("BillDetailsSegue", this);
		}

	}
}