using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataDecimal : IDataType
	{
		private Decimal _value;
		private bool _isNotNull;

		public Decimal Value
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

		public DataDecimal (Decimal value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataDecimal (object value)
		{
			if (value is Decimal)
			{
				_value = (Decimal) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataDecimal (Decimal value)
		{
			return new DataDecimal(value);
		}

		public static implicit operator DataDecimal (DBNull value)
		{
			return new DataDecimal(value);
		}

		public static implicit operator Decimal (DataDecimal value)
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