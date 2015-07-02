using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
	public partial class MainForm : Form
	{
		private List<String> files;
		private List<Video> videos;

		public enum videoType { SERIAL, FILM};
		private videoType current;

		private ConfirmBox confirmation;

		public MainForm()
		{
			InitializeComponent();

			confirmation = new ConfirmBox();

			files = new List<String>();
			videos = new List<Video>();

			//Drag and drop
			this.AllowDrop = true;
			this.DragEnter += MainForm_DragEnter;
			this.DragDrop += MainForm_DragDrop;
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				//Gets all paths of files dropped on form
				String[] filesLoc = (string[])(e.Data.GetData(DataFormats.FileDrop));

				foreach (String loc in filesLoc)
				{
					if (!files.Contains(loc))
					{
						files.Add(loc);
						if (current == videoType.SERIAL)
						{
							videos.Add(new Serial(loc));
						}
						else
						{
							videos.Add(new Film(loc));
						}
					}
				}

				updateLabel();
				Console.WriteLine("DROP: {0} dropped, {1} total.", filesLoc.Count(), files.Count());
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			current = (videoType)this.DropBox.SelectedItem;

			clearVideoList();

			if (current == videoType.FILM)
			{
				this.LanguageBox.Show();
			}
			else 
			{
				this.LanguageBox.Hide();
			}
			Console.WriteLine("DROP_BOX: Type = {0}", current);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			clearVideoList();
		}

		private void clearVideoList() 
		{
			files.Clear();
			videos.Clear();
			updateLabel();
		}

		private void updateLabel()
		{
			this.FilesCountLabel.Text = "Files loaded: " + files.Count();
		}

		private void RenameFilesButton_Click(object sender, EventArgs e)
		{
			if ((videos.Count() > 0) && (this.NameBox.Text != System.String.Empty))
			{
				List<String> newNames = new List<String>();

				if (current == videoType.SERIAL)
				{
					foreach (Serial video in videos)
					{
						video.setName(this.NameBox.Text);
						newNames.Add(video.getFormatedFullName());
					}

					if (confirm(newNames.ToArray()))
					{
						foreach (Serial video in videos)
						{
							video.renameFile();
						}
					}
				}
				if ((current == videoType.FILM) && (this.LanguageBox.SelectedIndex != -1))
				{
					foreach (Film video in videos)
					{
						video.setName(this.NameBox.Text, this.LanguageBox.SelectedItem.ToString());
						newNames.Add(video.getFormatedFullName());
					}

					if (confirm(newNames.ToArray()))
					{
						foreach (Film video in videos)
						{
							video.renameFile();
						}
					}
				}
			}
		}

		private bool confirm(String[] list)
		{
			confirmation.show(list);

			while (!FormControler.ConfirmationClosed) 
			{
				System.Threading.Thread.Sleep(10);
			}

			FormControler.ConfirmationClosed = false;

			return confirmation.confirmation;
		}

		private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Do nothing.
		}
	}
}
