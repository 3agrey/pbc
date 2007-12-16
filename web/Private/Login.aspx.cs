using System;
using AIM.PBC.Web;
using AIM.PBC.Web.AppCode;
using AIM.PBC.Web.UI.Controls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class Login : BasePage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
		}

		private void RegisterEventHandlers()
		{
			btnSubmit.Click += new EventHandler(btnSubmit_Click);
			Load += new EventHandler(Page_Load);
		}

		public override string PageTitle
		{
			get { return "Login"; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (SessionManager.IsAuthenticated)
			{
				Response.Redirect("Default.aspx");
			}
			DataBind();
			ClientScript.RegisterStartupScript(GetType(), "onload", "FocusUsernameBox();", true);
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				string username = tbUsername.Text;
				string password = tbPassword.Text;
				bool persistent = cbPersistent.Checked;
				bool succesfully = SessionManager.Login(username, password, persistent, true);
				if (!succesfully)
				{
					ctrlClientMessage.ShowSingleMessage("Your login attempt was not successful. Please try again.", ClientMessageTypes.Error);
				}
			}
		}
	}
}