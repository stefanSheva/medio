using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Medio
{
	public sealed class MockTableData
	{
		public IList<EmailItem> Email { get; set; }
		public static string UserName { get; set; }

		public IList<Template> Medications { get; set; }
		public IList<Template> Appointments { get; set; }
		public IList<Medication> Months { get; set; }
		public IList<Medication> Doctors { get; set; }
		public static string[] medications = { "Sedatives", "Pain relievers", "Minerals", "Diuretics", "Cholesterol-lowering medications", "Blood pressure medications", "Anti-inflammatories", "Antibiotics", "Antiarrhythmics" };
		public static string[] appointements = { "Audiology", "Day surgery/out-patient procedures", "Endoscopy", "Gynaecology", "Imaging/Radiology", "Maternity", "Mental health", "Paediatrics", "Physiotherapy", "Throat", "Nose and Ear Hospital" };
		public static string[] months = { "2017" };

		const string DefaultUserName = "Johnny Appleseed";

		static MockTableData()
		{
			UserName = DefaultUserName;

		}

		public MockTableData(int count = 10)
		{
			Email = new List<EmailItem>();
			Medications = new List<Template>();
			Appointments = new List<Template>();
			Months = new List<Medication>();
			Doctors = new List<Medication>();
			Generate();
		}

		void Generate(int count = 0)
		{
			for (int index = 0; index < 12; index+=3)
			{
				Medication current = new Medication();
				current.MedicationName = index + 1 + "/2017";
				current.Dose = ((index * 1000) + 480).ToString();
				current.Deadline = (Foundation.NSDate)DateTime.Today.AddDays(-365 + (index + 1) * 30);
				current.Description = "Don't forget to take your pill";
				current.InvoiceNumber = "4232312";
				current.Category = "";
				current.isMedication = true;
				Months.Insert(0, current);
			}
			for (int index = 0; index< 12; index+=3)
			{
				Medication current = new Medication();
				current.MedicationName = "Doctor-" + index + 1;
				current.Dose = ((index* 1000) + 480).ToString();
				current.Deadline = (Foundation.NSDate)DateTime.Today.AddDays(-365 + (index + 1) * 30);
				current.Description = "Don't forget to take your pill";
				current.InvoiceNumber = "4232312";
				current.Category = "";
				current.isMedication = false;
				Doctors.Insert(0, current);
			}
			for (int index = 0; index < medications.Length; index++)
			{
				Template b = new Template();
				b.Dose = medications[index];
				b.Category = "http://google.com";
				b.MedicationName = "1123456";
				b.Months = this.Months;
				Medications.Insert(0, b);
			}
			for (int index = 0; index < appointements.Length; index++)
			{
				Template b = new Template();
				b.Dose = appointements[index];
				b.Category = "http://google.com";
				b.MedicationName = "1123456";
				b.Months = this.Doctors;
				Appointments.Insert(0, b);
			}

		}

		EmailItem CreateOneEmail()
		{
			return new EmailItem
			{
				To = UserName ?? DefaultUserName,
				//From = DataGenerator.Name,
				//Subject = DataGenerator._firstName[0],
				Body = DataGenerator.GenerateParagraphs(DataGenerator.RNG.Next(3, 5),
					DataGenerator.RNG.Next(3), DataGenerator.RNG.Next(4, 8),
					DataGenerator.RNG.Next(4), DataGenerator.RNG.Next(5, 20))
			};
		}
	}

	public static class DataGenerator
	{
		static readonly StringBuilder _builder = new StringBuilder();
		static string[] _words;

		public static string[] _lastName = {
			"Ackard", "Baker", "Candy", "Duvall", "Ennis", "Finch", "Griswold", "Heck",
			"Jackson", "Kardashian", "Lewis", "Miller", "Nevell", "Octavius", "Parker",
			"Rivest", "Smith", "Taylor", "Stewart"
		};

		static public Random RNG = new Random();

		static DataGenerator()
		{
			_words = File.ReadAllLines(@"words.txt");
		}

		//public static string Name
		//{
		//	//get { return _firstName[RNG.Next(_firstName.Length - 1)] + " " + _lastName[RNG.Next(_lastName.Length - 1)]; }
		//}

		public static string GenerateParagraphs(int numberParagraphs, int minSentences,
										 int maxSentences, int minWords, int maxWords)
		{
			_builder.Clear();

			for (int i = 0; i < numberParagraphs; i++)
			{
				AddParagraph(RNG.Next(minSentences, maxSentences + 1), minWords, maxWords);
				_builder.Append("\n\n");
			}

			return _builder.ToString();
		}

		public static string GenerateSentence(int numberWords)
		{
			StringBuilder b = new StringBuilder();
			for (int i = 0; i < numberWords; i++)
			{
				b.Append(_words[RNG.Next(_words.Length)]).Append(" ");
			}

			string sentence = b.ToString().Trim() + ". ";
			sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
			return sentence;
		}

		static void AddParagraph(int numberSentences, int minWords, int maxWords)
		{
			for (int i = 0; i < numberSentences; i++)
			{
				int count = RNG.Next(minWords, maxWords + 1);
				AddSentence(count);
			}
		}

		static void AddSentence(int numberWords)
		{
			_builder.Append(GenerateSentence(numberWords));
		}
	}

	public sealed class EmailItem
	{
		public string From { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime Date { get; set; }

		public EmailItem()
		{
			Date = DateTime.Now;
		}

		private readonly CGColor[] colors = {
			UIColor.Red.CGColor,
			UIColor.Blue.CGColor,
			UIColor.Brown.CGColor,
			UIColor.DarkGray.CGColor,
			UIColor.Magenta.CGColor,
			UIColor.Orange.CGColor,
			UIColor.Purple.CGColor,
		};

		public override string ToString()
		{
			return string.Format("{2}, From={0}, To={1}, Date={3}]", From, To, Subject, Date);
		}

		public UIImage GetImage()
		{
			nfloat width = 32;
			nfloat height = 32;

			CGColor color = colors[DataGenerator.RNG.Next(colors.Length - 1)];

			UIFont font = UIFont.FromName("Helvetica Light", 14);
			UIGraphics.BeginImageContextWithOptions(new CGSize(width, height), false, 0);

			var context = UIGraphics.GetCurrentContext();
			context.SetFillColor(color);
			context.AddArc(width / 2, height / 2, width / 2, 0, (nfloat)(2 * Math.PI), true);
			context.FillPath();

			var textAttributes = new UIStringAttributes
			{
				ForegroundColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				Font = font,
				ParagraphStyle = new NSMutableParagraphStyle { Alignment = UITextAlignment.Center },
			};

			string text;
			string[] splitFrom = From.Split(' ');
			if (splitFrom.Length > 1)
			{
				text = splitFrom[0][0].ToString() + splitFrom[1][0];
			}
			else if (splitFrom.Length > 0)
			{
				text = splitFrom[0][0].ToString();
			}
			else {
				text = "?";
			}

			NSString str = new NSString(text);

			var textSize = str.GetSizeUsingAttributes(textAttributes);
			str.DrawString(new CGRect(0, height / 2 - textSize.Height / 2,
				width, height), textAttributes);

			UIImage image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			return image;
		}
	}
}

