using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using FSANC.Utils;

namespace FSANC
{
	/// <summary>
	/// Class for serial video file.
	/// </summary>
	public sealed class Serial : Video
	{
		#region Variables
		private const String TAG = "SERIAL";

		private int _season;

		private int _episode;

		private String _episodeName;
		
		#endregion

		#region Constructors
		public Serial(String path)
			: base(path)
		{
			_episodeName = System.String.Empty;

			extractSeasonAndEpisode();
		}

		#endregion

		#region Private methods
		private void extractSeasonAndEpisode()
		{
			String str = Path.GetFileNameWithoutExtension(_filePath);

			String seasonAndEpisode = Regex.Match(str, @"S\d{2}E\d{2}").ToString();
			if (seasonAndEpisode.Equals("")) seasonAndEpisode = Regex.Match(str, @"s\d{2}e\d{2}").ToString();

			if (!seasonAndEpisode.Equals(""))
			{
				_season = int.Parse(seasonAndEpisode.Substring(1, 2));
				_episode = int.Parse(seasonAndEpisode.Substring(4));

				Log.print(TAG, seasonAndEpisode +" S = "+ _season +" E = "+ _episode);
			}
			else
			{
				_season = 0;
				_episode = 0;
				Log.print(TAG, "Didn't find season/episode values in file name.");
			}
		}

		protected override String getFormatedFullName()
		{
			return Name + " [" + getFormatedSeasonAndEpisode() +" "+ _episodeName + "]" + getFileExtention();
		}

		private String getFormatedSeasonAndEpisode()
		{
			String s = _season < 10 ? "0" : "";
			String e = _episode < 10 ? "0" : "";
			return "S" + s + _season + "E" + e + _episode;
		}

		private void updateEpisodeName(int id)
		{
			_episodeName = VideoDatabase.getEpisodeName(id, _season, _episode);
		}

		#endregion

		#region Public methods
		public override void updateVideoInfo(VideoFromDatabase video)
		{
			this.Name = video.Name;

			updateEpisodeName(video.Id);
		}

		public override void renameFile() // TODO: recheck.
		{
			Console.WriteLine("SERIAL: Renaming file in " + Path.GetDirectoryName(_filePath));
			File.Move(_filePath, Path.GetDirectoryName(_filePath) + "\\" + getFormatedFullName());
		}

		#endregion
	}
}
