using System;
namespace Medio
{
	public class User
	{
		public string Email;
		public string Username;
		public string FullName;
		public string Password;

		public User() { }
		public User(string email, string username, string fullname, string password)
		{
			this.Email = email;
			this.Username = username;
			this.FullName = fullname;
			this.Password = password;
		}

		public bool Login(User u) 
		{
			if (u.Email == Email && u.Password == Password)
				return true;
			else
				return false;
		}

		public bool Register(string email, string username, string fullname, string password)
		{
			this.Username = username;
			this.Email = email;
			this.FullName = fullname;
			this.Password = password;
			return true;
		}
	}
}
