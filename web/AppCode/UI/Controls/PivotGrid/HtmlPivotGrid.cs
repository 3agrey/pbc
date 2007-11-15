using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIM.PBC.Web.UI.Controls
{
	public class HtmlPivotGrid : PivotGrid
	{
		#region Members
		private int _cellPadding = 0;
		private int _cellSpacing = 0;
		private Unit _width = Unit.Empty;
		#endregion

		#region Properties
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

		public Unit Width
		{
			get { return _width; }
			set { _width = value; }
		}
		#endregion

		#region Rendering
		protected override void RenderGridBegin (HtmlTextWriter writer)
		{
			writer.Write("<table border='1' rules='all'");
			writer.Write(" cellpadding='" + _cellPadding.ToString() + "'");
			writer.Write(" cellspacing='" + _cellSpacing.ToString() + "'");
			StringBuilder style = new StringBuilder();
			style.Append("border-collapse:collapse;");
			if (!_width.IsEmpty)
			{
				style.Append("width:" + _width.ToString() + ";");
			}
			if (style.Length > 0)
			{
				writer.Write(" style='" + style.ToString() + "'");
			}
			writer.WriteLine(">");
		}

		protected override void RenderGridEnd (HtmlTextWriter writer)
		{
			writer.WriteLine("</table>");
		}

		protected override void RenderRowBegin (HtmlTextWriter writer)
		{
			writer.WriteLine("<tr>");
		}

		protected override void RenderRowEnd (HtmlTextWriter writer)
		{
			writer.WriteLine("</tr>");
		}

		protected override void RenderDummyCell (HtmlTextWriter writer)
		{
			writer.WriteLine("<td rowspan='2'>");
			writer.WriteLine("&nbsp;");
			writer.WriteLine("</td>");
		}

		protected override void RenderAxisCell (HtmlTextWriter writer, PivotGridAxisCellEventArgs args)
		{
			writer.WriteLine("<td>");
			writer.WriteLine(args.Text);
			writer.WriteLine("</td>");
		}

		protected override void RenderDataHeaderCell (HtmlTextWriter writer, string text)
		{
			writer.WriteLine("<td>");
			writer.WriteLine(text);
			writer.WriteLine("</td>");
		}

		protected override void RenderDataCell (HtmlTextWriter writer, PivotGridDataCellEventArgs args)
		{
			writer.WriteLine("<td>");
			writer.WriteLine(args.Text);
			writer.WriteLine("</td>");
		}
		#endregion
	}
}
