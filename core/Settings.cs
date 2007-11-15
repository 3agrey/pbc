namespace AIM.PBC.Core
{
	public static class Settings
	{
		private static string _connectionString;
		private static bool _isDebug;

		/// <summary>
		/// Static constructor
		/// Inintializes default settings
		/// </summary>
		static Settings ()
		{
			_connectionString = "";
			_isDebug = false;
		}

		/// <summary>
		/// Database connection string
		/// </summary>
		public static string ConnectionString
		{
			get { return _connectionString; }
			set { _connectionString = value; }
		}

		/// <summary>
		/// Debug Mode Flag
		/// </summary>
		public static bool IsDebug
		{
			get { return _isDebug; }
			set { _isDebug = value; }
		}
	}
}
