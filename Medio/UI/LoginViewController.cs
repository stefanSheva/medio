using Foundation;
using System;
using UIKit;
using System.Net.Mail;

namespace Medio
{
    public partial class LoginViewController : UIViewController
    {
		User user;
		Validator v; 

        public LoginViewController (IntPtr handle) : base (handle)
        {
			this.user = new User();
			this.v = new Validator(); 
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			txtUsername.ShouldReturn += (textField) =>
			{
				textField.ResignFirstResponder();
				this.user.Email = textField.Text;
				txtPassword.BecomeFirstResponder();
				return true;
			};
			txtPassword.ShouldReturn += (textField) =>
			{
				this.user.Password = textField.Text;
				textField.ResignFirstResponder();
				return true;
			};

			txtPassword.EditingDidBegin += (s, e) =>
				SetAsCurrentKeyboardHolder(s);

			btnLogin.TouchUpInside += (s, e) => {
				if (v.IsValidMail(txtUsername.Text) && v.IsValidPassword(txtPassword.Text))
				{
					lblResponse.Text = "";
					var content = Logger.GetInstance().Log(this.user);
					if (content == "OK")
						PerformSegue("LoginToMainSegue", this);
					else
						lblResponse.Text = "This user doesn't exist, please try again!";
				}
				else
					lblResponse.Text = "Invalid Username or Password, please try again!";
			};
		}
		UITextField currentKeyboardHolder;
		protected void
		SetAsCurrentKeyboardHolder(object sender, EventArgs args = null) => currentKeyboardHolder = sender as UITextField;

		public override void ViewDidAppear(bool animated)
		{
			this.NavigationController.NavigationBarHidden = true;
			base.ViewDidAppear(animated);
			txtUsername.Text = "";
			txtPassword.Text = "";
		}

		partial void BtnSignUp_TouchUpInside(UIButton sender)
		{
			Logger.GetInstance().Log("Sign Up Touched");
			PerformSegue("LoginToRegisterSegue", this);
		}
	}
}