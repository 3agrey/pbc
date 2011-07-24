using System;
using System.Collections.Generic;
using System.Text;

namespace AIM.NCore.DataTypes
{
	public interface IDataType
	{
		bool IsNull { get; }
	}
}