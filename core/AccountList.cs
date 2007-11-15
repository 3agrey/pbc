using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AIM.PBC.Core
{
	[Serializable]
	public class AccountList : List<Account>
	{
		public AccountList ()
		{
		}

		public AccountList (SqlDataReader reader)
		{
			while (reader.Read())
			{
				Account entity = new Account();
				entity.LoadFromReader(reader);
				Add(entity);
			}
		}
	}
}
