using Foundation;
using System;
using UIKit;

namespace Medio
{
	public partial class MedicationDetailsViewController : UIViewController
    {
		MockTableData tableData = AppDelegate.DataStore;
		public Medication Item { get; set;}
		public string Payment { get; set; }
		public string Category { get; set; }
		public bool IsMedication { get; set; }
		public int SelectedIndex { get; set; }
		public int BillIndex { get; set; }
		public MedicationDetailsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			SetView();
			base.ViewDidLoad();

			tvNotes.Layer.BorderWidth = 5.0f;
			tvNotes.Layer.BorderColor = new CoreGraphics.CGColor(128, 128, 128);

			btnDone.Clicked += (sender, e) =>
			{
				UpdateViews();
				this.NavigationController.PopViewController(true);
			};
			txtDose.ShouldReturn += (textField) => 
			{
				textField.ResignFirstResponder();
				return true;
			};
		}

		void SetView()
		{
			txtMedicationName.Text = Item.MedicationName;
			txtDose.Text = Item.Dose;
			txtCategory.Text = Category;
			dtDeadline.SetDate(Item.Deadline, true);
		}

		void UpdateViews()
		{
			Medication b = new Medication();
			b.Dose = txtDose.Text;
			b.Deadline = dtDeadline.Date;
			b.MedicationName = txtMedicationName.Text;

			tableData.Medications[this.BillIndex].Months[this.SelectedIndex] = b;
		}
	}
}