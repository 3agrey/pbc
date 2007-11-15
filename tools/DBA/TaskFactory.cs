using System;

namespace AIM.Tools.DBA
{
	public class TaskFactory
	{
		public static Task ResolveTask (string[] args)
		{
			Task task = null;

			if (args.Length > 0)
			{
				string commandName = args[0];

				switch (commandName)
				{
					case CommandNames.Execute:
						task = new ExecuteScriptTask(args);
						break;
					case CommandNames.SearchAndExecute:
						task = new SearchAndExecuteScriptTask(args);
						break;
					case CommandNames.ShowHelp:
						task = new ShowHelpTask();
						break;
				}
			}

			if (task == null)
			{
				task = new ShowHelpTask();
			}

			task.RootDir = Environment.CurrentDirectory;

			return task;
		}
	}
}
