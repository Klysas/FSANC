using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyApp
{
	public class Film : Video
	{
		private int year;

		private String language;

		private String[] genres;

		public Film(String path) : base(path)
		{
			year = 0;
			language = System.String.Empty;

			tryToGetYear();
		}


		private void tryToGetYear()
		{
			year = int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(oldPath), @"\d{4}").ToString());

			Console.WriteLine("FILM: Year: {0}", year);
		}


		public String getFileExtension()
		{
			return Path.GetExtension(oldPath);
		}


		public String getFormatedFullName()
		{
			return Name + " [" + year + "][" + language + "] [" + getFormatedGenres() + "]" + getFileExtension();
		}


		public String getFormatedGenres() {
			StringBuilder sb = new StringBuilder();

			if (genres.Count() == 0)
			{
				return System.String.Empty;
			}

			sb.Append(genres[0]);
			for(var i = 1; i < genres.Count(); i++)
			{
				sb.Append(@"&" + genres[i]);
			}

			return sb.ToString();
		}


		public void setName(String name, String language) 
		{
			this.Name = name;
			this.language = language;
			genres = VideoDatabase.getFilmGenres(this.Name, year);
			for (int i = 0; i < genres.Count(); i++ )
			{
				if (genres[i].Equals("Science Fiction"))
				{
					genres[i] = "Sci-Fi";
				}
			}
			Console.WriteLine("FILM: Name: {0}, Year: {1}, Genres: {2}", this.Name, year, genres.ToString());
		}


		public void renameFile()
		{
			Console.WriteLine("FILM: Renaming file in " + Path.GetDirectoryName(oldPath));
			File.Move(oldPath, Path.GetDirectoryName(oldPath) + "\\" + getFormatedFullName());
		}
	}
}
