using System;
using Iesi.Collections.Generic;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class Account
	{
		private int _id;
		private string _name;
		private decimal _beginningBalance;
		private DateTime _beginningBalanceDate;
		private User _user;
		private ISet<Account> _transfersFrom;
		private ISet<Account> _transfersTo;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
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

		public ISet<Account> TransfersFrom
		{
			get { return _transfersFrom; }
			set { _transfersFrom = value; }
		}

		public ISet<Account> TransfersTo
		{
			get { return _transfersTo; }
			set { _transfersTo = value; }
		}

		public override int GetHashCode()
		{
			return _id;
		}
	}
}