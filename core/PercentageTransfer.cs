using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class PercentageTransfer : Transfer
	{
		protected DataDecimal _amount;
		protected DataSingle _percentage;
		protected DataDateTime _startDate;
		protected DataInt32 _period;

		public DataDecimal Amount
		{
			get { return _amount; }
			set { _amount = value; }
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

		public PercentageTransfer ()
			: base()
		{
			_amount = null;
			_percentage = null;
			_startDate = null;
			_period = null;
		}

		public override void LoadFromReader (SqlDataReader reader)
		{
			base.LoadFromReader(reader);
			_amount = new DataDecimal(reader["Amount"]);
			_percentage = new DataSingle(reader["Percentage"]);
			_startDate = new DataDateTime(reader["StartDate"]);
			_period = new DataInt32(reader["Period"]);
		}
	}
}
