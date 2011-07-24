using System;

namespace AIM.PBC.Core
{
	public struct TransactionsReportItem
	{
		private string _transferName;
		private string _sourceAccountName;
		private string _targetAccountName;
		private DateTime _transactionDate;
		private decimal _transactionAmount;

		public string TransferName
		{
			get { return _transferName; }
			set { _transferName = value; }
		}
		public string SourceAccountName
		{
			get { return _sourceAccountName; }
			set { _sourceAccountName = value; }
		}
		public string TargetAccountName
		{
			get { return _targetAccountName; }
			set { _targetAccountName = value; }
		}
		public DateTime TransactionDate
		{
			get { return _transactionDate; }
			set { _transactionDate = value; }
		}
		public decimal TransactionAmount
		{
			get { return _transactionAmount; }
			set { _transactionAmount = value; }
		}
	}
}
