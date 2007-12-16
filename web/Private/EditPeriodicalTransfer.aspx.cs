using System;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Web.AppCode;
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


		public override string PageTitle
		{
			get { return OperationText + " Periodical Transfer"; }
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
			if (!ddlSourceAccount.HasSelectedAccount)
			{
				ctrlClientMessage.Messages.Add("Please select 'Source Account'");
			}
			if (!ddlTargetAccount.HasSelectedAccount)
			{
				ctrlClientMessage.Messages.Add("Please select 'Target Account'");
			}
			if ((!ddlSourceAccount.HasSelectedAccount) &&
				(!ddlTargetAccount.HasSelectedAccount))
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
				
				entity.SourceAccount = ddlSourceAccount.SelectedAccount;
				entity.TargetAccount = ddlTargetAccount.SelectedAccount;
				
				entity.Name = tbName.Text;
				entity.Amount = decimal.Parse(tbAmount.Text);
				entity.StartDate = dpStartDate.SelectedDate;
				entity.EndDate = dpEndDate.SelectedDate;
				if (rblPeriodType.SelectedValue == ((byte) PeriodTypes.Standard).ToString())
				{
					entity.PeriodType = PeriodTypes.Standard;
					entity.StandardPeriod = (StandardPeriods) Enum.Parse(typeof(StandardPeriods), rblStandardPeriod.SelectedValue);
				}
				else
				{
					entity.PeriodType = PeriodTypes.Custom;
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

				entity.SourceAccount = ddlSourceAccount.SelectedAccount;
				entity.TargetAccount = ddlTargetAccount.SelectedAccount;

				entity.Name = tbName.Text;
				entity.Amount = decimal.Parse(tbAmount.Text);
				entity.StartDate = dpStartDate.SelectedDate;
				entity.EndDate = dpEndDate.SelectedDate;
				if(rblPeriodType.SelectedValue == ((byte)PeriodTypes.Standard).ToString())
				{
					entity.PeriodType = PeriodTypes.Standard;
					entity.StandardPeriod = (StandardPeriods)Enum.Parse(typeof(StandardPeriods), rblStandardPeriod.SelectedValue);
				}
				else
				{
					entity.PeriodType = PeriodTypes.Custom;
					entity.CustomPeriod = int.Parse(tbCustomPeriod.Text);
				}
				TransferProvider.Add(entity);
				Response.Redirect("Transfers.aspx");
			}
		}

		private void InitEditOperation ()
		{
			PeriodicalTransfer entity = (PeriodicalTransfer) TransferProvider.Get(ParamTransferId, TransferTypes.Periodical);

			ddlSourceAccount.SelectedAccount = entity.SourceAccount;
			ddlTargetAccount.SelectedAccount = entity.TargetAccount;

			tbName.Text = entity.Name;
			tbAmount.Text = entity.Amount.ToString();
			dpStartDate.SelectedDate = entity.StartDate;
			dpEndDate.SelectedDate = entity.EndDate;
			if(entity.PeriodType == PeriodTypes.Standard)
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
