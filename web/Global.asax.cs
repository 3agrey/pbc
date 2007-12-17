using System;
using System.Web;
using Panel=Aim.Web.Controls.Panel;

namespace AIM.PBC.Web
{
	public class Global : HttpApplication
	{
		protected void Application_Start (object sender, EventArgs e)
		{
			// Init core
			AIM.PBC.Core.Settings.ConnectionString = Settings.ConnectionString;
			AIM.PBC.Core.Settings.IsDebug = Settings.IsDebug;
			
			// Init controls
			AIM.PBC.Web.UI.Controls.ClientMessage.ImagesDir = "~/Images/ClientMessage/";
			Panel.ImagesDir = "~/Images/WindowPanel/";
			AIM.PBC.Web.UI.Controls.MenuBar.ImagesDir = "~/Images/MenuBar/";
		}
		
		protected void Application_End (object sender, EventArgs e)
		{
		}

		protected void Application_Error (object sender, EventArgs e)
		{
		}

		protected void Session_Start (object sender, EventArgs e)
		{
		}

		protected void Session_End (object sender, EventArgs e)
		{
		}
		
		protected void Application_AuthenticateRequest (Object sender, EventArgs e)
		{
		}
	}
}