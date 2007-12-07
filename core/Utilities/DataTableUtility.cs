using System;
using System.Data;

namespace AIM.PBC.Core.Utilities
{
	public static class DataTableUtility
	{
		private static bool ColumnEqual (object a, object b)
		{
			if (a == DBNull.Value && b == DBNull.Value) //  both are DBNull.Value
			{
				return true;
			}
			if (a == DBNull.Value || b == DBNull.Value) //  only one is DBNull.Value
			{
				return false;
			}
			return a.Equals(b);  // value type standard comparison
		}

		public static DataTable SelectDistinct (DataTable table, string column)
		{
			DataTable result = new DataTable();
			result.Columns.Add(column, table.Columns[column].DataType);

			object lastValue = null;
			foreach (DataRow row in table.Select("", column))
			{
				if (lastValue == null || !(ColumnEqual(lastValue, row[column])))
				{
					lastValue = row[column];
					DataRow newRow = result.NewRow();
					newRow[column] = lastValue;
					result.Rows.Add(newRow);
				}
			}

			return result;
		}
	}
}