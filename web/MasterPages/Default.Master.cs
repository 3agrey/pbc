using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AIM.PBC.Web.MasterPages
{
	public partial class Default : System.Web.UI.MasterPage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Load += new EventHandler(Page_Load);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			DataBind();
		}
	}
}
