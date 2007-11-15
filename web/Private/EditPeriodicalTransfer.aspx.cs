using System;
using System.Web.UI.WebControls;
using AIM.PBC.Core;
using AIM.PBC.Web.UI.Controls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class EditPeriodicalTransfer : BasePage
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
			PreRender += new EventHandler(Page_PreRender);
			cvPage.ServerValidate += new ServerValidateEventHandler(cvPage_ServerValidate);
			btnAddSubmit.Click += new EventHandler(btnAddSubmit_Click);
			btnAddCancel.Click += new EventHandler(btnAddCancel_Click);
			btnEditSubmit.Click += new EventHandler(btnEditSubmit_Click);
			btnEditCancel.Click += new EventHandler(btnEditCancel_Click);
		}

		private void Page_PreRender (object sender, EventArgs e)
		{
			if (rblPeriodType.SelectedValue == ((byte) PeriodTypes.Standard).ToString())
			{
				trCustomPeriod.Attributes.Add("style", "display:none");
				trStandardPeriod.Attributes.Add("style", "display:");
			}
			else
			{
				trCustomPeriod.Attributes.Add("style", "display:");
				trStandardPeriod.Attributes.Add("style", "display:none");
			}
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
			
			// custom period
			if (rblPeriodType.SelectedValue == ((byte) PeriodTypes.Custom).ToString())
			{
				try
				{
					int.Parse(tbCustomPeriod.Text);
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

		private void btnEditCancel_Click (object sender, EventArgs e)
		{
			Response.Redirect("Transfers.aspx");
		}

		private void btnEditSubmit_Click (object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				PeriodicalTransfer entity = (PeriodicalTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Periodical);
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
				entity.StartDate = dpStartDate.SelectedDate;
				entity.EndDate = dpEndDate.SelectedDate;
				if (rblPeriodType.SelectedValue == ((byte) PeriodTypes.Standard).ToString())
				{
					entity.PeriodType = (byte) PeriodTypes.Standard;
					entity.StandardPeriod = byte.Parse(rblStandardPeriod.SelectedValue);
				}
				else
				{
					entity.PeriodType = (byte) PeriodTypes.Custom;
					entity.CustomPeriod = int.Parse(tbCustomPeriod.Text);
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
				PeriodicalTransfer entity = new PeriodicalTransfer();
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
				entity.StartDate = dpStartDate.SelectedDate;
				entity.EndDate = dpEndDate.SelectedDate;
				if(rblPeriodType.SelectedValue == ((byte)PeriodTypes.Standard).ToString())
				{
					entity.PeriodType = (byte)PeriodTypes.Standard;
					entity.StandardPeriod = byte.Parse(rblStandardPeriod.SelectedValue);
				}
				else
				{
					entity.PeriodType = (byte) PeriodTypes.Custom;
					entity.CustomPeriod = int.Parse(tbCustomPeriod.Text);
				}
				TransferProvider.Add(entity);
				Response.Redirect("Transfers.aspx");
			}
		}

		private void InitEditOperation ()
		{
			PeriodicalTransfer entity = (PeriodicalTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Periodical);
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
			tbAmount.Text = entity.Amount.ToString();
			dpStartDate.SelectedDate = entity.StartDate;
			dpEndDate.SelectedDate = entity.EndDate;
			if(entity.PeriodType == (byte)PeriodTypes.Standard)
			{
				SelectStandardPeriod();
				rblStandardPeriod.Items.FindByValue(entity.StandardPeriod.ToString()).Selected = true;
			}
			else
			{
				SelectCustomPeriod();
				rblStandardPeriod.Items.FindByValue(((byte) StandardPeriods.Monthly).ToString()).Selected = true;
				tbCustomPeriod.Text = entity.CustomPeriod.ToString();
			}
		}

		private void InitAddOperation ()
		{
			dpStartDate.SelectedDate = DateTime.Today;
			dpEndDate.SelectedDate = DateTime.Today;
			SelectStandardPeriod();
			rblStandardPeriod.Items.FindByValue(((byte)StandardPeriods.Monthly).ToString()).Selected = true;
		}

		private void SelectStandardPeriod()
		{
			rblPeriodType.Items.FindByValue(((byte) PeriodTypes.Standard).ToString()).Selected = true;
		}

		private void SelectCustomPeriod ()
		{
			rblPeriodType.Items.FindByValue(((byte)PeriodTypes.Custom).ToString()).Selected = true;
		}
	}
}