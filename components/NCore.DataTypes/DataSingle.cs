using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataSingle : IDataType
	{
		private Single _value;
		private bool _isNotNull;

		public Single Value
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

		public DataSingle (Single value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataSingle (object value)
		{
			if (value is Single)
			{
				_value = (Single) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataSingle (Single value)
		{
			return new DataSingle(value);
		}

		public static implicit operator DataSingle (DBNull value)
		{
			return new DataSingle(value);
		}

		public static implicit operator Single (DataSingle value)
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