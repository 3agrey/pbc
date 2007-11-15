using System.Data.SqlClient;
using AIM.NCore.DataTypes;

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
			const string procedureName = Namespace + "_" + "Get";
			User entity = null;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@Id", id)
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
		/// Creates new user
		/// </summary>
		public static int Add (User entity)
		{
			const string procedureName = Namespace + "_" + "Add";
			int id = (int) ExecuteProcedureScalar(procedureName, 
				new SqlParameter("@Username", entity.Username.Value),
				new SqlParameter("@Password", entity.Password.Value),
				new SqlParameter("@Firstname", entity.Firstname.NullableValue),
				new SqlParameter("@Lastname", entity.Lastname.NullableValue),
				new SqlParameter("@Email", entity.Email.NullableValue));
			return id;
		}
	}
}
