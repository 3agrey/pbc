using System;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class SingleTransfer : Transfer
	{
		private DateTime _date;

		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public SingleTransfer()
		{
			Type = TransferTypes.Single;
		}
	}
}