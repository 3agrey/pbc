using System;

namespace AIM.PBC.Web
{
	public abstract class BasePage : System.Web.UI.Page
	{
		private string _pageTittle = null;

		protected string GetGlobalString (string resourceKey)
		{
			const string className = "Global";
			string result = (string) GetGlobalResourceObject(className, resourceKey);
			return result;
		}
			
		protected string GetLocalString (string resourceKey)
		{
			string result = (string) GetLocalResourceObject(resourceKey);
			return result;
		}

		public virtual string PageTitle
		{
			get
			{
				if (String.IsNullOrEmpty(_pageTittle))
				{
					string res = GetLocalString("Title");
					if (String.IsNullOrEmpty(res))
					{
						_pageTittle = "Untitled";
					}
					_pageTittle = res;
				}
				return _pageTittle;
			}
		}

		protected override void OnPreInit(EventArgs e)
		{
			Title = String.Format("{0} : {1}", Settings.ApplicationTitle, PageTitle);
			Theme = "Default";
			base.OnPreInit(e);
		}
	}
}