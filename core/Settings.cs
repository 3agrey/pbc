using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Xml;
using AIM.PBC.Core.Exceptions;
using NHibernate;
using Configuration=NHibernate.Cfg.Configuration;

namespace AIM.PBC.Core
{
	public static class Settings
	{
		private const string NhibernateSectionName = "nhibernate";

		private static string _connectionString;
		private static bool _isDebug;
		private static ISessionFactory _sessionFactory;

		/// <summary>
		/// Static constructor
		/// Inintializes default settings
		/// </summary>
		static Settings ()
		{
			_connectionString = "";
			_isDebug = false;

//			Configuration cfg = new Configuration();
//			cfg.AddAssembly(Assembly.GetCallingAssembly());
//			cfg.AddAssembly(Assembly.GetExecutingAssembly());
//			_sessionFactory = cfg.BuildSessionFactory();
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

		/// <summary>
		/// Nhibernate SessionFactory.
		/// </summary>
		public static ISessionFactory SessionFactory
		{
			get
			{
				Configuration cfg = new Configuration();
				IDictionary section = ConfigurationManager.GetSection(NhibernateSectionName) as IDictionary;
				if (section == null)
				{
					throw new NHibernateSectionLoadException();
				}
				cfg.AddProperties(section);
				cfg.AddAssembly(typeof(Settings).Assembly);
				
				_sessionFactory = cfg.BuildSessionFactory();
				return _sessionFactory;
			}
		}
	}
}
