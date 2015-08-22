using System;
using System.Text.RegularExpressions;

namespace FSANC.Utils
{
	class Utils
	{
		private static readonly Regex _invalidFileRegex = new Regex(string.Format("[{0}]", Regex.Escape(@"<>:""/\|?*")));
		
		/// <summary>
		/// Removes invalid characters for path and name of file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string SanitizeFileName(string fileName)
		{
			return _invalidFileRegex.Replace(fileName, string.Empty);
		}
		
	}
}
