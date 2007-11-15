using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class PeriodicalTransfer : Transfer
	{
		protected DataDateTime _startDate;
		protected DataDateTime _endDate;
		protected DataByte _periodType;
		protected DataByte _standardPeriod;
		protected DataInt32 _customPeriod;
		protected DataDecimal _amount;

		public DataDateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}

		public DataDateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		public DataByte PeriodType
		{
			get { return _periodType; }
			set { _periodType = value; }
		}

		public DataByte StandardPeriod
		{
			get { return _standardPeriod; }
			set { _standardPeriod = value; }
		}

		public DataInt32 CustomPeriod
		{
			get { return _customPeriod; }
			set { _customPeriod = value; }
		}

		public DataDecimal Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		public PeriodicalTransfer ()
			: base()
		{
			_startDate = null;
			_periodType = null;
			_standardPeriod = null;
			_customPeriod = null;
			_amount = null;
		}

		public override void LoadFromReader (SqlDataReader reader)
		{
			base.LoadFromReader(reader);
			_startDate = new DataDateTime(reader["StartDate"]);
			_endDate = new DataDateTime(reader["EndDate"]);
			_periodType = new DataByte(reader["PeriodType"]);
			_standardPeriod = new DataByte(reader["StandardPeriod"]);
			_customPeriod = new DataInt32(reader["CustomPeriod"]);
			_amount = new DataDecimal(reader["Amount"]);
		}
	}
}
