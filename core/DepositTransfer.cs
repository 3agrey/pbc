using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class DepositTransfer : Transfer
	{
		protected DataDecimal _beginningAmount;
		protected DataSingle _percentage;
		protected DataDateTime _startDate;
		protected DataInt32 _period;
		protected DataByte _incrementPeriodType;
		protected DataByte _incrementStandardPeriod;
		protected DataInt32 _incrementCustomPeriod;
		protected DataDecimal _incrementAmount;

		public DataDecimal BeginningAmount
		{
			get { return _beginningAmount; }
			set { _beginningAmount = value; }
		}
		public DataSingle Percentage
		{
			get { return _percentage; }
			set { _percentage = value; }
		}
		public DataDateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}
		public DataInt32 Period
		{
			get { return _period; }
			set { _period = value; }
		}
		public DataByte IncrementPeriodType
		{
			get { return _incrementPeriodType; }
			set { _incrementPeriodType = value; }
		}
		public DataByte IncrementStandardPeriod
		{
			get { return _incrementStandardPeriod; }
			set { _incrementStandardPeriod = value; }
		}
		public DataInt32 IncrementCustomPeriod
		{
			get { return _incrementCustomPeriod; }
			set { _incrementCustomPeriod = value; }
		}
		public DataDecimal IncrementAmount
		{
			get { return _incrementAmount; }
			set { _incrementAmount = value; }
		}

		public DepositTransfer ()
			: base()
		{
			_beginningAmount = null;
			_percentage = null;
			_startDate = null;
			_period = null;
			_incrementPeriodType = null;
			_incrementStandardPeriod = null;
			_incrementCustomPeriod = null;
			_incrementAmount = null;
		}

		public override void LoadFromReader (SqlDataReader reader)
		{
			base.LoadFromReader(reader);
			_beginningAmount = new DataDecimal(reader["BeginningAmount"]);
			_percentage = new DataSingle(reader["Percentage"]);
			_startDate = new DataDateTime(reader["StartDate"]);
			_period = new DataInt32(reader["Period"]);
			_incrementPeriodType = new DataByte(reader["IncrementPeriodType"]);
			_incrementStandardPeriod = new DataByte(reader["IncrementStandardPeriod"]);
			_incrementCustomPeriod = new DataInt32(reader["IncrementCustomPeriod"]);
			_incrementAmount = new DataDecimal(reader["IncrementAmount"]);
		}
	}
}
