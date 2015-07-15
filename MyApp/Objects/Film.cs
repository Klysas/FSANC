using FSANC.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FSANC
{
	/// <summary>
	/// Class for film video file.
	/// </summary>
	public sealed class Film : Video
	{
		#region Variables

		private const String TAG = "FILM";

		private int _year;

		private String _language;

		private String[] _genres;

		#endregion

		#region Constructors

		public Film(String path)
			: base(path)
		{
			_language = System.String.Empty;

			tryToGetYear();
		}

		#endregion

		#region Private methods

		private void tryToGetYear()
		{
			try
			{
				_year = int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(_filePath), @"\d{4}").ToString());
			}
			catch
			{
				_year = 0;
			}
			finally
			{
				Log.print(TAG, "Year extracted from file = " + _year);
			}
		}

		protected override String getFormatedFullName()
		{
			return Name + " [" + _year + "][" + _language + "] [" + getFormatedGenres() + "]" + getFileExtention();
		}

		private String getFormatedGenres()
		{
			StringBuilder sb = new StringBuilder();

			if (_genres.Count() == 0)
			{
				return System.String.Empty;
			}

			sb.Append(_genres[0]);
			for (var i = 1; i < _genres.Count(); i++)
			{
				sb.Append(@"&" + _genres[i]);
			}

			return sb.ToString();
		}

		private void updateGenres(int id)
		{
			_genres = VideoDatabase.getFilmGenres(id);
			for (int i = 0; i < _genres.Count(); i++)
			{
				if (_genres[i].Equals("Science Fiction"))
				{
					_genres[i] = "Sci-Fi";
				}
			}
		}

		#endregion

		#region Public methods

		public override void updateVideoInfo(VideoFromDatabase video)
		{
			this.Name = video.Name;
			this.Year = video.Year;

			updateGenres(video.Id);
		}

		public override void renameFile() // TODO: only can rename files, when language is set and updateVideoInfo() is called.
		{
			File.Move(_filePath, Path.GetDirectoryName(_filePath) + "\\" + Utils.Utils.ValidateFileName(getFormatedFullName()));
		}

		#endregion

		#region Private properties

		private int Year
		{
			get { return _year;}
			set { if (value != 0) _year = value; }
		}

		#endregion

		#region Public properties

		public String Language
		{
			get { return _language; }
			set { if (FSANC.Language._list.Contains(value)) _language = value; }
		}

		#endregion
	}
}
