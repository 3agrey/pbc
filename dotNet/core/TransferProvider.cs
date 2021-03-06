using System;
using System.Collections.ObjectModel;
using AIM.PBC.Core.BusinessObjects;
using AIM.PBC.Core.Exceptions;
using AIM.PBC.Core.Utilities;
using NHibernate;
using NHibernate.Expression;

namespace AIM.PBC.Core
{
	public class TransferProvider : NhibernateDatabaseProvider
	{
		/// <summary>
		/// Returns Transfer
		/// </summary>
		public static Transfer Get (int id, TransferTypes type)
		{
			Type transferType = TransferFactory.GetTransferType(type);
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				return (Transfer)session.Load(transferType, id);
			}
		}
		
		/// <summary>
		/// Returns list of transfers assigned to specified user
		/// </summary>
		public static ReadOnlyCollection<Transfer> GetListByUser(int userId)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				User owner = session.Load<User>(userId);
				if (owner == null)
				{
					throw new ConsistencyException(String.Format("Unable to get transfer list. UserId supplied = {0}", userId));
				}
				
				ICriteria cr = session.CreateCriteria(typeof(Transfer)).
					Add(
						Expression.Or(
										Expression.InG("SourceAccount", owner.Accounts), 
										Expression.InG("TargetAccount", owner.Accounts)));
				
				return CollectionUtility.ToReadOnly(cr.List<Transfer>());
			}
		}

		/// <summary>
		/// Returns list of transfers assigned to specified account
		/// </summary>
		public static ReadOnlyCollection<Transfer> GetListByAccount(int accountId)
		{
			using (ISession session = Settings.SessionFactory.OpenSession())
			{
				ICriteria cr = session.CreateCriteria(typeof(Transfer)).
					Add(
						Expression.Or(
										Expression.Eq("SourceAccountId", accountId), 
										Expression.Eq("TargetAccountId", accountId)));
				return CollectionUtility.ToReadOnly(cr.List<Transfer>());
			}	
		}
	}
}
