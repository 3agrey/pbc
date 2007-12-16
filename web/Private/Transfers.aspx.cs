using System;
using System.Collections.ObjectModel;
using System.Web.UI;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class Transfers : BasePage
	{
		public static class PageParameters
		{
			public const string AccountId = "AccountId";
		}

		protected int AccountId
		{
			get
			{
				int result = -1;
				try
				{
					result = int.Parse(Request.QueryString[PageParameters.AccountId]);
				}
				catch { }
				return result;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			RegisterEventHandlers();
			base.OnInit(e);
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
				ReadOnlyCollection<Transfer> list;
				if (AccountId != -1)
				{
					list = TransferProvider.GetListByAccount(AccountId);
				}
				else
				{
					list = TransferProvider.GetListByUser(userId);
				}

				rpTransfers.DataSource = list;
				rpTransfers.DataBind();
				
				phEmpty.Visible = (list.Count == 0);

				DataBind();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Response.Redirect("EditTransfer.aspx");
		}

		private void btnGoHome_Click (object sender, EventArgs e)
		{
			Response.Redirect("Default.aspx");
		}
	}
}
