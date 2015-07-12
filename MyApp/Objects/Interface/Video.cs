using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC
{
	public abstract class Video
	{
		#region Variables
		public readonly String _filePath;

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

		#endregion

		#region Public methods
		public void renameFile() // TODO: only can rename files, when language is set and updateVideoInfo() is called.
		{
			File.Move(_filePath, Path.GetDirectoryName(_filePath) + "\\" + getFormatedFullName());// TODO: NotSupportedException unhandled.
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
