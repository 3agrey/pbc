using System;

namespace AIM.PBC.Core.Exceptions
{
	public sealed class ConsistencyException : CoreException
	{
		public ConsistencyException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public ConsistencyException(string message) : base(message)
		{
		}
	}
}