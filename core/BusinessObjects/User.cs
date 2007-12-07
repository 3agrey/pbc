using System;
using AIM.NCore.DataTypes;
using Iesi.Collections.Generic;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class User
	{
		private int _id;
		private string _username;
		private string _password;
		private string _firstname;
		private string _lastname;
		private string _email;
		private DateTime _created;
		private DateTime? _lastLogin;
		private bool _hasTransactionCache;

		private ISet<Account> _accounts;
		private string _fullName = null;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		public string Firstname
		{
			get { return _firstname; }
			set { _firstname = value; }
		}

		public string Lastname
		{
			get { return _lastname; }
			set { _lastname = value; }
		}

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public DateTime Created
		{
			get { return _created; }
		}

		public DateTime? LastLogon
		{
			get { return _lastLogin; }
			set { _lastLogin = value; }
		}

		public DataBoolean HasTransactionCache
		{
			get { return _hasTransactionCache; }
		}

		public string Fullname
		{
			get
			{
				if (_fullName == null)
				{
					_fullName = String.Format("{0} {1}", Firstname, Lastname);
					_fullName = _fullName.Trim();
					if (String.IsNullOrEmpty(_fullName))
					{
						_fullName = Username;
					}
				}
				return _fullName;
			}
		}

		public ISet<Account> Accounts
		{
			get { return _accounts; }
			set { _accounts = value; }
		}
	}
}