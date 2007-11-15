using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIM.PBC.Core;
using AIM.PBC.Web.UI.Controls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class EditDepositTransfer : BasePage
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

		protected string OperationText
		{
			get
			{
				if (ParamTransferId == -1)
				{
					return GetGlobalString("OperationAdd");
				}
				else
				{
					return GetGlobalString("OperatioEdit");
				}
			}
		}

		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			InitControls();
			BindControls();
			DataBind();
		}
		private void InitControls ()
		{
			// Incremental Period Type
			rblIncrementPeriodType.Items.Clear();

			ListItem periodType = new ListItem(GetGlobalString("PeriodTypeStandard"), "1");
			periodType.Attributes.Add("onclick", "SelectStandardPeriod()");
			rblIncrementPeriodType.Items.Add(periodType);

			periodType = new ListItem(GetGlobalString("PeriodTypeCustom"), "2");
			periodType.Attributes.Add("onclick", "SelectCustomPeriod()");
			rblIncrementPeriodType.Items.Add(periodType);

			// Incremental Standard Periods
			rblIncrementStandardPeriod.Items.Clear();
			rblIncrementStandardPeriod.Items.Add(new ListItem(GetGlobalString("Daily"), "1"));
			rblIncrementStandardPeriod.Items.Add(new ListItem(GetGlobalString("Weekly"), "2"));
			rblIncrementStandardPeriod.Items.Add(new ListItem(GetGlobalString("Monthly"), "3"));
			rblIncrementStandardPeriod.Items.Add(new ListItem(GetGlobalString("Yearly"), "4"));
		}

		private void BindControls ()
		{
			BindAccountSelectors();
		}

		private void BindAccountSelectors ()
		{
			AccountList list = AccountProvider.GetList(SessionManager.CurrentUser.Id);
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
			btnUpdateSubmit.Click += new EventHandler(btnUpdateSubmit_Click);
			btnUpdateCancel.Click += new EventHandler(btnUpdateCancel_Click);
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

			// beginning amount
			try
			{
				decimal.Parse(tbBeginningAmount.Text);
			}
			catch
			{
				ctrlClientMessage.Messages.Add("Please type beginning amount in valid format, like '1000.50, -580.25'");
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

			// increment amount
			try
			{
				decimal.Parse(tbIncrementAmount.Text);
			}
			catch
			{
				ctrlClientMessage.Messages.Add("Please type increment amount in valid format, like '1000.50, -580.25'");
			}

			// custom period
			if (rblIncrementPeriodType.SelectedValue == ((byte) PeriodTypes.Custom).ToString())
			{
				try
				{
					int.Parse(tbIncrementCustomPeriod.Text);
				}
				catch
				{
					ctrlClientMessage.Messages.Add("Please type custom period in valid format, like '27, 14'");
				}
			}

			bool isValid = (ctrlClientMessage.Messages.Count == 0);
			if (!isValid)
			{
				ctrlClientMessage.ShowListMessages("There are some errors in the form:", ClientMessageTypes.Error);
			}
			args.IsValid = isValid;
		}

		private void btnUpdateCancel_Click (object sender, EventArgs e)
		{
			Response.Redirect("Transfers.aspx");
		}

		private void btnUpdateSubmit_Click (object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				DepositTransfer entity = (DepositTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Deposit);
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
				entity.BeginningAmount = decimal.Parse(tbBeginningAmount.Text);
				entity.Percentage = float.Parse(tbPercentage.Text);
				entity.StartDate = dpStartDate.SelectedDate;
				entity.Period = int.Parse(tbPeriod.Text);
				entity.IncrementAmount = decimal.Parse(tbIncrementAmount.Text);
				if (rblIncrementPeriodType.SelectedValue == ((byte) PeriodTypes.Standard).ToString())
				{
					entity.IncrementPeriodType = (byte) PeriodTypes.Standard;
					entity.IncrementStandardPeriod = byte.Parse(rblIncrementStandardPeriod.SelectedValue);
				}
				else
				{
					entity.IncrementPeriodType = (byte) PeriodTypes.Custom;
					entity.IncrementCustomPeriod = int.Parse(tbIncrementCustomPeriod.Text);
				}
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
				DepositTransfer entity = new DepositTransfer();
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
				entity.BeginningAmount = decimal.Parse(tbBeginningAmount.Text);
				entity.Percentage = float.Parse(tbPercentage.Text);
				entity.StartDate = dpStartDate.SelectedDate;
				entity.Period = int.Parse(tbPeriod.Text);
				entity.IncrementAmount = decimal.Parse(tbIncrementAmount.Text);
				if (rblIncrementPeriodType.SelectedValue == ((byte) PeriodTypes.Standard).ToString())
				{
					entity.IncrementPeriodType = (byte) PeriodTypes.Standard;
					entity.IncrementStandardPeriod = byte.Parse(rblIncrementStandardPeriod.SelectedValue);
				}
				else
				{
					entity.IncrementPeriodType = (byte) PeriodTypes.Custom;
					entity.IncrementCustomPeriod = int.Parse(tbIncrementCustomPeriod.Text);
				}
				TransferProvider.Add(entity);
				Response.Redirect("Transfers.aspx");
			}
		}

		private void InitEditOperation ()
		{
			DepositTransfer entity = (DepositTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Deposit);
			if (!entity.SourceAccountId.IsNull)
			{
				ddlSourceAccount.Items.FindByValue(entity.SourceAccountId.ToString()).Selected = true;
			}
			else
			{
				ddlSourceAccount.Items.FindByValue(ddlSourceAccount.ExternalAccountValue.ToString()).Selected = true;
			}
			if (!entity.TargetAccountId.IsNull)
			{
				ddlTargetAccount.Items.FindByValue(entity.TargetAccountId.ToString()).Selected = true;
			}
			else
			{
				ddlTargetAccount.Items.FindByValue(ddlTargetAccount.ExternalAccountValue.ToString()).Selected = true;
			}
			tbName.Text = entity.Name;
			tbBeginningAmount.Text = entity.BeginningAmount.ToString();
			tbPercentage.Text = entity.Percentage.ToString();
			dpStartDate.SelectedDate = entity.StartDate;
			tbPeriod.Text = entity.Period.ToString();
			tbIncrementAmount.Text = entity.IncrementAmount.ToString();
			if (entity.IncrementPeriodType == (byte) PeriodTypes.Standard)
			{
				SelectStandardPeriod();
				rblIncrementStandardPeriod.Items.FindByValue(entity.IncrementStandardPeriod.ToString()).Selected = true;
			}
			else
			{
				SelectCustomPeriod();
				rblIncrementStandardPeriod.Items.FindByValue(((byte) StandardPeriods.Monthly).ToString()).Selected = true;
				tbIncrementCustomPeriod.Text = entity.IncrementCustomPeriod.ToString();
			}

		}

		private void InitAddOperation ()
		{
			dpStartDate.SelectedDate = DateTime.Today;
			SelectStandardPeriod();
			rblIncrementStandardPeriod.Items.FindByValue(((byte) StandardPeriods.Monthly).ToString()).Selected = true;
		}

		private void SelectStandardPeriod ()
		{
			rblIncrementPeriodType.Items.FindByValue(((byte) PeriodTypes.Standard).ToString()).Selected = true;
		}

		private void SelectCustomPeriod ()
		{
			rblIncrementPeriodType.Items.FindByValue(((byte) PeriodTypes.Custom).ToString()).Selected = true;
		}
	}
}
