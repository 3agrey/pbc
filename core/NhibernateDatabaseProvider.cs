using System;
using AIM.PBC.Core.BusinessObjects;
using NHibernate;

namespace AIM.PBC.Core
{
	public abstract class NhibernateDatabaseProvider : DatabaseProvider
	{
		/// <summary>
		/// Returns entity by key.
		/// </summary>
		/// <typeparam name="T">PbcObject type</typeparam>
		/// <param name="key">Key of needed PbcObject</param>
		/// <returns>PbcObject</returns>
		public static T Get<T>(int key) where T : PbcObject
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				return session.Load<T>(key);
			}
		}

		/// <summary>
		/// Saves given PbcObject.
		/// </summary>
		/// <typeparam name="T">PbcObject type</typeparam>
		/// <param name="entity">PbcObject to save</param>
		/// <returns>PbcObject key</returns>
		public static int Add<T>(T entity) where T : PbcObject
		{
			if (entity == null) throw new ArgumentNullException("entity");

			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				ITransaction transaction = session.BeginTransaction();
				session.Save(entity);
				transaction.Commit();
				//tell somehow to refresh object
				session.Refresh(entity);
				return entity.Id;
			}
		}

		/// <summary>
		/// Updates given PbcObject.
		/// </summary>
		/// <typeparam name="T">PbcObject type</typeparam>
		/// <param name="entity">PbcObject to save</param>
		/// <returns>PbcObject key</returns>
		public static void Update<T>(T entity) where T : PbcObject
		{
			if (entity == null) throw new ArgumentNullException("entity");

			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				ITransaction transaction = session.BeginTransaction();
				session.Flush();
				transaction.Commit();
			}
		}
	}
}