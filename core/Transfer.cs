using System;
using System.Data.SqlClient;

using AIM.NCore.DataTypes;

namespace AIM.PBC.Core
{
	[Serializable]
	public class Transfer
	{
		#region Members
		protected DataInt32 _id = null;
		protected DataInt32 _sourceAccountId = null;
		protected DataInt32 _targetAccountId = null;
		protected DataString _name = null;
		protected DataByte _type = null;
		#endregion

		#region Properties
		public DataInt32 Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public DataInt32 SourceAccountId
		{
			get { return _sourceAccountId; }
			set { _sourceAccountId = value; }
		}
		public DataInt32 TargetAccountId
		{
			get { return _targetAccountId; }
			set { _targetAccountId = value; }
		}
		public DataString Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public DataByte Type
		{
			get { return _type; }
			set { _type = value; }
		}
		#endregion

		#region LoadFromReader
		public virtual void LoadFromReader (SqlDataReader reader)
		{
			_id = new DataInt32(reader["Id"]);
			_sourceAccountId = new DataInt32(reader["SourceAccountId"]);
			_targetAccountId = new DataInt32(reader["TargetAccountId"]);
			_name = new DataString(reader["Name"]);
			_type = new DataByte(reader["Type"]);
		}
		#endregion

		#region GetHashCode
		public override int GetHashCode ()
		{
			return _id;
		}
		#endregion
	}
}
