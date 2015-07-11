using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
