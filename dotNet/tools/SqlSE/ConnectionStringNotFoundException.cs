using System;

namespace AIM.Tools.SqlSE
{
	public class ConnectionStringNotFoundException : ApplicationException
	{
		private const string messageFormat = "Specified connection string '{0}' is not found. Please check your configuration file.";

		public ConnectionStringNotFoundException (string connectionStringName)
			: base (string.Format(messageFormat, connectionStringName))
		{
		}
	}
}
