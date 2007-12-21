using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Aim.Web.Controls.Utilities
{
	public static class WebUtility
	{
		public static HtmlLink CreateStyleSheet(string path)
		{
			if (String.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
			
			HtmlLink cssLink = new HtmlLink();
			cssLink.Href = path;
			cssLink.Attributes.Add("rel", "stylesheet");
			cssLink.Attributes.Add("type", ContentTypes.TEXT_CSS);
			return cssLink;
		}

		public static void AddStyleSheet(Page page, string path)
		{
			HtmlLink css = CreateStyleSheet(path);
			page.Header.Controls.Add(css);
		}
	}
}