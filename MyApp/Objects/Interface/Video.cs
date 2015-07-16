using FSANC.Database;
using FSANC.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC.Objects
{
	public abstract class Video
	{
		#region Variables

		/// <summary>
		/// Full path with filename.
		/// </summary>
		public readonly string _filePath;

		#endregion

		#region Constructor

		public Video(string path)
		{
			_filePath = path.Trim();
		}

		#endregion

		#region Private methods

		protected abstract String getFormatedFullName();

		protected String getFileExtention()
		{
			return Path.GetExtension(_filePath);
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Updates file info, must run before renameFile().
		/// </summary>
		/// <param name="video">Info about individual video (i.e. Title, Year, Id in database).</param>
		public abstract void updateVideoInfo(VideoFromDatabase video);

		public override string ToString()
		{	
			return getFormatedFullName();
		}

		public void renameFile()
		{
			File.Move(_filePath, Path.GetDirectoryName(_filePath) + "\\" + Utils.Utils.ValidateFileName(getFormatedFullName()));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Video title name.
		/// </summary>
		protected String Name
		{
			get;
			set;
		}

		#endregion
	}
}
