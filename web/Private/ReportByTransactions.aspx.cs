using System;
using System.Data;
using System.Web.UI.WebControls;
using AIM.PBC.Core;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class ReportByTransactions : BasePage
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			InitControls();
			DataBind();
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Page_Load);
		}

		private void InitControls ()
		{
			BoundField column = new BoundField();
			column.HeaderText = GetLocalString("ColumnTransferName");
			column.DataField = "TransferName";
			gvReport.Columns.Add(column);

			column = new BoundField();
			column.HeaderText = GetLocalString("ColumnSourceAccountName");
			column.DataField = "SourceAccountName";
			gvReport.Columns.Add(column);

			column = new BoundField();
			column.HeaderText = GetLocalString("ColumnTargetAccountName");
			column.DataField = "TargetAccountName";
			gvReport.Columns.Add(column);

			column = new BoundField();
			column.HeaderText = GetLocalString("ColumnTransactionDate");
			column.DataField = "TransactionDate";
			gvReport.Columns.Add(column);

			column = new BoundField();
			column.HeaderText = GetLocalString("ColumnTransactionAmount");
			column.DataField = "TransactionAmount";
			gvReport.Columns.Add(column);
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
			DataTable reportData = ReportProvider.GetReportByTransactions(SessionManager.CurrentUser.Id);
			gvReport.DataSource = reportData;
			gvReport.DataBind();
		}
	}
}
