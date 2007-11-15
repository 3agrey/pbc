using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataByte : IDataType
	{
		private Byte _value;
		private bool _isNotNull;

		public Byte Value
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

		public DataByte (Byte value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataByte (object value)
		{
			if (value is Byte)
			{
				_value = (Byte) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataByte (Byte value)
		{
			return new DataByte(value);
		}

		public static implicit operator DataByte (DBNull value)
		{
			return new DataByte(value);
		}

		public static implicit operator Byte (DataByte value)
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