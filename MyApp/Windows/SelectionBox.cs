using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC.Windows
{
	public partial class SelectionBox : Form
	{
		public SelectionBox()
		{
			InitializeComponent();

		}

		#region Private methods
		private void Button_Ok_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Button_Cancel_Click(object sender, EventArgs e)
		{
			this.ListBox_Files.SelectedIndex = -1;
			this.Close();
		}

		private void ListBox_Files_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListBox_Files.SelectedIndex != -1)
			{
				this.Button_Ok.Enabled = true;
			}
		}

		private void updateListBox(VideoFromDatabase[] list)
		{
			if (list == null) return;

			foreach (VideoFromDatabase video in list)
			{
				this.ListBox_Files.Items.Add(video);
			}
		}

		private void reset()
		{
			this.Button_Ok.Enabled = false;
			this.ListBox_Files.Items.Clear();
		}

		#endregion

		#region Public methods
		public VideoFromDatabase showSelectionBox(VideoFromDatabase[] list)
		{
			reset();
			updateListBox(list);
			this.ShowDialog();

			return (VideoFromDatabase)this.ListBox_Files.SelectedItem;
		}

		#endregion

	}
}
