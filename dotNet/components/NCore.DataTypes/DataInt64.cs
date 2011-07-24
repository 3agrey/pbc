using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataInt64 : IDataType
	{
		private Int64 _value;
		private bool _isNotNull;

		public Int64 Value
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

		public DataInt64 (Int64 value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataInt64 (object value)
		{
			if (value is Int64)
			{
				_value = (Int64) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataInt64 (Int64 value)
		{
			return new DataInt64(value);
		}

		public static implicit operator DataInt64 (DBNull value)
		{
			return new DataInt64(value);
		}

		public static implicit operator Int64 (DataInt64 value)
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