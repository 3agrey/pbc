using System.Web.UI;

namespace AIM.PBC.Web.Private.Controls
{
	public partial class Head : UserControl
	{
		private string _pageTitle = "";
		
		protected string ApplicationTitle
		{
			get
			{
				return Settings.ApplicationTitle;
			}
		}

		public string PageTitle
		{
			get { return _pageTitle; }
			set { _pageTitle = value; }
		}
	}
}