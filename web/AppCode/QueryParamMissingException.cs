using System;

namespace AIM.PBC.Web
{
	public class QueryParamMissingException : ApplicationException
	{
		private const string messageFormat = "Required query string parameter '{0}' is missing or has invalid value.";

		public QueryParamMissingException(string parameterName)
			: base(string.Format(messageFormat, parameterName))
		{
		}

		public QueryParamMissingException(string parameterName, Exception innerException)
			: base(string.Format(messageFormat, parameterName), innerException)
		{
		}
	}
}