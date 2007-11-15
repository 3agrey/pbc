using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataInt16 : IDataType
	{
		private Int16 _value;
		private bool _isNotNull;

		public Int16 Value
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

		public DataInt16 (Int16 value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataInt16 (object value)
		{
			if (value is Int16)
			{
				_value = (Int16) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataInt16 (Int16 value)
		{
			return new DataInt16(value);
		}

		public static implicit operator DataInt16 (DBNull value)
		{
			return new DataInt16(value);
		}

		public static implicit operator Int16 (DataInt16 value)
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