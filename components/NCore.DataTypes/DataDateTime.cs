using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataDateTime : IDataType
	{
		private DateTime _value;
		private bool _isNotNull;

		public DateTime Value
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

		public DataDateTime (DateTime value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataDateTime (object value)
		{
			if (value is DateTime)
			{
				_value = (DateTime) value;
				_isNotNull = true;
			}
			else
			{
				_value = DateTime.MinValue;
				_isNotNull = false;
			}
		}

		public static implicit operator DataDateTime (DateTime value)
		{
			return new DataDateTime(value);
		}

		public static implicit operator DataDateTime (DBNull value)
		{
			return new DataDateTime(value);
		}

		public static implicit operator DateTime (DataDateTime value)
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