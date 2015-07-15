using System;

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
