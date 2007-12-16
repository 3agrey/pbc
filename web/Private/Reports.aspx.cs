using System;
using AIM.PBC.Web.AppCode;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class Reports : BasePage
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
			DataBind();
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
