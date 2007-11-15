using System;
using System.Data.SqlClient;

using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class User
	{
		#region Members
		private DataInt32 _id;
		private DataString _username;
		private DataString _password;
		private DataString _firstname;
		private DataString _lastname;
		private DataString _email;
		private DataDateTime _created;
		private DataDateTime _lastLogin;
		private DataBoolean _hasTransactionCache;

		private AccountList _accounts = null;
		#endregion

		#region Properties
		public DataInt32 Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public DataString Username
		{
			get { return _username; }
			set { _username = value; }
		}
		public DataString Password
		{
			get { return _password; }
			set { _password = value; }
		}
		public DataString Firstname
		{
			get { return _firstname; }
			set { _firstname = value; }
		}
		public DataString Lastname
		{
			get { return _lastname; }
			set { _lastname = value; }
		}
		public DataString Email
		{
			get { return _email; }
			set { _email = value; }
		}
		public DataDateTime Created
		{
			get { return _created; }
			set { _created = value; }
		}
		public DataDateTime LastLogin
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
				string result = "";
				if (!_firstname.IsNull)
				{
					result += _firstname;
				}
				if (!_lastname.IsNull)
				{
					if (result.Length > 0) result += " ";
					result += _lastname;
				}

				if (result.Length == 0)
				{
					result = _username;
				}

				return result;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public User ()
		{
			_id = null;
			_username = null;
			_password = null;
			_firstname = null;
			_lastname = null;
			_email = null;
			_created = null;
			_lastLogin = null;
			_hasTransactionCache = null;
		}

		/// <summary>
		/// Constructor. Creates user entity and fills its properties by data from database
		/// </summary>
		public User (SqlDataReader reader)
		{
			_id = new DataInt32(reader["Id"]);
			_username = new DataString(reader["Username"]);
			_password = new DataString(reader["Password"]);
			_firstname = new DataString(reader["Firstname"]);
			_lastname = new DataString(reader["Lastname"]);
			_email = new DataString(reader["Email"]);
			_created = new DataDateTime(reader["Created"]);
			_lastLogin = new DataDateTime(reader["LastLogin"]);
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
