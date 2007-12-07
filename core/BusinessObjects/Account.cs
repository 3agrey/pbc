using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class Account
	{
		private int _id;
		private int _userId;
		private string _name;
		private decimal _beginningBalance;
		private DateTime _beginningBalanceDate;
		private User _user;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public int UserId
		{
			get { return _userId; }
			set { _userId = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public decimal BeginningBalance
		{
			get { return _beginningBalance; }
			set { _beginningBalance = value; }
		}

		public DateTime BeginningBalanceDate
		{
			get { return _beginningBalanceDate; }
			set { _beginningBalanceDate = value; }
		}

		public User User
		{
			get { return _user; }
			set { _user = value; }
		}

		public virtual void LoadFromReader(SqlDataReader reader)
		{
			_id = new DataInt32(reader["Id"]);
			_userId = new DataInt32(reader["UserId"]);
			_name = new DataString(reader["Name"]);
			_beginningBalance = new DataDecimal(reader["BeginningBalance"]);
			_beginningBalanceDate = new DataDateTime(reader["BeginningBalanceDate"]);
		}

		public override int GetHashCode()
		{
			return _id;
		}
	}
}