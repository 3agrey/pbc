using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace AIM.Tools.DBA
{
	public class ExecuteScriptTask : Task
	{
		private string _connectionStringName;
		private string _inputfilePath;
		private DatabaseProvider _provider;

		public ExecuteScriptTask (string connectionStringName, string inputfilePath)
			: base()
		{
			_connectionStringName = connectionStringName;
			_inputfilePath = inputfilePath;
			_provider = null;
		}

		public ExecuteScriptTask (string[] args)
			: this(args[1], args[2])
		{
		}

		public override void Execute ()
		{
			ValidateParameters();

			_provider = new DatabaseProvider(Helpers.GetConnectionString(_connectionStringName));

			string inputQuery = File.ReadAllText(Helpers.GetRootedInputfilePath(_rootDir, _inputfilePath));

			using (SqlConnection connection = _provider.Connection)
			{
				connection.Open();
				string[] lines = inputQuery.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
				StringBuilder sbQuery = new StringBuilder();
				foreach (string line in lines)
				{
					if (IsGoSeparator(line))
					{
						string currentQuery = sbQuery.ToString();
						sbQuery = new StringBuilder();
						ExecuteQuery(connection, currentQuery);
					}
					else
					{
						sbQuery.AppendLine(line);
					}
				}
				if (sbQuery.Length > 0)
				{
					string currentQuery = sbQuery.ToString();
					ExecuteQuery(connection, currentQuery);
				}
				connection.Close();
			}
		}

		private void ExecuteQuery (SqlConnection connection, string query)
		{
			try
			{
				_provider.ExecuteQueryVoid(connection, query);
			}
			catch (SqlException ex)
			{
				Console.WriteLine(string.Format("Server: Msg {0}, Level {1}, State {2}, Line {3}", ex.Number, ex.Class, ex.State, ex.LineNumber));
				Console.WriteLine(ex.Message);
				Console.WriteLine("Current Query:");
				PrintQueryWithLineNumbers(query);
				throw new QueryAbortException(_inputfilePath);
			}
		}

		private void PrintQueryWithLineNumbers (string query)
		{
			string[] lines = query.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < lines.Length; i++)
			{
				Console.Write((i + 1).ToString() + "> ");
				Console.WriteLine(lines[i]);
			}
		}

		private static bool IsGoSeparator (string line)
		{
			line = line.Replace('\t', ' ');
			line = line.Trim().ToLower();

			return (line == "go");
		}

		private void ValidateParameters ()
		{
			ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[_connectionStringName];
			if (connectionStringSettings == null)
			{
				throw new ConnectionStringNotFoundException(_connectionStringName);
			}

			string rootedPath = Helpers.GetRootedInputfilePath(_rootDir, _inputfilePath);
			if (!File.Exists(rootedPath))
			{
				throw new FileNotFoundException("SQL script file was not found", _inputfilePath);
			}
		}
	}
}