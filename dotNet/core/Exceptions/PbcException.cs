using System;
using System.Runtime.Serialization;

namespace AIM.PBC.Core.Exceptions
{
	public class PbcException : ApplicationException
	{
		public PbcException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public PbcException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public PbcException(string message) : base(message)
		{
		}

		public PbcException()
		{
		}
	}
}