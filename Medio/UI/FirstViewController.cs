using Foundation;
using System;
using UIKit;

namespace BillManager
{
    public partial class FirstViewController : UIViewController
    {
        public FirstViewController (IntPtr handle) : base (handle)
        {
        }

		partial void BtnClickMe_TouchUpInside(UIButton sender)
		{
			lblName.Text = "button was clicked";
		}
	}
}