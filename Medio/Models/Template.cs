using System;
using System.Collections.Generic;
using Foundation;

namespace Medio
{
	public class Template
	{
		public string Dose;
		public string Category;
		public string MedicationName;
		public IList<Medication> Months;
		public NSDate Deadline;

		public Template()
		{
		}

		public Template(string dose, string category, string medicationName, List<Medication> month, NSDate deadline)
		{
			this.Dose = dose;
			this.Category = category;
			this.MedicationName = medicationName;
			this.Months = month;
			this.Deadline = deadline;
		}

		public bool Save() 
		{
			return true;
		}
	}
}
