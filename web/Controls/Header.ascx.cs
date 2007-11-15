using System;
using AIM.PBC.Web;

namespace AIM.PBC.Web.Controls
{
	public partial class Header : System.Web.UI.UserControl
	{
		protected string UserFullname
		{
			get
			{
				string result = "";
				if (SessionManager.IsAuthenticated)
				{
					result = SessionManager.CurrentUser.Fullname;
				}
				return result;
			}
		}

		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
		}

		private void RegisterEventHandlers ()
		{
			Load += new EventHandler(Control_Load);
		}

		protected void Control_Load (object sender, EventArgs e)
		{
			DataBind();
		}
	}
}