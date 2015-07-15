using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC.Utils
{
	class Utils
	{
		public static string ValidateFileName(string name)
		{
			name = name.Replace(":", "");
			name = name.Replace("*", "");
			name = name.Replace("\"", "");
			name = name.Replace("<", "");
			name = name.Replace(">", "");
			name = name.Replace("?", "");
			name = name.Replace("|", "");
			name = name.Replace("/", "");
			name = name.Replace("\\", "");

			return name;
		}
	}
}
