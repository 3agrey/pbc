using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataBoolean : IDataType
	{
		private Boolean _value;
		private bool _isNotNull;

		public Boolean Value
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

		public DataBoolean (Boolean value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataBoolean (object value)
		{
			if (value is Boolean)
			{
				_value = (Boolean) value;
				_isNotNull = true;
			}
			else
			{
				_value = false;
				_isNotNull = false;
			}
		}

		public static implicit operator DataBoolean (Boolean value)
		{
			return new DataBoolean(value);
		}

		public static implicit operator DataBoolean (DBNull value)
		{
			return new DataBoolean(value);
		}

		public static implicit operator Boolean (DataBoolean value)
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