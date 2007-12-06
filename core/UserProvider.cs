using System;
using System.Data.SqlClient;
using AIM.NCore.DataTypes;
using AIM.PBC.Core.BusinessObjects;
using NHibernate;

namespace AIM.PBC.Core
{
	public class UserProvider : DatabaseProvider
	{
		/// <summary>
		/// Database methods namespace
		/// </summary>
		private const string Namespace = "Users";

		/// <summary>
		/// Returns User by credentials
		/// </summary>
		public static User GetByCredentials (string username, string password)
		{
			const string procedureName = Namespace + "_" + "GetByCredentials";
			User entity = null;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@Username", username),
					new SqlParameter("@Password", password)
				);
				if (reader.Read())
				{
					entity = new User(reader);
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
		/// Returns User
		/// </summary>
		public static User Get (int id)
		{
			using (SqlConnection con = new SqlConnection(Settings.ConnectionString))
			{
				using (ISession session = Settings.SessionFactory.OpenSession(con))
				{
					con.Open();
					return session.Load<User>(id);
				}
			}
		}
		
		
		/// <summary>
		/// Creates new user
		/// </summary>
		public static int Add (User entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");

			using(SqlConnection con = new SqlConnection(Settings.ConnectionString))
			{
				using (ISession session = Settings.SessionFactory.OpenSession(con))
				{
					con.Open();
					ITransaction transaction = session.BeginTransaction();
					session.Save(entity);
					transaction.Commit();
					//tell somehow to refresh object
					session.Refresh(entity);
					return entity.Id;
				}
			}
		}
	}
}
