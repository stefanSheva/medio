using Foundation;
using System;
using UIKit;

namespace Medio
{
    public partial class NewMedicationViewController : UIViewController
    {
		MockTableData tableData = AppDelegate.DataStore;
		public string Category { get; set; }
		public string PaymentUrl { get; set; }
		public int MedicationIndex { get; set; }

		public NewMedicationViewController (IntPtr handle) : base (handle)
        {
        }

		partial void BtnDone_Activated(UIBarButtonItem sender)
		{
			Template t = new Template();
			t.Dose = txtDose.Text;
			t.Category = txtCategory.Text;
			t.MedicationName = txtMedicationName.Text;
			t.Deadline = dtDeadline.Date;
			
			tableData.Medications.Insert(0, t);
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

				//Create Notifacation - Reminder
				var notification = new UILocalNotification();
				notification.FireDate = NSDate.FromTimeIntervalSinceNow(sec.Duration);
				notification.AlertAction = "Reminder";
				notification.AlertBody = $"You need to take medicine now - {t.MedicationName} - {t.Category} - {t.Dose}";
				notification.ApplicationIconBadgeNumber = 1;
				notification.SoundName = UILocalNotification.DefaultSoundName;
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			}

			this.NavigationController.PopViewController(true);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			txtCategory.Text = this.Category;

			txtDose.ShouldReturn += ShouldReturn;
			txtCategory.ShouldReturn += ShouldReturn;
			txtMedicationName.ShouldReturn += ShouldReturn;

			tvNotes.Layer.BorderWidth = 5.0f;
			tvNotes.Layer.BorderColor = new CoreGraphics.CGColor(128, 128, 128);
		}

		bool ShouldReturn(UITextField textField)
		{
			textField.ResignFirstResponder();
			return true;
		}
	}
}