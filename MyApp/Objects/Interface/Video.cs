using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FSANC
{
	public abstract class Video
	{
		#region Variables
		public readonly String _filePath;

		private readonly Regex _invalidFileRegex = new Regex(string.Format("[{0}]", Regex.Escape(@"<>:""/\|?*")));

		#endregion

		#region Constructor
		public Video(String path)
		{
			_filePath = path;
		}

		#endregion

		#region Private methods
		protected abstract String getFormatedFullName();

		protected String getFileExtention()
		{
			return Path.GetExtension(_filePath);
		}

		/// <summary>
		/// Removes invalid characters for path and name of file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		private string SanitizeFileName(string fileName)
		{
			return _invalidFileRegex.Replace(fileName, string.Empty);
		}

		#endregion

		#region Public methods
		public void renameFile() // TODO: only can rename files, when language is set and updateVideoInfo() is called.
		{
			File.Move(_filePath, Path.GetDirectoryName(_filePath) + "\\" + SanitizeFileName(getFormatedFullName()));
		}

		public abstract void updateVideoInfo(VideoFromDatabase video);

		public override string ToString()
		{	
			return getFormatedFullName();
		}

		#endregion

		#region Properties
		protected String Name
		{
			get;
			set;
		}

		#endregion
	}
}
