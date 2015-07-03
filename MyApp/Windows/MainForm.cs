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
		public enum VideoType { SERIAL, FILM };

		/// <summary>
		/// Current video type.
		/// </summary>
		private VideoType _currentVideoType;

		private ConfirmationBox _confirmationBox;

		#endregion


		#region Constructors
		public MainForm()
		{
			InitializeComponent();

			// Initialization.
			_confirmationBox = new ConfirmationBox();
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
				// Add dropped files to video list.
				foreach ( String _droppedFile in (string[])e.Data.GetData(DataFormats.FileDrop) )
				{
					// Protects from duplicate files.
					if (!_files.Contains(_droppedFile))
					{
						_files.Add(_droppedFile);
						if (_currentVideoType == VideoType.SERIAL)
						{
							_videos.Add(new Serial(_droppedFile));
						}
						else
						{
							_videos.Add(new Film(_droppedFile));
						}
					}
				}
				UpdateUI();
			}
		}

		private void ComboBox_VideoType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_currentVideoType = (VideoType)this.DropBox.SelectedItem;

			// Only one type videos at the same time.
			ClearVideoList();
			UpdateUI();

			if (_currentVideoType == VideoType.FILM)
			{
				this.LanguageBox.Show();
			}
			else 
			{
				this.LanguageBox.Hide();
			}
		}

		private void Button_C_Click(object sender, EventArgs e)
		{
			ClearVideoList();
			UpdateUI();
		}

		private void Button_RenameFiles_Click(object sender, EventArgs e)
		{
			if ((_videos.Count() > 0) && (this.TextBox_VideoName.Text != System.String.Empty))
			{
				List<String> _formatedNames = new List<String>();

				if ((_currentVideoType == VideoType.FILM) && (this.LanguageBox.SelectedIndex != -1))
				{
					// Film.
					foreach (Film video in _videos)
					{
						video.setName(this.TextBox_VideoName.Text, this.LanguageBox.SelectedItem.ToString());
						_formatedNames.Add(video.getFormatedFullName());
					}

					if (Confirm(_formatedNames.ToArray()))
					{
						foreach (Film video in _videos)
						{
							video.renameFile();
						}
					}
				}
				else
				{
					// Serial.
					foreach (Serial video in _videos)
					{
						video.setName(this.TextBox_VideoName.Text);
						_formatedNames.Add(video.getFormatedFullName());
					}

					if (Confirm(_formatedNames.ToArray()))
					{
						foreach (Serial video in _videos)
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

		private bool Confirm(String[] list)
		{
			_confirmationBox.ShowConfirmationBox(list);

			while (!_confirmationBox.IsClosed()) 
			{
				System.Threading.Thread.Sleep(50);
			}

			return _confirmationBox.IsConfirmed();
		}

		#endregion


		#region Utils
		private void ClearVideoList()
		{
			_files.Clear();
			_videos.Clear();
		}

		private void UpdateUI()
		{
			this.Label_FilesCount.Text = "Files loaded: " + _files.Count();
		}

		#endregion
	}
}
