using Foundation;
using System;
using UIKit;

namespace Medio
{
    public partial class MedioTabBarViewController : UITabBarController
    {
        public MedioTabBarViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.ViewControllerSelected += (sender, e) => {
				if (TabBar.SelectedItem.Title == "Medications")
				{ 
					AppDelegate.IsMedication = true;
				}
				else if (TabBar.SelectedItem.Title == "Appointements")
				{
					AppDelegate.IsMedication = false;
				}
			
			};
		}



		//partial void BtnAddBill_Activated(UIBarButtonItem sender)
		//{
		//	var sb = UIStoryboard.FromName("Main", null);
		//	var billsTab = sb.InstantiateViewController("NewBillViewController");
		//	this.NavigationController.NavigationBarHidden = false;
		//	this.NavigationController.PushViewController(billsTab, true);
		//}
	}
}