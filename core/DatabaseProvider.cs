using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	/// <summary>
	/// Allows objects to execute database methods
	/// </summary>
	public class DatabaseProvider
	{
		#region Connection
		/// <summary>
		/// Returns new instance of connection object
		/// </summary>
		private static SqlConnection Connection
		{
			get
			{
				return new SqlConnection(Settings.ConnectionString);
			}
		}
		#endregion

		#region GetArrayParameters
		/// <summary>
		/// Converts instance of period list to parameter
		/// </summary>
		public static void GetArrayParameters (ArrayList list, out string outArray, out byte outItemLen)
		{
			outArray = null;
			outItemLen = 0;

			if (list == null || list.Count == 0)
			{
				return;
			}

			byte itemLen = 0;
			foreach (object item in list)
			{
				byte currLen = (byte) item.ToString().Length;
				if (currLen > itemLen) itemLen = currLen;
			}

			StringBuilder sbArray = new StringBuilder();
			foreach (object item in list)
			{
				string currValue = item.ToString().PadLeft(itemLen + 1, ' ');
				sbArray.Append(currValue);
			}

			outArray = sbArray.ToString();
			outItemLen = itemLen;
			outItemLen++;
		}
		#endregion

		#region ExecuteStringXXX
		/// <summary>
		/// Executes non-query string
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameterList">query parameters</param>
		protected static void ExecuteStringNonQuery (string query, SqlParameterList parameterList)
		{
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.Text;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		/// <summary>
		/// Executes non-query query string
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameters">query parameters</param>
		protected static void ExecuteStringNonQuery (string query, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			ExecuteStringNonQuery(query, list);
		}

		/// <summary>
		/// Executes string and returns a scalar result
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameterList">query parameters</param>
		protected static object ExecuteStringScalar (string query, SqlParameterList parameterList)
		{
			object result;
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.Text;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				connection.Open();
				result = command.ExecuteScalar();
				connection.Close();
			}
			return result;
		}

		/// <summary>
		/// Executes string and returns a scalar result
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameters">query parameters</param>
		protected static object ExecuteStringScalar (string query, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteStringScalar(query, list);
		}

		/// <summary>
		/// Executes string and returns a data reader
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameterList">query parameters</param>
		protected static SqlDataReader ExecuteStringReader (string query, SqlParameterList parameterList)
		{
			SqlConnection connection = Connection;
			SqlCommand command = new SqlCommand(query, connection);
			command.CommandTimeout = 0;
			command.CommandType = CommandType.Text;
			if (parameterList != null && parameterList.Count > 0)
			{
				foreach (SqlParameter parameter in parameterList)
				{
					command.Parameters.Add(parameter);
				}
			}
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		/// <summary>
		/// Executes string and returns a data reader
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameters">query parameters</param>
		protected static SqlDataReader ExecuteStringReader (string query, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteStringReader(query, list);
		}

		/// <summary>
		/// Executes string and returns a table
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameterList">query parameters</param>
		protected static DataTable ExecuteStringTable (string query, SqlParameterList parameterList)
		{
			DataTable result = new DataTable();
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.Text;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				connection.Open();
				adapter.Fill(result);
				connection.Close();
			}
			return result;
		}

		/// <summary>
		/// Executes string and returns a table
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameters">query parameters</param>
		protected static DataTable ExecuteStringTable (string query, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteStringTable(query, list);
		}

		/// <summary>
		/// Executes string and returns a set of tables
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameterList">query parameters</param>
		protected static DataSet ExecuteStringMultiTable (string query, SqlParameterList parameterList)
		{
			DataSet result = new DataSet();
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.Text;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				connection.Open();
				adapter.Fill(result);
				connection.Close();
			}
			return result;
		}

		/// <summary>
		/// Executes string and returns a set of tables
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="parameters">query parameters</param>
		protected static DataSet ExecuteStringMultiTable (string query, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteStringMultiTable(query, list);
		}
		#endregion

		#region ExecuteProcedureXXX
		/// <summary>
		/// Executes non-query stored procedure
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameterList">Procedure parameters</param>
		protected static void ExecuteProcedureNonQuery (string procedureName, SqlParameterList parameterList)
		{
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(procedureName, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.StoredProcedure;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		/// <summary>
		/// Executes non-query stored procedure
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameters">Procedure parameters</param>
		protected static void ExecuteProcedureNonQuery (string procedureName, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			ExecuteProcedureNonQuery(procedureName, list);
		}

		/// <summary>
		/// Executes stored procedure and returns a scalar result
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameterList">Procedure parameters</param>
		protected static object ExecuteProcedureScalar (string procedureName, SqlParameterList parameterList)
		{
			object result;
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(procedureName, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.StoredProcedure;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				connection.Open();
				result = command.ExecuteScalar();
				connection.Close();
			}
			return result;
		}

		/// <summary>
		/// Executes stored procedure and returns a scalar result
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameters">Procedure parameters</param>
		protected static object ExecuteProcedureScalar (string procedureName, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteProcedureScalar(procedureName, list);
		}

		/// <summary>
		/// Executes stored procedure and returns a data reader
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameterList">Procedure parameters</param>
		protected static SqlDataReader ExecuteProcedureReader (string procedureName, SqlParameterList parameterList)
		{
			SqlConnection connection = Connection;
			SqlCommand command = new SqlCommand(procedureName, connection);
			command.CommandTimeout = 0;
			command.CommandType = CommandType.StoredProcedure;
			if (parameterList != null && parameterList.Count > 0)
			{
				foreach (SqlParameter parameter in parameterList)
				{
					command.Parameters.Add(parameter);
				}
			}
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		/// <summary>
		/// Executes stored procedure and returns a data reader
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameters">Procedure parameters</param>
		protected static SqlDataReader ExecuteProcedureReader (string procedureName, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteProcedureReader(procedureName, list);
		}

		/// <summary>
		/// Executes stored procedure and returns a table
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameterList">Procedure parameters</param>
		protected static DataTable ExecuteProcedureTable (string procedureName, SqlParameterList parameterList)
		{
			DataTable result = new DataTable();
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(procedureName, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.StoredProcedure;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				connection.Open();
				adapter.Fill(result);
				connection.Close();
			}
			return result;
		}

		/// <summary>
		/// Executes stored procedure and returns a table
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameters">Procedure parameters</param>
		protected static DataTable ExecuteProcedureTable (string procedureName, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteProcedureTable(procedureName, list);
		}

		/// <summary>
		/// Executes stored procedure and returns a set of tables
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameterList">Procedure parameters</param>
		protected static DataSet ExecuteProcedureMultiTable (string procedureName, SqlParameterList parameterList)
		{
			DataSet result = new DataSet();
			using (SqlConnection connection = Connection)
			{
				SqlCommand command = new SqlCommand(procedureName, connection);
				command.CommandTimeout = 0;
				command.CommandType = CommandType.StoredProcedure;
				if (parameterList != null && parameterList.Count > 0)
				{
					foreach (SqlParameter parameter in parameterList)
					{
						command.Parameters.Add(parameter);
					}
				}
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				connection.Open();
				adapter.Fill(result);
				connection.Close();
			}
			return result;
		}

		/// <summary>
		/// Executes stored procedure and returns a set of tables
		/// </summary>
		/// <param name="procedureName">Name of the procedure</param>
		/// <param name="parameters">Procedure parameters</param>
		protected static DataSet ExecuteProcedureMultiTable (string procedureName, params SqlParameter[] parameters)
		{
			SqlParameterList list = new SqlParameterList();
			foreach (SqlParameter parameter in parameters)
			{
				list.Add(parameter);
			}

			return ExecuteProcedureMultiTable(procedureName, list);
		}
		#endregion
	}
}
