using System.Data;
using System.Data.SqlClient;

namespace AIM.PBC.Core
{
	public class ReportProvider : DatabaseProvider
	{
		/// <summary>
		/// Database methods namespace
		/// </summary>
		private const string Namespace = "Reports";

		public static DataTable GetReportByTransactions (int userId)
		{
			const string procedureName = Namespace + "_" + "GetReportByTransactions";
			DataTable result = ExecuteProcedureTable(procedureName,
				new SqlParameter("@UserId", userId)
			);
			return result;
		}

		public static DataTable GetReportByAccounts (int userId)
		{
			const string procedureName = Namespace + "_" + "GetReportByAccounts";
			DataTable result = ExecuteProcedureTable(procedureName,
				new SqlParameter("@UserId", userId)
			);
			return result;
		}
	}
}
