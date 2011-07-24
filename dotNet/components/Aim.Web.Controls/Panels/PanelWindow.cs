using System.Text;
using System.Web.UI;

namespace Aim.Web.Controls.Panels
{
	internal class PanelWindow : PanelBase
	{
		public PanelWindow(Panel panel) : base(panel)
		{
		}

		public override void RenderHeader(HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(Panel.ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("");
			writer.Write("<table cellpadding='" + CellPadding + "' cellspacing='" + CellSpacing + "'");
			StringBuilder style = new StringBuilder();
			if (!Width.IsEmpty)
			{
				style.Append("width:" + Width + ";");
			}
			if (style.Length > 0)
			{
				writer.Write(" style='" + style + "'");
			}
			writer.WriteLine(">");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_window_ul'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_window_u'>");
			writer.WriteLine(Title);
			writer.WriteLine("		</td>");
			writer.WriteLine("		<td class='panel_window_ur'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_window_l'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_window_c' align='" + InnerAlign + "'>");
		}

		public override void RenderFooter(HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(Panel.ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("		</td>");
			writer.WriteLine("		<td class='panel_window_r'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_window_bl'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_window_b'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_window_br'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("</table>");
			writer.WriteLine("");
		}
	}
}