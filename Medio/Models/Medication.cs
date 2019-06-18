using System;
using Foundation;

namespace Medio
{
	public class Medication
	{
		public string Category;
		public string Dose;
		public string InvoiceNumber;
		public string MedicationName;
		public NSDate Deadline;
		public string Description;
		public bool isMedication;

		public Medication()
		{
		}
		public Medication(string category, string dose, string invoice, 
		            string billPeriod, NSDate deadline, string desc, bool isPaid = false)
		{
			this.Category = category;
			this.Dose = dose;
			this.InvoiceNumber = invoice;
			this.MedicationName = billPeriod;
			this.Deadline = deadline;
			this.isMedication = isPaid;
			this.Description = desc;
		}

		public void Save() 
		{ 
		
		}
	}
}
