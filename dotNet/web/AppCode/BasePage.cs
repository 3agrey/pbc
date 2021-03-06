using System;
using System.Resources;
using System.Web.UI;

namespace AIM.PBC.Web.AppCode
{
	public abstract class BasePage : Page
	{
		private string _pageTittle = null;

		protected string GetGlobalString (string resourceKey)
		{
			const string className = "Global";
			try
			{
				string result = (string)GetGlobalResourceObject(className, resourceKey);
				return result;
			}
			catch (MissingManifestResourceException)
			{
				return null;
			}
		}
			
		protected string GetLocalString (string resourceKey)
		{
			try
			{
				string result = (string)GetLocalResourceObject(resourceKey);
				return result;
			}
			catch (InvalidOperationException)
			{
				return null;
			}
			catch (MissingManifestResourceException)
			{
				return null;
			}
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
			base.OnPreInit(e);
			Theme = "Default";
		}
	}
}