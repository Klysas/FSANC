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
	public partial class ConfirmBox : Form
	{
		#region Variables
		public bool confirmation = false;

		#endregion

		#region Constructors
		public ConfirmBox()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods
		private void Button_Yes_Click(object sender, EventArgs e)
		{
			confirmation = true;
			this.close();
		}

		private void Button_No_Click(object sender, EventArgs e)
		{
			this.close();
		}

		private void close() 
		{
			FormControler.ConfirmationClosed = true;
			this.Close();
		}

		#endregion

		#region Public methods
		/// <summary>
		/// Shows this window.
		/// </summary>
		/// <param name="names">List of names displayed in this window.</param>
		public void show(String[] names) 
		{
			confirmation = false;
			this.FilesList.Items.Clear();

			this.FilesList.Items.AddRange(names);
			this.ShowDialog();
		}

		#endregion
	}
}
