using System;

namespace AIM.Tools.DBA
{
	public class Program
	{
		public static void Main (string[] args)
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
			}
		}
	}
}
