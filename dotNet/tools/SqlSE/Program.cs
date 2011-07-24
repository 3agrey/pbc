using System;

namespace AIM.Tools.SqlSE
{
	public class Program
	{
		public static int Main (string[] args)
		{
			Task task = TaskFactory.ResolveTask(args);
			try
			{
				task.Execute();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error occured during execution:");
				Console.WriteLine(ex.Message);
				return -1;
			}
			return 0;
		}
	}
}
