using System;

namespace AIM.PBC.Web.UI.Controls
{
	public class PivotGridFieldInfo
	{
		private string _name;
		private string _format;
		private Type _type;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Format
		{
			get { return _format; }
			set { _format = value; }
		}

		public Type Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public PivotGridFieldInfo (string name)
			: this(name, null, null)
		{
		}

		public PivotGridFieldInfo (string name, string format, Type type)
		{
			_name = name;
			_format = format;
			_type = type;
		}
	}
}