using System;

namespace AIM.PBC.Web
{
	public class QueryParamInvalidException : ApplicationException
	{
		private const string messageFormat = "Query string parameter '{0}' has invalid value.";

		public QueryParamInvalidException(string parameterName)
			: base(string.Format(messageFormat, parameterName))
		{
		}

		public QueryParamInvalidException(string parameterName, Exception innerException)
			: base(string.Format(messageFormat, parameterName), innerException)
		{
		}
	}
}