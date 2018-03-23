using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HammaBob.Libraries
{
	public class CustomException : Exception
	{
		public CustomException(string message, Exception originalException) : base(message, originalException) { }
	}
}