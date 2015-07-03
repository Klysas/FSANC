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

namespace FSANC
{
	public partial class MainForm : Form
	{
		#region Variables
		/// <summary>
		/// List of all dropped files on app.
		/// </summary>
		private List<String> _files;

		/// <summary>
		/// List of video files.
		/// </summary>
		private List<Video> _videos;

		/// <summary>
		/// Video type of video file.
		/// </summary>
		public enum videoType { SERIAL, FILM };
		private videoType _currentType;

		private ConfirmBox _confirmationBox;

		#endregion

		#region Constructors
		public MainForm()
		{
			InitializeComponent();

			// Initialization.
			_confirmationBox = new ConfirmBox();

			_files = new List<String>();
			_videos = new List<Video>();

			// Drag and drop.
			this.AllowDrop = true;
			this.DragEnter += MainForm_DragEnter;
			this.DragDrop += MainForm_DragDrop;
		}

		#endregion

		#region Private methods
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
				// Gets all paths of files dropped on form.
				String[] filesLoc = (string[])(e.Data.GetData(DataFormats.FileDrop));

				// Add files to video list.
				foreach (String loc in filesLoc)
				{
					if (!_files.Contains(loc))
					{
						_files.Add(loc);
						if (_currentType == videoType.SERIAL)
						{
							_videos.Add(new Serial(loc));
						}
						else
						{
							_videos.Add(new Film(loc));
						}
					}
				}

				updateLabel();
				Console.WriteLine("DROP: {0} dropped, {1} total.", filesLoc.Count(), _files.Count());
			}
		}

		private void comboBox_VideoType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_currentType = (videoType)this.DropBox.SelectedItem;

			clearVideoList();

			if (_currentType == videoType.FILM)
			{
				this.LanguageBox.Show();
			}
			else 
			{
				this.LanguageBox.Hide();
			}
			Console.WriteLine("DROP_BOX: Type = {0}", _currentType);
		}

		private void button_C_Click(object sender, EventArgs e)
		{
			clearVideoList();
		}

		private void RenameFilesButton_Click(object sender, EventArgs e)
		{
			if ((_videos.Count() > 0) && (this.NameBox.Text != System.String.Empty))
			{
				List<String> newNames = new List<String>();

				if (_currentType == videoType.SERIAL)
				{
					foreach (Serial video in _videos)
					{
						video.setName(this.NameBox.Text);
						newNames.Add(video.getFormatedFullName());
					}

					if (confirm(newNames.ToArray()))
					{
						foreach (Serial video in _videos)
						{
							video.renameFile();
						}
					}
				}
				if ((_currentType == videoType.FILM) && (this.LanguageBox.SelectedIndex != -1))
				{
					foreach (Film video in _videos)
					{
						video.setName(this.NameBox.Text, this.LanguageBox.SelectedItem.ToString());
						newNames.Add(video.getFormatedFullName());
					}

					if (confirm(newNames.ToArray()))
					{
						foreach (Film video in _videos)
						{
							video.renameFile();
						}
					}
				}
			}
		}

		private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Do nothing.
		}

		private bool confirm(String[] list)
		{
			_confirmationBox.show(list);

			while (!FormControler.ConfirmationClosed) 
			{
				System.Threading.Thread.Sleep(10);
			}

			FormControler.ConfirmationClosed = false;

			return _confirmationBox.confirmation;
		}

		#endregion

		#region Utils
		private void clearVideoList()
		{
			_files.Clear();
			_videos.Clear();
			updateLabel();
		}

		private void updateLabel()
		{
			this.FilesCountLabel.Text = "Files loaded: " + _files.Count();
		}

		#endregion
	}
}
