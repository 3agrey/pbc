using System;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Web.AppCode;
using AIM.PBC.Web.UI.Controls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class EditPercentageTransfer : BasePage
	{
		public static class PageParameters
		{
			public const string TransferId = "TransferId";
		}

		protected int ParamTransferId
		{
			get
			{
				int result = -1;
				try
				{
					result = int.Parse(Request.QueryString[PageParameters.TransferId]);
				}
				catch { }
				return result;
			}
		}

		public override string PageTitle
		{
			get { return OperationText + " Percentage Transfer"; }
		}

		protected string OperationText
		{
			get
			{
				if (ParamTransferId == -1)
				{
					return "Add";
				}
				else
				{
					return "Edit";
				}
			}
		}

		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			BindControls();
			DataBind();
		}

		private void BindControls ()
		{
			BindAccountSelectors();
		}

		private void BindAccountSelectors ()
		{
			ReadOnlyCollection<Account> list = AccountProvider.GetList(SessionManager.CurrentUser.Id);
			ddlSourceAccount.DataSource = list;
			ddlSourceAccount.DataTextField = "Name";
			ddlSourceAccount.DataValueField = "Id";

			ddlTargetAccount.DataSource = list;
			ddlTargetAccount.DataTextField = "Name";
			ddlTargetAccount.DataValueField = "Id";
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Page_Load);
			cvPage.ServerValidate += new ServerValidateEventHandler(cvPage_ServerValidate);
			btnAddSubmit.Click += new EventHandler(btnAddSubmit_Click);
			btnAddCancel.Click += new EventHandler(btnAddCancel_Click);
			btnEditSubmit.Click += new EventHandler(btnEditSubmit_Click);
			btnEditCancel.Click += new EventHandler(btnEditCancel_Click);
		}

		private void Page_Load (object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (ParamTransferId == -1)
				{
					InitAddOperation();
				}
				else
				{
					InitEditOperation();
				}

				phAddMode.Visible = (ParamTransferId == -1);
				phEditMode.Visible = !phAddMode.Visible;
			}
		}
		
		private void cvPage_ServerValidate (object source, ServerValidateEventArgs args)
		{
			// accounts
			if (ddlSourceAccount.SelectedAccountValue == ddlSourceAccount.EmptyValue)
			{
				ctrlClientMessage.Messages.Add("Please select 'Source Account'");
			}
			if (ddlTargetAccount.SelectedAccountValue == ddlTargetAccount.EmptyValue)
			{
				ctrlClientMessage.Messages.Add("Please select 'Target Account'");
			}
			if ((ddlSourceAccount.SelectedAccountValue == ddlSourceAccount.ExternalAccountValue) &&
				(ddlTargetAccount.SelectedAccountValue == ddlTargetAccount.ExternalAccountValue))
			{
				ctrlClientMessage.Messages.Add("Only one account can be 'External'");
			}

			// name
			if (tbName.Text.Length == 0)
			{
				ctrlClientMessage.Messages.Add("Transfer name is required");
			}

			// amount
			try
			{
				decimal.Parse(tbAmount.Text);
			}
			catch
			{
				ctrlClientMessage.Messages.Add("Please type transfer amount in valid format, like '1000.50, -580.25'");
			}
			
			// percentage
			float percentage = 0;
			try
			{
				percentage = float.Parse(tbPercentage.Text);
			}
			catch
			{
				ctrlClientMessage.Messages.Add("Please type transfer percentage in valid format, like '4.5, 12'");
			}
			if (percentage < 0 || percentage > 100)
			{
				ctrlClientMessage.Messages.Add("Transfer percentage value can be from 0 to 100'");
			}
			
			// period
			try
			{
				int.Parse(tbPeriod.Text);
			}
			catch
			{
				ctrlClientMessage.Messages.Add("Please type transfer period in valid format, like '60, 120'");
			}

			bool isValid = (ctrlClientMessage.Messages.Count == 0);
			if (!isValid)
			{
				ctrlClientMessage.ShowListMessages("There are some errors in the form:", ClientMessageTypes.Error);
			}
			args.IsValid = isValid;
		}

		private void btnEditCancel_Click (object sender, EventArgs e)
		{
			Response.Redirect("Transfers.aspx");
		}

		private void btnEditSubmit_Click (object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				PercentageTransfer entity = (PercentageTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Percentage);
				if (ddlSourceAccount.SelectedAccountValue == 0)
				{
					entity.SourceAccountId = null;
				}
				else
				{
					entity.SourceAccountId = ddlSourceAccount.SelectedAccountValue;
				}
				if (ddlTargetAccount.SelectedAccountValue == 0)
				{
					entity.TargetAccountId = null;
				}
				else
				{
					entity.TargetAccountId = ddlTargetAccount.SelectedAccountValue;
				}
				entity.Name = tbName.Text;
				entity.Amount = decimal.Parse(tbAmount.Text);
				entity.Percentage = float.Parse(tbPercentage.Text);
				entity.StartDate = dpStartDate.SelectedDate;
				entity.Period = int.Parse(tbPeriod.Text);
				TransferProvider.Update(entity);
				Response.Redirect("Transfers.aspx");
			}
		}

		private void btnAddCancel_Click (object sender, EventArgs e)
		{
			Response.Redirect("Transfers.aspx");
		}

		private void btnAddSubmit_Click (object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				PercentageTransfer entity = new PercentageTransfer();
				if (ddlSourceAccount.SelectedAccountValue == 0)
				{
					entity.SourceAccountId = null;
				}
				else
				{
					entity.SourceAccountId = ddlSourceAccount.SelectedAccountValue;
				}
				if (ddlTargetAccount.SelectedAccountValue == 0)
				{
					entity.TargetAccountId = null;
				}
				else
				{
					entity.TargetAccountId = ddlTargetAccount.SelectedAccountValue;
				}
				entity.Name = tbName.Text;
				entity.Amount = decimal.Parse(tbAmount.Text);
				entity.Percentage = float.Parse(tbPercentage.Text);
				entity.StartDate = dpStartDate.SelectedDate;
				entity.Period = int.Parse(tbPeriod.Text);
				TransferProvider.Add(entity);
				Response.Redirect("Transfers.aspx");
			}
		}

		private void InitEditOperation ()
		{
			PercentageTransfer entity = (PercentageTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Percentage);
			if (entity.SourceAccountId != null)
			{
				ddlSourceAccount.Items.FindByValue(entity.SourceAccountId.ToString()).Selected = true;
			}
			else
			{
				ddlSourceAccount.Items.FindByValue(ddlSourceAccount.ExternalAccountValue.ToString()).Selected = true;
			}
			if (entity.TargetAccountId != null)
			{
				ddlTargetAccount.Items.FindByValue(entity.TargetAccountId.ToString()).Selected = true;
			}
			else
			{
				ddlTargetAccount.Items.FindByValue(ddlTargetAccount.ExternalAccountValue.ToString()).Selected = true;
			}
			tbName.Text = entity.Name;
			tbAmount.Text = entity.Amount.ToString();
			tbPercentage.Text = entity.Percentage.ToString();
			dpStartDate.SelectedDate = entity.StartDate;
			tbPeriod.Text = entity.Period.ToString();
		}

		private void InitAddOperation ()
		{
			dpStartDate.SelectedDate = DateTime.Today;
		}
	}
}
