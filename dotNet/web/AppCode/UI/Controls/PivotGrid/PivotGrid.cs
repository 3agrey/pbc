using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace AIM.PBC.Web.UI.Controls
{
	public abstract class PivotGrid : Control
	{
		#region Members
		private DataTable _dataSource = null;

		private string _yAxisValueField = null;
		private string _yAxisTextFormat = "";
		private PivotGridFieldInfoCollection _yAxisTextFields = new PivotGridFieldInfoCollection();
		private List<string> _yAxisIdentityValue = new List<string>();

		private string _xAxisValueField = null;
		private string _xAxisTextFormat = "";
		private PivotGridFieldInfoCollection _xAxisTextFields = new PivotGridFieldInfoCollection();
		private List<string> _xAxisIdentityValue = new List<string>();

		private string _factValueField = null;
		#endregion

		#region Properties
		public DataTable DataSource
		{
			get { return _dataSource; }
			set { _dataSource = value; }
		}

		public string YAxisValueField
		{
			get { return _yAxisValueField; }
			set { _yAxisValueField = value; }
		}

		public string YAxisTextFormat
		{
			get { return _yAxisTextFormat; }
			set { _yAxisTextFormat = value; }
		}

		public PivotGridFieldInfoCollection YAxisTextFields
		{
			get { return _yAxisTextFields; }
			set { _yAxisTextFields = value; }
		}

		public List<string> YAxisIdentityValue
		{
			get { return _yAxisIdentityValue; }
			set { _yAxisIdentityValue = value; }
		}

		public string XAxisValueField
		{
			get { return _xAxisValueField; }
			set { _xAxisValueField = value; }
		}

		public string XAxisTextFormat
		{
			get { return _xAxisTextFormat; }
			set { _xAxisTextFormat = value; }
		}

		public PivotGridFieldInfoCollection XAxisTextFields
		{
			get { return _xAxisTextFields; }
			set { _xAxisTextFields = value; }
		}

		public List<string> XAxisIdentityValue
		{
			get { return _xAxisIdentityValue; }
			set { _xAxisIdentityValue = value; }
		}

		public string FactValueField
		{
			get { return _factValueField; }
			set { _factValueField = value; }
		}
		#endregion

		#region Rendering Logic
		protected override void Render (HtmlTextWriter writer)
		{
			if (_dataSource != null && _dataSource.Rows.Count > 0)
			{
				RenderGridBegin(writer);
				RenderGridHeader(writer);
				RenderGridContent(writer);
				RenderGridEnd(writer);
			}
		}

		private void RenderGridHeader (HtmlTextWriter writer)
		{
			DataTable xAxisItems = DataTableHelper.SelectDistinct(_dataSource, _xAxisValueField);
			int xAxisItemsCount = xAxisItems.Rows.Count;

			// render x axis items
			RenderRowBegin(writer);
			RenderDummyCell(writer);
			foreach (DataRow xAxisRow in xAxisItems.Rows)
			{
				string xAxisValue = xAxisRow[_xAxisValueField].ToString();

				PivotGridAxisCellEventArgs axisArgs = new PivotGridAxisCellEventArgs();
				axisArgs.Text = xAxisValue;
				RenderAxisCell(writer, axisArgs);
			}
			RenderRowEnd(writer);

			// render data cell names
			RenderRowBegin(writer);
			for (int xAxisItemIndex = 0; xAxisItemIndex < xAxisItemsCount; xAxisItemIndex++)
			{
				RenderDataHeaderCell(writer, _factValueField);
			}
			RenderRowEnd(writer);
		}

		private void RenderGridContent (HtmlTextWriter writer)
		{
			DataTable yAxisItems = DataTableHelper.SelectDistinct(_dataSource, _yAxisValueField);
			DataTable xAxisItems = DataTableHelper.SelectDistinct(_dataSource, _xAxisValueField);

			foreach (DataRow yAxisRow in yAxisItems.Rows)
			{
				RenderRowBegin(writer);

				string yAxisValue = yAxisRow[_yAxisValueField].ToString();

				PivotGridAxisCellEventArgs axisArgs = new PivotGridAxisCellEventArgs();
				axisArgs.Text = yAxisValue;
				RenderAxisCell(writer, axisArgs);
				
				foreach (DataRow xAxisRow in xAxisItems.Rows)
				{
					string xAxisValue = xAxisRow[_xAxisValueField].ToString();

					string expression = string.Format("{0}='{1}' and {2}='{3}'",
						_yAxisValueField, yAxisValue,
						_xAxisValueField, xAxisValue
						);
					DataRow[] founded = _dataSource.Select(expression);

					string value = "";
					if (founded.Length > 0)
					{
						value = founded[0][_factValueField].ToString();
					}
					PivotGridDataCellEventArgs dataArgs = new PivotGridDataCellEventArgs();
					dataArgs.Text = value;
					RenderDataCell(writer, dataArgs);
				}
				RenderRowEnd(writer);
			}
		}
		#endregion

		#region Rendering
		protected virtual void RenderGridBegin (HtmlTextWriter writer)
		{
		}

		protected virtual void RenderGridEnd (HtmlTextWriter writer)
		{
		}

		protected virtual void RenderRowBegin (HtmlTextWriter writer)
		{
		}

		protected virtual void RenderRowEnd (HtmlTextWriter writer)
		{
		}

		protected virtual void RenderDummyCell (HtmlTextWriter writer)
		{
		}

		protected virtual void RenderAxisCell (HtmlTextWriter writer, PivotGridAxisCellEventArgs args)
		{
		}

		protected virtual void RenderDataHeaderCell (HtmlTextWriter writer, string text)
		{
		}

		protected virtual void RenderDataCell (HtmlTextWriter writer, PivotGridDataCellEventArgs args)
		{
		}
		#endregion

		#region DataTableUtility
		/// <summary>
		/// Source:
		/// HOW TO: Implement a DataSet SELECT DISTINCT Helper Class in Visual C# .NET
		/// http://support.microsoft.com/default.aspx?scid=kb;en-us;326176
		/// </summary>
		protected static class DataTableHelper
		{
			private static bool ColumnEqual (object a, object b)
			{
				// Compares two values to see if they are equal. Also compares DBNULL.Value.
				// Note: If your DataTable contains object fields, then you must extend this
				// function to handle them in a meaningful way if you intend to group on them.

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
		#endregion
	}
}