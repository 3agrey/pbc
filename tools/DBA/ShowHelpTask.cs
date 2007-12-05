using System;

namespace AIM.Tools.SqlSE
{
	public class ShowHelpTask : Task
	{
		public override void Execute ()
		{
			Console.WriteLine("Database Project Automation Tool, version 1.1.0.0");
			Console.WriteLine("Copyright (C) AIM Technologies 2006");
			Console.WriteLine("");
			Console.WriteLine("usage: dba <connectionString> <input file>");
			Console.WriteLine("<connectionString> - name of connection string from configuration file");
			Console.WriteLine("<input file> - path to SQL query file to execute");
			Console.WriteLine("");
			Console.WriteLine("example: dba sa database.sql");
			Console.WriteLine("");
		}
	}
}
