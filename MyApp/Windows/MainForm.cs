using FSANC.Database;
using FSANC.Objects;
using FSANC.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FSANC.Windows
{
	public partial class MainForm : Form
	{
		#region Variables

		private const String TAG = "MAIN_FORM";

		/// <summary>
		/// List of all dropped files on app.
		/// </summary>
		private List<String> _files;

		/// <summary>
		/// List of video files.
		/// </summary>
		private List<Video> _videos;

		/// <summary>
		/// Type of video file.
		/// </summary>
		public enum VideoType { SERIAL, FILM };
		private		VideoType _currentVideoType;

		private ConfirmationBox _confirmationBox;
		private SelectionBox	_selectionBox;

		#endregion


		#region Constructors

		public MainForm()
		{
			InitializeComponent();

			// Initialization.
			_confirmationBox = new ConfirmationBox();
			_selectionBox = new SelectionBox();
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
			if ((_videos.Count > 0) && (this.TextBox_VideoName.Text != System.String.Empty))
			{
				VideoFromDatabase videoInfo;
				if ((_currentVideoType == VideoType.FILM) && (this.LanguageBox.SelectedIndex != -1))
				{
					// Film.
					videoInfo = _selectionBox.showSelectionBox(VideoDatabase.getFilmList(this.TextBox_VideoName.Text));

					if (videoInfo == null) return;

					foreach (Film video in _videos)
					{
						video.updateVideoInfo(videoInfo);
						video.Language = this.LanguageBox.SelectedItem.ToString();
					}

					if (Confirm(_videos.ToArray()))
					{
						foreach (Film video in _videos)
						{
							video.renameFile();
						}

						ClearVideoList();
						UpdateUI();
					}
				}
				else if(_currentVideoType == VideoType.SERIAL)
				{
					// Serial.
					videoInfo = _selectionBox.showSelectionBox(VideoDatabase.getSerialList(this.TextBox_VideoName.Text));

					if (videoInfo == null) return;

					foreach (Serial video in _videos)
					{
						video.updateVideoInfo(videoInfo);
					}

					if (Confirm(_videos.ToArray()))
					{
						foreach (Serial video in _videos)
						{
							video.renameFile();
						}

						ClearVideoList();
						UpdateUI();
					}
				}
			}
		}

		private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Do nothing.
		}

		private bool Confirm(Video[] list)
		{
			return _confirmationBox.ShowConfirmationBox(list);
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
			this.Label_FilesCount.Text = "Files loaded: " + _files.Count;
		}

		#endregion
	}
}
