using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FSANC
{
	/// <summary>
	/// Class for serial video file.
	/// </summary>
	public class Serial : Video
	{

		private int season;

		private int episode;

		private String episodeName;


		public Serial(String path)
			: base(path)
		{
			episodeName = System.String.Empty;

			extractSeasonAndEpisode();
		}


		private void extractSeasonAndEpisode()
		{
			String str = Path.GetFileNameWithoutExtension(oldPath);

			String formatedSeasonAndEpisode = Regex.Match(str, @"S\d{2}E\d{2}").ToString();

			if (!formatedSeasonAndEpisode.Equals(""))
			{
				season = int.Parse(formatedSeasonAndEpisode.Substring(1, 2));
				episode = int.Parse(formatedSeasonAndEpisode.Substring(4));

				Console.WriteLine("SERIAL: {0} S: {1} E: {2}", formatedSeasonAndEpisode, season, episode);
			}
			else
			{
				Console.WriteLine("SERIAL: Failed to get season and episode values.");
			}
		}

		public String getFormatedSeasonAndEpisode()
		{
			String s = season < 10 ? "0" : "";
			String e = episode < 10 ? "0" : "";
			return "S" + s + season + "E" + e + episode;
		}

		public String getFileExtention()
		{
			return Path.GetExtension(oldPath);
		}

		public void setName(String name) 
		{
			this.Name = name;
			episodeName = VideoDatabase.getEpisodeName(this.Name, season, episode);
			Console.WriteLine("SERIAL: Name: {0}, Episode: {1}", this.Name, episodeName);
		}

		public String getFormatedFullName()
		{
			return Name + " [" + getFormatedSeasonAndEpisode() +" "+ episodeName + "]" + getFileExtention();
		}

		public void renameFile()
		{
			Console.WriteLine("SERIAL: Renaming file in " + Path.GetDirectoryName(oldPath));
			File.Move(oldPath, Path.GetDirectoryName(oldPath) + "\\" + getFormatedFullName());
		}
	}
}
