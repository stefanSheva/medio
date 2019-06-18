using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ObjCRuntime;

namespace Medio
{
	public class Logger
	{
		public User model = new User();
		private static Logger instance;

		public static Logger GetInstance()
		{
			if (instance == null)
			{
				instance = new Logger();
			}
			return instance;
		}

		public void Log(string message)
		{
			Console.WriteLine(message);
		}

		public bool SaveUser(string email, string username, string fullname, string pass, string confirmpass) 
		{
			if (pass == confirmpass)
			{
				model.Register(email, username, fullname, pass);
				return true;
			}
			else
				return false;

		}

		public string Log(User user)
		{
			var login = model.Login(user);
			var statusCode = "";
			if (login)
			{
				var request = HttpWebRequest.Create(string.Format(@"https://rxnav.nlm.nih.gov/REST/version"));
				request.ContentType = "application/json";
				request.Method = "GET";

				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
				{
					if (response.StatusCode != HttpStatusCode.OK)
					{
						Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
						statusCode = response.StatusCode.ToString();
					}
					using (StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						var content = reader.ReadToEnd();
						if (string.IsNullOrWhiteSpace(content))
						{
							Console.Out.WriteLine("Response contained empty body...");
						}
						else {
							Console.Out.WriteLine("Response Body: \r\n {0}", content);
							Console.Out.WriteLine("StatusCode Body: \r\n {0}", response.StatusCode);
						}
						statusCode = response.StatusCode.ToString();
					}
				}
			}
			Console.WriteLine($"{user.FullName} - {user.Email}, {user.Username}");
			return statusCode;
		}
	}
}
