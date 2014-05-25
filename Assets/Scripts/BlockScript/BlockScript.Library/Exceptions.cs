/// <summary>
/// BlockScript Exceptions.
/// 
/// By: Christian Gunderman
/// </summary>
using System;

namespace BlockScript.Library.Exceptions
{
	public class OutOfRangeException : Exception
	{
		public OutOfRangeException (string message) :
			base (message)
		{
		}

		public OutOfRangeException (string message, Exception innerException) :
			base (message, innerException)
		{
		}
	}
}

