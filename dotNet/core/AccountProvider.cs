using System;
using System.Collections.ObjectModel;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Core.Exceptions;
using AIM.PBC.Core.Utilities;
using NHibernate;

namespace AIM.PBC.Core
{
	public class AccountProvider : NhibernateDatabaseProvider
	{
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
	}
}