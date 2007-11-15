using System.Collections;

namespace AIM.PBC.Core
{
	public class AccountHashList : Hashtable
	{
		public void Add (Account item)
		{
			int key = item.Id.Value;
			Add(key, item);
		}

		public void AddList (AccountList sourceList)
		{
			foreach (Account account in sourceList)
			{
				Add(account);
			}
		}

		public Account this[int accountId]
		{
			get
			{
				return (Account) base[accountId];
			}
		}
	}
}
