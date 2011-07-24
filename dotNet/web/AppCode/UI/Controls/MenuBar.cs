using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIM.PBC.Web.UI.Controls
{
	[ParseChildren(true)]
	public class MenuBar : Control
	{
		public static string ImagesDir = "";

		private Unit _width = Unit.Empty;
		private MenuItemList _items = new MenuItemList();

		public MenuItemList Items
		{
			get { return _items; }
			set { _items = value; }
		}

		protected override void Render (HtmlTextWriter writer)
		{
			RenderHeader(writer);
			RenderItems(writer);
			RenderFooter(writer);
		}
		
		private void RenderHeader (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

			writer.Write("<table border='0' cellpadding='0' cellspacing='0'");
			StringBuilder style = new StringBuilder();
			if (!_width.IsEmpty)
			{
				style.Append("width:" + _width.ToString());
			}
			writer.Write(" style='" + style.ToString() + "'");
			writer.WriteLine(">");
			writer.WriteLine("<tr>");
			writer.WriteLine("<td class='menu_l'>" + spacer + "</td>");
			writer.WriteLine("<td class='menu_c' align='right'>");
		}
		
		private void RenderItems (HtmlTextWriter writer)
		{
			for (int menuIndex = 0; menuIndex < _items.Count; menuIndex ++)
			{
				MenuItem item = _items[menuIndex];
				if (menuIndex == 0)
				{
					writer.Write("&nbsp;");
				}
				string text = string.Format("<a href='{0}' class='menu_link'>{1}</a>", item.Url, item.Text);
				writer.Write(text);
				if (menuIndex == _items.Count - 1)
				{
					writer.Write("&nbsp;");
				}
				else
				{
					writer.Write("<span class='menu_sp'>&nbsp;|&nbsp;</span>");
				}
			}
		}
		
		private void RenderFooter (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("</td>");
			writer.WriteLine("<td class='menu_r'>" + spacer + "</td>");
			writer.WriteLine("</tr>");
			writer.WriteLine("</table>");
		}
	}
}
