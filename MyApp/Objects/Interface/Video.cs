using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC
{
	/// <summary>
	/// Video file interface.
	/// </summary>
	public class Video
	{
		#region Variables
		public readonly String oldPath;

		private String name;

		#endregion

		#region Constructor
		public Video(String path)
		{
			oldPath = path;

			name = System.String.Empty;
		}

		#endregion

		public String Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}
