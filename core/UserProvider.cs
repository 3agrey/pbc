using System;
using AIM.PBC.Core.BusinessObjects;
using NHibernate;
using NHibernate.Expression;

namespace AIM.PBC.Core
{
	public class UserProvider : NhibernateDatabaseProvider
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
	}
}