using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Medio
{
	public partial class CreateAppointmentViewController : UIViewController
    {
		MockTableData tableData = AppDelegate.DataStore;

	public CreateAppointmentViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			btnDone.Clicked += (sender, e) =>
			{
				Template t = new Template();
				t.Dose = txtHospital.Text;
				t.Category = txtAppointmentDetails.Text;
				t.MedicationName = txtDoctorsName.Text;
				t.Months = new List<Medication>();
				tableData.Appointments.Insert(0, t);
				var dateRemind = new NSDate();
				dateRemind = dtDeadline.Date;
				var dateNow = NSDate.Now;
				NSDateInterval sec = null;
				var dateNowSplited = dateNow.Description.Split(' ', ',');
				var dateRemindSplited = dateRemind.Description.Split(' ', ',');
				var nowHoursSplited = dateNowSplited[1].Split(' ', ':');
				var remindHoursSplited = dateRemindSplited[1].Split(' ', ':');
				if (dateNowSplited[0].Equals(dateRemindSplited[0]) && nowHoursSplited[0].Equals(remindHoursSplited[0]) && nowHoursSplited[1].Equals(remindHoursSplited[1]))
					new UIAlertView("Warning", "Please set time reminder, it must be greater than date now", null, "OK", null).Show();
				else
				{
					sec = new NSDateInterval(dateNow, dateRemind);
					//Create Notifacation - Reminderr
					var notification = new UILocalNotification();
					notification.FireDate = NSDate.FromTimeIntervalSinceNow(sec.Duration);
					notification.AlertAction = "Reminder";
					notification.AlertBody = $"You need to visit {t.MedicationName} in {t.Dose} today";
					notification.ApplicationIconBadgeNumber = 1;
					notification.SoundName = UILocalNotification.DefaultSoundName;
					UIApplication.SharedApplication.ScheduleLocalNotification(notification);
				}

				this.NavigationController.TabBarController.SelectedIndex = 0;
                this.NavigationController.PopViewController(true);
			};
			txtHospital.ShouldReturn += ShouldReturn;
			txtDoctorsName.ShouldReturn += ShouldReturn;

			txtAppointmentDetails.Layer.BorderWidth = 5.0f;
			txtAppointmentDetails.Layer.BorderColor = new CoreGraphics.CGColor(128, 128, 128);
		}

		bool ShouldReturn(UITextField textField)
		{
			textField.ResignFirstResponder();
			return true;
		}
}
}