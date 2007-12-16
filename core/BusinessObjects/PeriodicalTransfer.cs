using System;

namespace AIM.PBC.Core.BusinessObjects
{
	[Serializable]
	public class PeriodicalTransfer : Transfer
	{
		private DateTime _startDate;
		private DateTime _endDate;
		private byte _periodType;
		private byte _standardPeriod;
		private int _customPeriod;

		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}

		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		public PeriodTypes PeriodType
		{
			get { return (PeriodTypes) _periodType; }
			set { _periodType = (byte) value; }
		}

		public StandardPeriods StandardPeriod
		{
			get { return (StandardPeriods) _standardPeriod; }
			set { _standardPeriod = (byte) value; }
		}

		public int CustomPeriod
		{
			get { return _customPeriod; }
			set { _customPeriod = value; }
		}

		public PeriodicalTransfer()
		{
			Type = TransferTypes.Periodical;
		}
	}
}