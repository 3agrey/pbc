using System;
using System.Globalization;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Web.UI.Controls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class EditAccount : BasePage
	{
		public static class PageParameters
		{
			public const string AccountId = "AccountId";
		}
		
		protected int ParamAccountId
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

		public override string PageTitle
		{
			get { return OperationText + base.PageTitle; }
		}

		protected string OperationText
		{
			get
			{
				if (ParamAccountId == -1)
				{
					return "Add";
				}
				else
				{
					return "Edit";	
				}
			}
		}
		
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			DataBind();
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Page_Load);
			cvPage.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(cvPage_ServerValidate);
			btnAddSubmit.Click += new EventHandler(btnAddSubmit_Click);
			btnAddCancel.Click += new EventHandler(btnAddCancel_Click);
			btnEditSubmit.Click += new EventHandler(btnEditSubmit_Click);
			btnEditCancel.Click += new EventHandler(btnEditCancel_Click);
		}

		protected void Page_Load (object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (ParamAccountId == -1)
				{
					InitAddOperation();
				}
				else
				{
					InitEditOperation();
				}
				
				phAddMode.Visible = (ParamAccountId == -1);
				phEditMode.Visible = !phAddMode.Visible;
			}
		}
		
		private void InitAddOperation ()
		{
			dpBeginningBalanceDate.SelectedDate = DateTime.Today;	
		}

		private void InitEditOperation ()
		{
			Account entity = AccountProvider.Get(ParamAccountId);
			tbName.Text = entity.Name;
			tbBeginningBalance.Text = entity.BeginningBalance.ToString();
			dpBeginningBalanceDate.SelectedDate = entity.BeginningBalanceDate;
		}

		private void cvPage_ServerValidate (object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			// name
			if (tbName.Text.Length == 0)
			{
				ctrlClientMessage.Messages.Add("Field 'Name' is required");	
			}
			
			// amount
			try
			{
				decimal.Parse(tbBeginningBalance.Text);
			}
			catch
			{
				ctrlClientMessage.Messages.Add("Please type beginning balance in valid format, like '1000.50, -580.25'");
			}
			
			bool isValid = (ctrlClientMessage.Messages.Count == 0);
			if (!isValid)
			{
				ctrlClientMessage.ShowListMessages("There are some errors in the form:", ClientMessageTypes.Error);
			}
			args.IsValid = isValid;
		}

		private void btnAddSubmit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				Account entity = new Account();
				//entity.UserId = SessionManager.CurrentUser.Id;
				entity.Name = tbName.Text;
				entity.BeginningBalance = decimal.Parse(tbBeginningBalance.Text);
				entity.BeginningBalanceDate = dpBeginningBalanceDate.SelectedDate;
				entity.User = SessionManager.CurrentUser;
				AccountProvider.Add(entity);
				Response.Redirect("Accounts.aspx");
			}
		}

		private void btnAddCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("Accounts.aspx");
		}

		private void btnEditSubmit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				Account entity = AccountProvider.Get(ParamAccountId);
				entity.Name = tbName.Text;
				entity.BeginningBalance = decimal.Parse(tbBeginningBalance.Text);
				entity.BeginningBalanceDate = dpBeginningBalanceDate.SelectedDate;
				AccountProvider.Update(entity);
				Response.Redirect("Accounts.aspx");
			}
		}

		private void btnEditCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("Accounts.aspx");
		}
	}
}
