using System.Data;
using System.Data.SqlClient;

namespace AIM.PBC.Core
{
	public class AccountProvider : DatabaseProvider
	{
		/// <summary>
		/// Database methods namespace
		/// </summary>
		private const string Namespace = "Accounts";

		/// <summary>
		/// Returns account statistic
		/// </summary>
		public static DataTable GetStatistic (int userId)
		{
			const string procedureName = Namespace + "_" + "GetStatistic";
			DataTable result = ExecuteProcedureTable(procedureName,
				new SqlParameter("@UserId", userId)
			);
			return result;
		}

		/// <summary>
		/// Returns Account
		/// </summary>
		public static Account Get (int id)
		{
			const string procedureName = Namespace + "_" + "Get";
			Account entity = null;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@Id", id)
				);
				if (reader.Read())
				{
					entity = new Account();
					entity.LoadFromReader(reader);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return entity;
		}

		/// <summary>
		/// Returns account list
		/// </summary>
		public static AccountList GetList (int userId)
		{
			const string procedureName = Namespace + "_" + "GetList";
			AccountList list;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@UserId", userId)
				);
				list = new AccountList(reader);
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return list;
		}

		/// <summary>
		/// Add new account
		/// </summary>
		public static int Add (Account entity)
		{
			const string procedureName = Namespace + "_" + "Add";
			int id = (int) ExecuteProcedureScalar(procedureName,
				new SqlParameter("@UserId", entity.UserId.Value),
				new SqlParameter("@Name", entity.Name.Value),
				new SqlParameter("@BeginningBalance", entity.BeginningBalance.Value),
				new SqlParameter("@BeginningBalanceDate", entity.BeginningBalanceDate.Value)
			);
			return id;
		}

		/// <summary>
		/// Updates account
		/// </summary>
		public static void Update (Account entity)
		{
			const string procedureName = Namespace + "_" + "Update";
			ExecuteProcedureNonQuery(procedureName,
				new SqlParameter("@Id", entity.Id.Value),
				new SqlParameter("@Name", entity.Name.Value),
				new SqlParameter("@BeginningBalance", entity.BeginningBalance.Value),
				new SqlParameter("@BeginningBalanceDate", entity.BeginningBalanceDate.Value)
			);
		}
	}
}
