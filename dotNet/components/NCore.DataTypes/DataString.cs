using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataString : IDataType
	{
		private String _value;
		private bool _isNotNull;

		public String Value
		{
			get
			{
				if (_isNotNull)
				{
					return _value;
				}
				else
				{
					throw new NullReferenceException("Object is null");
				}
			}
			set
			{
				_value = value;
				_isNotNull = true;
			}
		}
		
		public object NullableValue
		{
			get
			{
				if (_isNotNull)
				{
					return _value;	
				}
				else
				{
					return DBNull.Value;
				}
			}
		}

		public bool IsNull
		{
			get
			{
				return !_isNotNull;
			}
		}

		public DataString (String value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataString (object value)
		{
			if (value is String)
			{
				_value = (String) value;
				_isNotNull = true;
			}
			else
			{
				_value = String.Empty;
				_isNotNull = false;
			}
		}

		public static implicit operator DataString (String value)
		{
			return new DataString(value);
		}

		public static implicit operator String (DataString value)
		{
			return value.Value;
		}

		public override string ToString ()
		{
			return Value.ToString();
		}

		public override int GetHashCode ()
		{
			return Value.GetHashCode();
		}
	}
}