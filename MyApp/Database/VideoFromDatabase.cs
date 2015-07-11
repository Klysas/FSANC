using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC
{
	public class VideoFromDatabase
	{
		#region Constructors
		public VideoFromDatabase(int id, String name, int year)
		{
			this.Id = id;
			this.Name = name;
			this.Year = year;
		}

		#endregion

		#region Properties
		public int Id
		{
			get;
			private set;
		}

		public String Name
		{
			get;
			private set;
		}

		public int Year
		{
			get;
			private set;
		}

		#endregion

	}
}
