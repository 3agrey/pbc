using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aim.Web.Controls;
using Aim.Web.Controls.Panels;
using Aim.Web.Controls.Utilities;
using Panel=Aim.Web.Controls.Panel;

#region Assembly Resource Attribute

[assembly: WebResource(Panel.PANEL_STYLE_NAMESPACE, ContentTypes.TEXT_CSS)]

#endregion 

namespace Aim.Web.Controls
{
	public class Panel : Control
	{
		public const string PANEL_STYLE_NAMESPACE = "Aim.Web.Controls.Styles.Panel.css";
		private const string PANEL_CSS_SCRIPT_KEY = "Panel_css";

		public static string ImagesDir;

		private string _title = "Untitled";
		private Unit _width = Unit.Empty;
		private int _cellPadding = 0;
		private int _cellSpacing = 0;
		private PanelMode _mode = PanelMode.Window;
		private string _innerAlign = "center";

		private PanelBase _renderer;

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
			set
			{
				if (_mode != value)
				{
					_renderer = null;
					_mode = value;
				}
			}
		}

		public string InnerAlign
		{
			get { return _innerAlign; }
			set { _innerAlign = value; }
		}

		private PanelBase Renderer
		{
			get
			{
				if (_renderer == null)
				{
					_renderer = PanelFactory.CreateRenderer(this);
				}
				return _renderer;
			}
		}

		private ClientScriptManager ClientScript
		{
			get { return Page.ClientScript; }
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (!ClientScript.IsClientScriptBlockRegistered(GetType(), PANEL_CSS_SCRIPT_KEY))
			{
				ClientScript.RegisterClientScriptBlock(GetType(), PANEL_CSS_SCRIPT_KEY, String.Empty);
				string cssUrl = ClientScript.GetWebResourceUrl(GetType(), PANEL_STYLE_NAMESPACE);
				WebUtility.AddStyleSheet(Page, cssUrl);
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			Renderer.RenderHeader(writer);
			base.Render(writer);
			Renderer.RenderFooter(writer);
		}

		#region ViewState

		protected override void LoadViewState(object savedState)
		{
			base.LoadViewState(savedState);
			if (EnableViewState)
			{
				_title = (string) ViewState["_title"];
				_width = (Unit) ViewState["_width"];
				_cellPadding = (int) ViewState["_cellPadding"];
				_cellSpacing = (int) ViewState["_cellSpacing"];
				_mode = (PanelMode) ViewState["_mode"];
				_innerAlign = (string) ViewState["_innerAlign"];
			}
		}

		protected override object SaveViewState()
		{
			if (EnableViewState)
			{
				ViewState["_title"] = _title;
				ViewState["_width"] = _width;
				ViewState["_cellPadding"] = _cellPadding;
				ViewState["_cellSpacing"] = _cellSpacing;
				ViewState["_mode"] = _mode;
				ViewState["_innerAlign"] = _innerAlign;
			}
			return base.SaveViewState();
		}

		#endregion
	}
}