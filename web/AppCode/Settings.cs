using System.Configuration;

namespace AIM.PBC.Web
{
	public static class Settings
	{
		public static string ConnectionString
		{
			get { return ConfigurationManager.ConnectionStrings["default"].ConnectionString; }
		}

		public static bool IsDebug
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["IsDebug"]); }
		}

		public static string ApplicationTitle
		{
			get { return ConfigurationManager.AppSettings["ApplicationTitle"]; }
		}
	}
}