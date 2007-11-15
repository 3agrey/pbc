using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIM.PBC.Web.UI.Controls
{
	public class Panel : Control
	{
		public static string ImagesDir = "";

		private string _title = "Untitled";
		private Unit _width = Unit.Empty;
		private int _cellPadding = 0;
		private int _cellSpacing = 0;
		private PanelMode _mode = PanelMode.Window;
		private string _innerAlign = "center";

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		public Unit Width
		{
			get { return _width; }
			set { _width = value; }
		}
		public int CellPadding
		{
			get { return _cellPadding; }
			set { _cellPadding = value; }
		}
		public int CellSpacing
		{
			get { return _cellSpacing; }
			set { _cellSpacing = value; }
		}
		public PanelMode Mode
		{
			get { return _mode; }
			set { _mode = value; }
		}
		public string InnerAlign
		{
			get { return _innerAlign; }
			set { _innerAlign = value; }
		}

		protected override void Render (HtmlTextWriter writer)
		{
			RenderHeader(writer);
			base.Render(writer);
			RenderFooter(writer);
		}

		private void RenderHeader (HtmlTextWriter writer)
		{
			switch (_mode)
			{
				case PanelMode.Window:
					RenderHeader_Window(writer);
					break;
				case PanelMode.Blue:
					RenderHeader_Blue(writer);
					break;
				case PanelMode.Gray:
					RenderHeader_Gray(writer);
					break;
			}
		}

		private void RenderFooter (HtmlTextWriter writer)
		{
			switch (_mode)
			{
				case PanelMode.Window:
					RenderFooter_Window(writer);
					break;
				case PanelMode.Blue:
					RenderFooter_Blue(writer);
					break;
				case PanelMode.Gray:
					RenderFooter_Gray(writer);
					break;
			}
		}

		#region Render Header
		private void RenderHeader_Window (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";
			
			writer.WriteLine("");
			writer.Write("<table cellpadding='" + _cellPadding.ToString() + "' cellspacing='" + _cellSpacing.ToString() + "'");
			StringBuilder style = new StringBuilder();
			if (!_width.IsEmpty)
			{
				style.Append("width:" + _width.ToString() + ";");
			}
			if (style.Length > 0)
			{
				writer.Write(" style='" + style.ToString() + "'");
			}
			writer.WriteLine(">");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_window_ul'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_window_u'>");
			writer.WriteLine(_title);
			writer.WriteLine("		</td>");
			writer.WriteLine("		<td class='panel_window_ur'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_window_l'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_window_c' align='" + _innerAlign + "'>");
		}

		private void RenderHeader_Blue (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("");
			writer.Write("<table cellpadding='" + _cellPadding.ToString() + "' cellspacing='" + _cellSpacing.ToString() + "'");
			StringBuilder style = new StringBuilder();
			if (!_width.IsEmpty)
			{
				style.Append("width:" + _width.ToString() + ";");
			}
			if (style.Length > 0)
			{
				writer.Write(" style='" + style.ToString() + "'");
			}
			writer.WriteLine(">");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_blue_ul'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_blue_u'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_blue_ur'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_blue_l'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_blue_c' align='" + _innerAlign + "'>");
		}

		private void RenderHeader_Gray (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("");
			writer.Write("<table cellpadding='" + _cellPadding.ToString() + "' cellspacing='" + _cellSpacing.ToString() + "'");
			StringBuilder style = new StringBuilder();
			if (!_width.IsEmpty)
			{
				style.Append("width:" + _width.ToString() + ";");
			}
			if (style.Length > 0)
			{
				writer.Write(" style='" + style.ToString() + "'");
			}
			writer.WriteLine(">");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_gray_ul'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_gray_u'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_gray_ur'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_gray_l'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_gray_c' align='" + _innerAlign + "'>");
		}
		#endregion

		#region RenderFooter
		private void RenderFooter_Window (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

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

		private void RenderFooter_Blue (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("		</td>");
			writer.WriteLine("		<td class='panel_blue_r'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_blue_bl'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_blue_b'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_blue_br'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("</table>");
			writer.WriteLine("");
		}

		private void RenderFooter_Gray (HtmlTextWriter writer)
		{
			string spacer = "<img src='" + Page.ResolveClientUrl(ImagesDir + "spacer.gif") + "'/>";

			writer.WriteLine("		</td>");
			writer.WriteLine("		<td class='panel_gray_r'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("	<tr>");
			writer.WriteLine("		<td class='panel_gray_bl'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_gray_b'>" + spacer + "</td>");
			writer.WriteLine("		<td class='panel_gray_br'>" + spacer + "</td>");
			writer.WriteLine("	</tr>");
			writer.WriteLine("</table>");
			writer.WriteLine("");
		}
		#endregion
	}
}
