using System;

namespace AIM.NCore.DataTypes
{
	[Serializable]
	public struct DataDouble : IDataType
	{
		private Double _value;
		private bool _isNotNull;

		public Double Value
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

		public DataDouble (Double value)
		{
			_value = value;
			_isNotNull = true;
		}

		public DataDouble (object value)
		{
			if (value is Double)
			{
				_value = (Double) value;
				_isNotNull = true;
			}
			else
			{
				_value = 0;
				_isNotNull = false;
			}
		}

		public static implicit operator DataDouble (Double value)
		{
			return new DataDouble(value);
		}

		public static implicit operator DataDouble (DBNull value)
		{
			return new DataDouble(value);
		}

		public static implicit operator Double (DataDouble value)
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