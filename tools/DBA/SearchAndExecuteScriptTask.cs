using System;
using System.IO;

namespace AIM.Tools.DBA
{
	public class SearchAndExecuteScriptTask : Task
	{
		private string _connectionStringName;
		private string _searchPattern;

		public SearchAndExecuteScriptTask (string connectionStringName, string searchPattern)
			: base()
		{
			_connectionStringName = connectionStringName;
			_searchPattern = searchPattern;
		}

		public SearchAndExecuteScriptTask (string[] args)
			: this(args[1], args[2])
		{
		}

		public override void Execute ()
		{
			string[] files = Helpers.SearchFiles(_rootDir, _searchPattern);
			foreach (string filePath in files)
			{
				ExecuteScriptTask currrentTask = new ExecuteScriptTask(_connectionStringName, filePath);
				currrentTask.RootDir = _rootDir;
				currrentTask.Execute();
			}
		}
	}
}
