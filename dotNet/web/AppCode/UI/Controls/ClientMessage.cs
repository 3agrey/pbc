using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIM.PBC.Web.UI.Controls
{
	public class ClientMessage : Control
	{
		private static string _imagesDir;

		private string _singleMessage;
		private string _header;
		private List<string> _messages;
		private ClientMessageTypes _type;
		private bool _showSingleMessage;
		private bool _showListMessages;

		static ClientMessage ()
		{
			_imagesDir = "";
		}

		public static string ImagesDir
		{
			get { return _imagesDir; }
			set { _imagesDir = value; }
		}

		public bool IsRenderNewLine
		{
			get { return ViewState["IsRenderNewLine"] == null ? false : (bool) ViewState["IsRenderNewLine"]; }
			set { ViewState["IsRenderNewLine"] = value; }
		}

		public Unit Width
		{
			get { return ViewState["Width"] == null ? Unit.Empty : (Unit) ViewState["Width"]; }
			set { ViewState["Width"] = value; }
		}

		public List<string> Messages
		{
			get { return _messages; }
		}

		public ClientMessage ()
		{
			_singleMessage = "";
			_header = "";
			_messages = new List<string>();
			_type = ClientMessageTypes.Info;
			_showSingleMessage = false;
			_showListMessages = false;

			// design defaults
			IsRenderNewLine = false;
		}

		public void ShowSingleMessage (string message, ClientMessageTypes type)
		{
			_singleMessage = message;
			_type = type;
			_showSingleMessage = true;
		}

		public void ShowListMessages (string header, ClientMessageTypes type)
		{
			_header = header;
			_type = type;
			_showListMessages = true;
		}

		private string GetImageName ()
		{
			string result = "";
			switch (_type)
			{
				case ClientMessageTypes.Info:
					return "Info.png";
				case ClientMessageTypes.Warning:
					return "Warning.png";
				case ClientMessageTypes.Error:
					return "Error.png";
			}
			return result;
		}

		private string GetCellTextCssClass ()
		{
			string result = "";
			switch (_type)
			{
				case ClientMessageTypes.Info:
					return "clientMessageCellTextInfo";
				case ClientMessageTypes.Warning:
					return "clientMessageCellTextWarning";
				case ClientMessageTypes.Error:
					return "clientMessageCellTextError";
			}
			return result;
		}

		protected void RenderBeginTag (HtmlTextWriter writer)
		{
			string clientImagesDir = Page.ResolveClientUrl(_imagesDir);

			StringBuilder sbStyle = new StringBuilder();
			if (!Width.IsEmpty)
			{
				sbStyle.Append("width: " + Width.ToString() + ";");
			}

			writer.Write("<div id=\"" + ClientID + "\" class=\"clientMessageDiv\"");
			if (sbStyle.Length > 0)
			{
				writer.Write(" style=\"" + sbStyle.ToString() + "\"");
			}
			writer.Write(">");
			writer.Write("<table class=\"clientMessageTable\" cellpadding=\"5\" cellspacing=\"0\" width=\"100%\">");
			writer.Write("<tr>");
			writer.Write("<td class=\"clientMessageCellImage\">");

			// Internet Explorer PNG bug
			// writer.Write("<div style=\"filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true, sizingMethod=crop src='" + clientImagesDir + GetImageName() + "'); height:32px; width:32px; \"></div>");

			// Other normal browsers
			writer.Write("<img src=\"" + clientImagesDir + GetImageName() + "\" border=\"0\" class=\"clientMessageImage\">");

			writer.Write("</td>");
			writer.Write("<td class=\"" + GetCellTextCssClass() + "\">");
		}

		protected void RenderEndTag (HtmlTextWriter writer)
		{
			writer.Write("</td>");
			writer.Write("</tr>");
			writer.Write("</table>");
			writer.Write("</div>");
		}

		protected void RenderNewLine (HtmlTextWriter writer)
		{
			writer.Write("<br/>");
		}

		protected override void Render (HtmlTextWriter writer)
		{
			if (_showSingleMessage)
			{
				RenderBeginTag(writer);

				writer.Write(_singleMessage);

				RenderEndTag(writer);

				if (IsRenderNewLine)
				{
					RenderNewLine(writer);
				}
			}
			else if (_showListMessages)
			{
				RenderBeginTag(writer);

				writer.Write(_header);
				writer.Write("<ul>");
				foreach (string message in _messages)
				{
					writer.Write("<li>");
					writer.Write(message);
					writer.Write("</li>");
				}
				writer.Write("</ul>");

				RenderEndTag(writer);

				if (IsRenderNewLine)
				{
					RenderNewLine(writer);
				}
			}
		}
	}
}