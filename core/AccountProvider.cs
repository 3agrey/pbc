using System;
using System.Collections.ObjectModel;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Core.Exceptions;
using AIM.PBC.Core.Utilities;
using NHibernate;

namespace AIM.PBC.Core
{
	public class AccountProvider : DatabaseProvider
	{
		/// <summary>
		/// Returns Account
		/// </summary>
		public static Account Get(int id)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				return session.Load<Account>(id);
			}
		}

		/// <summary>
		/// Returns account list
		/// </summary>
		public static ReadOnlyCollection<Account> GetList(int userId)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				User usr = session.Load<User>(userId);
				if (usr == null)
				{
					throw new ConsistencyException(String.Format("Unable to get account list. UserId supplied = {0}", userId));
				}
				return CollectionUtility.ToReadOnly(usr.Accounts);
			}
		}

		/// <summary>
		/// Add new account
		/// </summary>
		public static int Add(Account entity)
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
		/// Updates account
		/// </summary>
		public static void Update(Account entity)
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