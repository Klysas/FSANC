using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
	public partial class ConfirmBox : Form
	{
		public bool confirmation = false;
		
		public ConfirmBox()
		{
			InitializeComponent();
		}

		private void YesButton_Click(object sender, EventArgs e)
		{
			confirmation = true;
			this.close();
		}

		private void NoButton_Click(object sender, EventArgs e)
		{
			this.close();
		}

		private void close() 
		{
			FormControler.ConfirmationClosed = true;
			this.Close();
		}

		public void show(String[] names) 
		{
			confirmation = false;
			this.FilesList.Items.Clear();

			this.FilesList.Items.AddRange(names);
			this.ShowDialog();
		}
	}
}
