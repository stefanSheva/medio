using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Medio
{
	public class Validator
	{

		private string passwordRegex = "(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$";
		private string emailRegex = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

		public Validator()
		{
		}

		public bool IsValidMail(string v)
		{
			if (Regex.IsMatch(v, emailRegex))
				return true;
			return false;
		}

		public bool IsValidPassword(string text)
		{
			if (Regex.IsMatch(text, passwordRegex))
				return true;
			return false;
		}
	}
}
