using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace FSANC
{
	/// <summary>
	/// Class for connecting to video database and retrieving needed info about films and serials.
	/// </summary>
	class VideoDatabase
	{
		public static TMDbClient client = new TMDbClient("9696307d0fc643661e1e2b662a8ba18d");

		public static String getEpisodeName(String name, int season, int episode)
		{
			TvEpisode tvEpisode;
			SearchContainer<TvShowBase> container = client.SearchTvShow(name);

			if (container.Results.Count > 0)
			{
				tvEpisode = client.GetTvEpisode(client.SearchTvShow(name).Results[0].Id, season, episode);
				return tvEpisode.Name;
			}
			else 
			{
				Console.WriteLine("VIDEO_DATABASE: Didn't find any tv show with given name: {0}", name);
			}

			return System.String.Empty;
		}

		public static String[] getFilmGenres(String name, int year) 
		{
			Movie theMovie;
			SearchContainer<SearchMovie> container = client.SearchMovie(name);

			if (container.Results.Count > 0)
			{
				Console.WriteLine("VIDEO_DATABASE: Films count: " + container.Results.Count);
				foreach (SearchMovie movie in container.Results)
				{
					if (movie.ReleaseDate.Value.Year == year)
					{
						theMovie = client.GetMovie(movie.Id);

						String[] str = new String[theMovie.Genres.Count];
						int i = 0;
						foreach (Genre genre in theMovie.Genres)
						{
							str[i++] = genre.Name;
						}
						return str;
					}
				}
			}
			else
			{
				Console.WriteLine("VIDEO_DATABASE: Didn't find any film with given name: {0}", name);
			}

			return new String[]{};
		}
	}
}
