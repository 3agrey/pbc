using System;
using System.Data;
using AIM.PBC.Core;
using AIM.PBC.Web.AppCode;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class ReportByAccounts : BasePage
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
			pgReport.XAxisValueField = "AccountName";
			pgReport.YAxisValueField = "Date";
			pgReport.FactValueField = "Balance";
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
			pgReport.DataSource = reportData;
			pgReport.DataBind();
		}
	}
}
