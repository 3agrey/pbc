using System;

namespace AIM.PBC.Web.Pages.CustomErrors
{
	public partial class AccessDenied : BasePage
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

		}
	}
}
