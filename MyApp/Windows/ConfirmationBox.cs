using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC
{
	public partial class ConfirmationBox : Form
	{
		#region Variables
		/// <summary>
		/// Shows "Yes"(true) or "No"(false) was pressed.
		/// </summary>
		private bool _confirmed = false;

		/// <summary>
		/// True if window is closed.
		/// </summary>
		private bool _closed = true;

		#endregion


		#region Constructors
		public ConfirmationBox()
		{
			InitializeComponent();
		}

		#endregion


		#region Private methods
		private void Button_Yes_Click(object sender, EventArgs e)
		{
			_confirmed = true;
			this.CloseConfirmationBox();
		}

		private void Button_No_Click(object sender, EventArgs e)
		{
			this.CloseConfirmationBox();
		}

		private void CloseConfirmationBox() 
		{
			_closed = true;
			this.Close();
		}

		#endregion


		#region Public methods
		/// <summary>
		/// Shows this window.
		/// </summary>
		/// <param name="names">List of names displayed in this window.</param>
		public void ShowConfirmationBox(String[] names) 
		{
			_closed = false;
			_confirmed = false;

			// Make sure that list is empty.
			this.FilesList.Items.Clear();

			this.FilesList.Items.AddRange(names);
			this.ShowDialog();
		}

		public bool IsClosed()
		{
			return _closed;
		}

		public bool IsConfirmed()
		{
			return _confirmed;
		}

		#endregion
	}
}
