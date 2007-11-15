using System;
using System.Data;
using AIM.PBC.Core;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class Accounts : BasePage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			DataBind();
		}

		private void RegisterEventHandlers()
		{
			Load += new EventHandler(Page_Load);
			btnAdd.Click += new EventHandler(btnAdd_Click);
			btnGoHome.Click += new EventHandler(btnGoHome_Click);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				int userId = SessionManager.CurrentUser.Id;
				DataTable accountsStat = AccountProvider.GetStatistic(userId);
				rpAccounts.DataSource = accountsStat;
				rpAccounts.DataBind();
				phEmpty.Visible = accountsStat.Rows.Count == 0;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Response.Redirect("EditAccount.aspx");
		}

		private void btnGoHome_Click (object sender, EventArgs e)
		{
			Response.Redirect("Default.aspx");
		}
	}
}
