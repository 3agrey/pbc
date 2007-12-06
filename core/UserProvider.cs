using System;
using AIM.PBC.Core.BusinessObjects;
using NHibernate;
using NHibernate.Expression;

namespace AIM.PBC.Core
{
	public class UserProvider : DatabaseProvider
	{
		/// <summary>
		/// Returns User by credentials
		/// </summary>
		public static User GetByCredentials (string username, string password)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				ICriteria cr = session.CreateCriteria(typeof(User))
					.Add(Expression.Eq("Username", username))
					.Add(Expression.Eq("Password", password));
				User res = cr.UniqueResult<User>();
				if (res != null)
				{
					res.LastLogon = DateTime.Now;
					session.Flush();
					return res;
				}
			}
			return null;
		}

		/// <summary>
		/// Returns User
		/// </summary>
		public static User Get (int id)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				return session.Load<User>(id);
			}
		}
		
		/// <summary>
		/// Creates new user
		/// </summary>
		public static int Add (User entity)
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
	}
}