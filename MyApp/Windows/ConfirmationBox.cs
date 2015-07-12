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
		#region Constructors
		public ConfirmationBox()
		{
			InitializeComponent();
		}

		#endregion


		#region Private methods
		private void Button_Yes_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.Close();
		}

		private void Button_No_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.No;
			this.Close();
		}

		private void Reset()
		{
			// Default value is 'No'.
			this.DialogResult = System.Windows.Forms.DialogResult.No;

			// Make sure that list is empty.
			this.FilesList.Items.Clear();

			this.YesButton.Focus();
		}

		#endregion


		#region Public methods
		/// <summary>
		/// Shows window until 'Yes'/'No' is pressed.
		/// </summary>
		/// <param name="names">Names are displayed</param>
		/// <returns>If 'Yes' pressed - true, otherwise - false</returns>
		public bool ShowConfirmationBox(Video[] names) 
		{
			Reset();
			this.FilesList.Items.AddRange(names);

			return this.ShowDialog() == (System.Windows.Forms.DialogResult.Yes) ? true : false;
		}

		#endregion
	}
}
