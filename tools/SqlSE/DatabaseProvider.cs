using System.Data;
using System.Data.SqlClient;

namespace AIM.Tools.SqlSE
{
	public class DatabaseProvider
	{
		private string _connectionString;

		public DatabaseProvider (string connectionString)
		{
			_connectionString = connectionString;
		}

		public SqlConnection Connection
		{
			get { return new SqlConnection(_connectionString); }
		}

		public void ExecuteQueryVoid (string query)
		{
			using (SqlConnection connection = Connection)
			{
				connection.Open();
				ExecuteQueryVoid(connection, query);
				connection.Close();
			}
		}

		public void ExecuteQueryVoid (SqlConnection connection, string query)
		{
			SqlCommand command = new SqlCommand(query, connection);
			command.CommandType = CommandType.Text;
			command.CommandTimeout = 0;
			command.ExecuteNonQuery();
		}

		public object ExecuteQueryScalar (string query)
		{
			object result = null;
			using (SqlConnection connection = Connection)
			{
				connection.Open();
				result = ExecuteQueryScalar(connection, query);
				connection.Close();
			}
			return result;
		}

		public object ExecuteQueryScalar (SqlConnection connection, string query)
		{
			object result = null;
			SqlCommand command = new SqlCommand(query, connection);
			command.CommandType = CommandType.Text;
			command.CommandTimeout = 0;
			result = command.ExecuteScalar();
			return result;
		}

		public DataTable ExecuteQueryTable (string query)
		{
			DataTable result = new DataTable();
			using (SqlConnection connection = Connection)
			{
				connection.Open();
				result = ExecuteQueryTable(connection, query);
				connection.Close();
			}
			return result;
		}

		public DataTable ExecuteQueryTable (SqlConnection connection, string query)
		{
			DataTable result = new DataTable();
			SqlCommand command = new SqlCommand(query, connection);
			command.CommandType = CommandType.Text;
			command.CommandTimeout = 0;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			adapter.Fill(result);
			return result;
		}

		public SqlDataReader ExecuteQueryReader (string query)
		{
			SqlDataReader reader = null;
			SqlConnection connection = Connection;
			connection.Open();
			reader = ExecuteQueryReader(connection, query);
			return reader;
		}

		public SqlDataReader ExecuteQueryReader (SqlConnection connection, string query)
		{
			SqlDataReader reader = null;
			SqlCommand command = new SqlCommand(query, connection);
			command.CommandType = CommandType.Text;
			command.CommandTimeout = 0;
			reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
	}
}
