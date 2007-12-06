using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;

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

		private AccountList _accounts = null;
		private string _fullName = null;

		#region Properties

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

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public User()
		{
			_id = default(int);
			_username = null;
			_password = null;
			_firstname = null;
			_lastname = null;
			_email = null;
			_created = default(DateTime);
			_lastLogin = null;
			_hasTransactionCache = default(bool);
		}

		/// <summary>
		/// Constructor. Creates user entity and fills its properties by data from database
		/// </summary>
		public User(SqlDataReader reader)
		{
			_id = new DataInt32(reader["Id"]);
			_username = new DataString(reader["Username"]);
			_password = new DataString(reader["Password"]);
			_firstname = new DataString(reader["Firstname"]);
			_lastname = new DataString(reader["Lastname"]);
			_email = new DataString(reader["Email"]);
			_created = new DataDateTime(reader["Created"]);
			_lastLogin = new DataDateTime(reader["LastLogon"]);
			_hasTransactionCache = new DataBoolean(reader["HasTransactionCache"]);
		}

		#endregion

		#region Methods

		public AccountList Accounts
		{
			get { return _accounts; }
			set { _accounts = value; }
		}

		#endregion
	}
}