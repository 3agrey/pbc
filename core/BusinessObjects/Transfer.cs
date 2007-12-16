using System;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class Transfer
	{
		private int _id;
		private string _name;
		private decimal _amount;
		private byte _type;

		private Account _sourceAccount;
		private Account _targetAccount;

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

		public TransferTypes Type
		{
			get { return (TransferTypes) _type; }
			set { _type = (byte) value; }
		}

		public Account SourceAccount
		{
			get { return _sourceAccount; }
			set { _sourceAccount = value; }
		}

		public Account TargetAccount
		{
			get { return _targetAccount; }
			set { _targetAccount = value; }
		}

		public decimal Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		public override int GetHashCode()
		{
			return _id;
		}
	}
}