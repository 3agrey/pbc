using System.Web.UI;

namespace AIM.PBC.Web.UI.Controls
{
	public class MenuItem : Control
	{
		private string _text;
		private string _url;

		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}
		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}
	}
}
