using Foundation;
using System;
using UIKit;

namespace Medio
{
    public partial class RegisterViewController : UIViewController
    {
		User user; 

        public RegisterViewController (IntPtr handle) : base (handle)
        {
			user = new User();
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Register";
		}

		public override void ViewWillAppear(bool animated)
		{
			//this.NavigationController.NavigationBarHidden = false;
			base.ViewWillAppear(animated);
			txtEmail.Text = "";
			txtFullName.Text = "";
			txtPassword.Text = "";
			txtUsername.Text = "";
			txtConfirmPassword.Text = "";
			txtFullName.ShouldReturn += ((UITextField textField) =>
			{
				textField.ResignFirstResponder();
				txtEmail.BecomeFirstResponder();
				return true;
			});
			txtEmail.ShouldReturn += (UITextField textField) => {
				textField.ResignFirstResponder();
				txtUsername.BecomeFirstResponder();
				return true;
			};
			txtUsername.ShouldReturn += (UITextField textField) => {
				textField.ResignFirstResponder();
				txtPassword.BecomeFirstResponder();
				return true;
			};
			txtPassword.ShouldReturn += (UITextField textField) => {
				textField.ResignFirstResponder();
				txtConfirmPassword.BecomeFirstResponder();
				return true;
			};
			txtConfirmPassword.ShouldReturn += (UITextField textField) => 
				textField.ResignFirstResponder();{
				//return true;
			};
		}

		partial void BtnRegister_TouchUpInside(UIButton sender)
		{
			if (IsValid(txtEmail.Text, txtUsername.Text, txtFullName.Text, txtPassword.Text, txtConfirmPassword.Text))
			{
				var isCorrect = Logger.GetInstance().SaveUser(txtEmail.Text, txtUsername.Text, txtFullName.Text, txtPassword.Text, txtConfirmPassword.Text);
				if (isCorrect)
				{
					var sb = UIStoryboard.FromName("Main", null);
					var billsTab = sb.InstantiateViewController("MedioTabBarViewController");
					this.NavigationController.PushViewController(billsTab, true);
				}
				else {
					lblNotValidRegistration.Text = "Password Not Match, please try again!";
				}
			}
			else
			{
				lblNotValidRegistration.Text = "Please fill every text field";
			}

		}

		bool ShouldReturn(UITextField textField)
		{
			textField.ResignFirstResponder();
			return true;
		}

		bool IsValid(string e, string u, string name, string pass, string confirmpass)
		{
			if (e == "" || u == "" || name == "" || pass == "" || confirmpass == "")
				return false;
			return true;
		}
	}
}