using System;
using System.Data.SqlClient;

using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class Account
	{
		#region Members
		private DataInt32 _id = null;
		private DataInt32 _userId = null;
		private DataString _name = null;
		private DataDecimal _beginningBalance = null;
		private DataDateTime _beginningBalanceDate = null;
		#endregion

		#region Properties
		public DataInt32 Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public DataInt32 UserId
		{
			get { return _userId; }
			set { _userId = value; }
		}
		public DataString Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public DataDecimal BeginningBalance
		{
			get { return _beginningBalance; }
			set { _beginningBalance = value; }
		}
		public DataDateTime BeginningBalanceDate
		{
			get { return _beginningBalanceDate; }
			set { _beginningBalanceDate = value; }
		}
		#endregion

		#region LoadFromReader
		public virtual void LoadFromReader (SqlDataReader reader)
		{
			_id = new DataInt32(reader["Id"]);
			_userId = new DataInt32(reader["UserId"]);
			_name = new DataString(reader["Name"]);
			_beginningBalance = new DataDecimal(reader["BeginningBalance"]);
			_beginningBalanceDate = new DataDateTime(reader["BeginningBalanceDate"]);
		}
		#endregion

		#region GetHashCode
		public override int GetHashCode ()
		{
			return _id;
		}
		#endregion
	}
}
