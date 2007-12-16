using System;
using AIM.PBC.Web;
using AIM.PBC.Web.AppCode;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class Logout : BasePage
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Page_Load);
		}

		protected void Page_Load (object sender, EventArgs e)
		{
			SessionManager.Logout();
			SessionManager.RedirectToPublicHome();
		}
	}
}