using System;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class PercentageTransfer : Transfer
	{
		private Single _percentage;
		private DateTime _startDate;
		private int _period;

		public Single Percentage
		{
			get { return _percentage; }
			set { _percentage = value; }
		}

		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}

		public int Period
		{
			get { return _period; }
			set { _period = value; }
		}
	}
}