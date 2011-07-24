using System.Web;
using System.Web.Security;
using AIM.PBC.Core;
using AIM.PBC.Core.BusinessObjects;

namespace AIM.PBC.Web
{
	public static class SessionManager
	{
		private const string SessionKeysPrefix = "SessionManager.";

		/// <summary>
		/// Returns entity of current user
		/// </summary>
		public static User CurrentUser
		{
			get
			{
				User entity = null;
				
				if (HttpContext.Current.User.Identity.IsAuthenticated)
				{
					entity = (User) HttpContext.Current.Session[SessionKeysPrefix + "CurrentUser"];
					if (entity == null)
					{
						int id = int.Parse(HttpContext.Current.User.Identity.Name);
						entity = UserProvider.Get<User>(id);
						if (entity != null)
						{
							// restore session
							HttpContext.Current.Session[SessionKeysPrefix + "CurrentUser"] = entity;
						}
					}
				}
				return entity;
			}
			set
			{
				HttpContext.Current.Session[SessionKeysPrefix + "CurrentUser"] = value;
			}
		}

		/// <summary>
		/// Checks is internet user is authenticated
		/// </summary>
		public static bool IsAuthenticated
		{
			get
			{
				return (CurrentUser != null); 
			}
		}

		/// <summary>
		/// Checks user credentials and signs in user if credentials are valid
		/// </summary>
		public static bool Login (string username, string password, bool persistent, bool redirectIfSuccesfully)
		{
			bool result = false;
			User entity = UserProvider.GetByCredentials(username, password);
			if (entity != null)
			{
				HttpContext.Current.Session.Clear();
				string authUserKey = entity.Id.ToString();
				if (redirectIfSuccesfully)
				{
					string returnUrl = HttpContext.Current.Request.QueryString["ReturnUrl"];
					if (returnUrl != null && returnUrl.Length > 0)
					{
						FormsAuthentication.RedirectFromLoginPage(authUserKey, persistent);
					}
					else
					{
						FormsAuthentication.SetAuthCookie(authUserKey, persistent);
						HttpContext.Current.Response.Redirect("Default.aspx");
					}
				}
				else
				{
					FormsAuthentication.SetAuthCookie(authUserKey, persistent);
				}
				result = true;
			}
			return result;
		}

		/// <summary>
		/// Signs out user
		/// </summary>
		public static void Logout ()
		{
			FormsAuthentication.SignOut();
			HttpContext.Current.Session.Clear();
		}

		/// <summary>
		/// Redirects to login page
		/// </summary>
		public static void RedirectToPublicHome ()
		{
			HttpContext.Current.Response.Redirect("~/Default.aspx");
		}
	}
}