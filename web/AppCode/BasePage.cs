namespace AIM.PBC.Web
{
	public class BasePage : System.Web.UI.Page
	{
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
	}
}