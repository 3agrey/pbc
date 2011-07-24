using System.Collections.Generic;

namespace AIM.PBC.Web.UI.Controls
{
	public class PivotGridFieldInfoCollection : List<PivotGridFieldInfo>
	{
		public void Add (string name)
		{
			Add(new PivotGridFieldInfo(name));
		}
	}
}