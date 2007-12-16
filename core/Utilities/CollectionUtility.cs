using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AIM.PBC.Core.Utilities
{
	public static class CollectionUtility
	{
		public static ReadOnlyCollection<T> ToReadOnly<T>(IEnumerable<T> source)
		{
			if (source == null)
			{
				return null;
			}
			if (source is List<T>)
			{
				List<T> res = (List<T>)source;
				return res.AsReadOnly();
			}
			else
			{
				List<T> res = new List<T>(source);
				return res.AsReadOnly();
			}
		}
	}
}