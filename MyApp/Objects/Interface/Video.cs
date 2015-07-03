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
		public readonly String oldPath;

		private String name;

		public Video(String path)
		{
			oldPath = path;

			name = System.String.Empty;
		}

		public String Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}
