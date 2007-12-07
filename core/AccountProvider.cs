using System;
using System.Data;
using System.Data.SqlClient;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Core.Exceptions;
using Iesi.Collections.Generic;
using NHibernate;

namespace AIM.PBC.Core
{
	public class AccountProvider : DatabaseProvider
	{
		/// <summary>
		/// Database methods namespace
		/// </summary>
		private const string Namespace = "Accounts";

		/// <summary>
		/// Returns account statistic
		/// </summary>
		public static DataTable GetStatistic (int userId)
		{
			const string procedureName = Namespace + "_" + "GetStatistic";
			DataTable result = ExecuteProcedureTable(procedureName,
				new SqlParameter("@UserId", userId)
			);
			return result;
		}

		/// <summary>
		/// Returns Account
		/// </summary>
		public static Account Get (int id)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				return session.Load<Account>(id);
			}
		}

		/// <summary>
		/// Returns account list
		/// </summary>
		public static ISet<Account> GetList (int userId)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				User usr = session.Load<User>(userId);
				if (usr == null)
				{
					throw new ConsistencyException(String.Format("Unable to get account list. UserId supplied = {0}", userId));
				}
				return usr.Accounts;
			}
		}

		/// <summary>
		/// Add new account
		/// </summary>
		public static int Add (Account entity)
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
		public static void Update (Account entity)
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
