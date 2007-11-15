using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AIM.PBC.Core
{
	[Serializable]
	public class TransferList : List<Transfer>
	{
		public TransferList ()
		{
		}
		
		public TransferList (SqlDataReader reader)
		{
			while (reader.Read())
			{
				Transfer entity = new Transfer();
				entity.LoadFromReader(reader);
				Add(entity);
			}
		}
	}
}
