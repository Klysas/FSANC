using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC.Database
{
	class InfoNotFound : Exception
	{
		#region Constructors

		public InfoNotFound(string message)
		{
			Message = message;
		}

		#endregion

		#region Public methods

		public override string ToString()
		{
			return Message;
		}

		#endregion

		#region Properties

		public string Message
		{
			get;
			private set;
		}

		#endregion
	}
}
