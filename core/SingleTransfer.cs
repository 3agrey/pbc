using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class SingleTransfer : Transfer
	{
		protected DataDateTime _date;
		protected DataDecimal _amount;

		public DataDateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public DataDecimal Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		public SingleTransfer ()
			: base()
		{
			_date = null;
			_amount = null;
		}

		public override void LoadFromReader (SqlDataReader reader)
		{
			base.LoadFromReader(reader);
			_date = new DataDateTime(reader["Date"]);
			_amount = new DataDecimal(reader["Amount"]);
		}
	}
}
