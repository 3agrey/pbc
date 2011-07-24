using System;
using System.Runtime.Serialization;

namespace AIM.PBC.Core.Exceptions
{
	public class CoreException : PbcException
	{
		public CoreException()
		{
		}

		public CoreException(string message) : base(message)
		{
		}

		public CoreException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public CoreException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}