using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Web.AppCode;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class EditTransfer : BasePage
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
			get { return String.Format("{0} {1}", OperationText, GetLocalString("Transfer")); }
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
					return GetGlobalString("OperationEdit");
				}
			}
		}

		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Page_Load);
			btnSubmit.Click += new EventHandler(btnSubmit_Click);
			btnCancel.Click += new EventHandler(btnCancel_Click);
		}

		protected void Page_Load (object sender, EventArgs e)
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
			}
			DataBind();
		}

		private void InitAddOperation ()
		{
			rblType.Items.Clear();
			rblType.Items.Add(new ListItem(GetGlobalString("TransferSingle"), ((byte) TransferTypes.Single).ToString()));
			rblType.Items.Add(new ListItem(GetGlobalString("TransferPeriodical"), ((byte) TransferTypes.Periodical).ToString()));
			rblType.Items.Add(new ListItem(GetGlobalString("TransferPercentage"), ((byte) TransferTypes.Percentage).ToString()));
			rblType.Items[0].Selected = true;
		}

		private void InitEditOperation ()
		{
			Transfer selectedTransfer = TransferProvider.Get(ParamTransferId);
			switch (selectedTransfer.Type)
			{
				case TransferTypes.Single:
					Response.Redirect("EditSingleTransfer.aspx?" + EditSingleTransfer.PageParameters.TransferId + "=" + ParamTransferId.ToString());
					break;
				case TransferTypes.Periodical:
					Response.Redirect("EditPeriodicalTransfer.aspx?" + EditPeriodicalTransfer.PageParameters.TransferId + "=" + ParamTransferId.ToString());
					break;
				case TransferTypes.Percentage:
					Response.Redirect("EditPercentageTransfer.aspx?" + EditPercentageTransfer.PageParameters.TransferId + "=" + ParamTransferId.ToString());
					break;
				default:
					throw new NotSupportedException();
			}
		}

		private void btnSubmit_Click (object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				TransferTypes selectedType = (TransferTypes) Enum.Parse(typeof(TransferTypes), rblType.SelectedValue);
				switch (selectedType)
				{
					case TransferTypes.Single:
						Response.Redirect("EditSingleTransfer.aspx");
						break;
					case TransferTypes.Periodical:
						Response.Redirect("EditPeriodicalTransfer.aspx");
						break;
					case TransferTypes.Percentage:
						Response.Redirect("EditPercentageTransfer.aspx");
						break;
				}
			}
		}

		private void btnCancel_Click (object sender, EventArgs e)
		{
			Response.Redirect("Transfers.aspx");
		}
	}
}
