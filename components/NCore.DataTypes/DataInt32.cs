using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataInt32 : IDataType
	{
		private Int32 _value;
		private bool _isNotNull;

		public Int32 Value
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

		public DataInt32 (Int32 value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataInt32 (object value)
		{
			if (value is Int32)
			{
				_value = (Int32) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataInt32 (Int32 value)
		{
			return new DataInt32(value);
		}

		public static implicit operator DataInt32 (DBNull value)
		{
			return new DataInt32(value);
		}

		public static implicit operator Int32 (DataInt32 value)
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