using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aim.Web.Controls.Panels
{
	internal abstract class PanelBase
	{
		private readonly Panel _panel;

		public string Title
		{
			get { return _panel.Title; }
		}
		public Unit Width
		{
			get { return _panel.Width; }
		}
		public int CellPadding
		{
			get { return _panel.CellPadding; }
		}
		public int CellSpacing
		{
			get { return _panel.CellSpacing; }
		}
		public string InnerAlign
		{
			get { return _panel.InnerAlign; }
		}
		public Page Page
		{
			get { return _panel.Page; }
		}


		protected PanelBase(Panel panel)
		{
			if (panel == null) throw new ArgumentNullException("panel");

			_panel = panel;
		}

		public abstract void RenderHeader(HtmlTextWriter writer);
		public abstract void RenderFooter(HtmlTextWriter writer);
	}
}