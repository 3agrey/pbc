using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AIM.Tools.DBA
{
	public static class Helpers
	{
		public static string GetRootedInputfilePath (string rootDir, string path)
		{
			string rootedPath;
			if (Path.IsPathRooted(path))
			{
				rootedPath = path;
			}
			else
			{
				rootedPath = Path.Combine(rootDir, path);
			}
			return rootedPath;
		}

		public static string GetConnectionString (string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		}

		public static string[] SearchFiles (string currentDir, string searchPattern)
		{
			List<string> founded = new List<string>();

			string[] searchPatternParts = searchPattern.Split('\\');
			int currentIndex = 0;
			if (searchPatternParts.Length > 0)
			{
				string currentPattern = searchPatternParts[0];
				if (currentPattern.IndexOf('.') == -1)
				{
					// directory
					currentIndex += currentPattern.Length + 1;
					if ((currentPattern.IndexOf('?') != -1) || (currentPattern.IndexOf('*') != -1))
					{
						string innerSearchPattern = searchPattern.Substring(currentIndex, searchPattern.Length - currentIndex);
						string[] directories = Directory.GetDirectories(currentDir);
						foreach (string directory in directories)
						{
							string innerDir = Path.Combine(currentDir, directory + "\\");
							founded.AddRange(SearchFiles(innerDir, innerSearchPattern));
						}
					}
					else
					{
						string innerSearchPattern = searchPattern.Substring(currentIndex, searchPattern.Length - currentIndex);
						string innerDir = Path.Combine(currentDir, currentPattern + "\\");
						founded.AddRange(SearchFiles(innerDir, innerSearchPattern));
					}
				}
				else
				{
					// file
					string[] files = null;
					try
					{
						files = Directory.GetFiles(currentDir, currentPattern);
						founded.AddRange(files);
					}
					catch (DirectoryNotFoundException)
					{
					}
				}
			}

			string[] result = founded.ToArray();
			return result;
		}
	}
}
