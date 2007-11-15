using System;

namespace AIM.Tools.DBA
{
	public class QueryAbortException : ApplicationException
	{
		private const string _messageFormat = "Query was aborted during error(s) in SQL script '{0}'";

		public QueryAbortException (string path)
			: base(string.Format(_messageFormat, path))
		{
		}
	}
}
