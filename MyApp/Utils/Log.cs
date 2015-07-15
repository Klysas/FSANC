using System;

namespace FSANC.Utils
{
	class Log
	{
		public static void print(String tag, String message)
		{
			Console.WriteLine("{0}: {1}", tag, message);
		}
	}
}
