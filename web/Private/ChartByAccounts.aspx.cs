using System;
using System.Data;
using System.Drawing;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Core.Utilities;
using AIM.PBC.Web.AppCode;
using Telerik.WebControls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class ChartByAccounts : BasePage
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			InitControls();
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Page_Load);
		}

		private void InitControls ()
		{
			rcReport.Title1.Text = "Chart by Accounts";
		}

		protected void Page_Load (object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindReportGrid();
			}
		}

		private void BindReportGrid ()
		{
			DataTable reportData = ReportProvider.GetReportByAccounts(SessionManager.CurrentUser.Id);

			DataTable xAxisItems = DataTableUtility.SelectDistinct(reportData, "Date");
			rcReport.XAxis.Clear();
			foreach (DataRow row in xAxisItems.Rows)
			{
				DateTime date = (DateTime) row["Date"];
				rcReport.XAxis.AddItem(date.ToString("MM/dd/yyyy"));
			}

			DataTable accounts = DataTableUtility.SelectDistinct(reportData, "AccountId");
			foreach (DataRow accountRow in accounts.Rows)
			{
				int accountId = (int) accountRow["AccountId"];
				Account account = AccountProvider.Get<Account>(accountId);

				ChartSeries series = new ChartSeries(account.Name, _currentColor, ChartSeriesType.Line);
				series.PointMark = ChartPointMark.None;
				series.ShowLabels = false;

				DataTable dates = DataTableUtility.SelectDistinct(reportData, "Date");
				foreach (DataRow dateRow in dates.Rows)
				{
					DateTime date = (DateTime) dateRow["Date"];
					double balance = 0;
					string expression = string.Format("AccountId='{0}' and Date='{1}'", accountId, date);
					DataRow[] founded = reportData.Select(expression);
					if (founded.Length > 0)
					{
						balance = Convert.ToDouble(founded[0]["Balance"]);
					}
					series.AddItem(balance);
				}
				
				rcReport.AddChartSeries(series);
				SetNextColor();
			}
		}


		private Color _currentColor = Color.Red;
		private void SetNextColor ()
		{
			if (_currentColor == Color.Red)
			{
				_currentColor = Color.Blue;
			}
			else if (_currentColor == Color.Blue)
			{
				_currentColor = Color.Green;	
			}
		}
	}
}
