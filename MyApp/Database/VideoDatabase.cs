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
	public class VideoDatabase
	{
		#region Variables
		private const String TAG = "VIDEO_DATABASE";

		private static TMDbClient _client = new TMDbClient("9696307d0fc643661e1e2b662a8ba18d");

		#endregion


		#region Public static methods
		public static VideoFromDatabase[] getFilmList(String name)
		{
			SearchContainer<SearchMovie> container = _client.SearchMovie(name);

			if (container.Results.Count == 0) return null;

			VideoFromDatabase[] list = new VideoFromDatabase[container.Results.Count];
			int i = 0;
			foreach( SearchMovie movie in container.Results){
				list[i++] = new VideoFromDatabase(movie.Id, movie.Title, movie.ReleaseDate.Value.Year);
			}

			return list;
		}

		public static VideoFromDatabase[] getSerialList(String name)
		{
			SearchContainer<TvShowBase> container = _client.SearchTvShow(name);

			if (container.Results.Count == 0) return null;

			VideoFromDatabase[] list = new VideoFromDatabase[container.Results.Count];
			int i = 0;
			foreach (TvShowBase serial in container.Results)
			{
				list[i++] = new VideoFromDatabase(serial.Id, serial.Name, serial.FirstAirDate.Value.Year);
			}

			return list;
		}

		public static String getEpisodeName(int id, int season, int episode)
		{
			return _client.GetTvEpisode(id, season, episode).Name;
		}

		public static String getEpisodeName(String name, int season, int episode)
		{
			TvEpisode tvEpisode;
			SearchContainer<TvShowBase> container = _client.SearchTvShow(name);

			if (container.Results.Count > 0)
			{
				tvEpisode = _client.GetTvEpisode(_client.SearchTvShow(name).Results[0].Id, season, episode);
				return tvEpisode.Name;
			}
			else 
			{
				Console.WriteLine("VIDEO_DATABASE: Didn't find any tv show with given name: {0}", name);
			}

			return System.String.Empty;
		}

		public static String[] getFilmGenres(int id)
		{
			Movie theMovie = _client.GetMovie(id);;

			String[] str = new String[theMovie.Genres.Count];
			int i = 0;
			foreach (Genre genre in theMovie.Genres)
			{
				str[i++] = genre.Name;
			}
			return str;
		}

		public static String[] getFilmGenres(String name, int year) 
		{
			Movie theMovie;
			SearchContainer<SearchMovie> container = _client.SearchMovie(name);

			if (container.Results.Count > 0)
			{
				Console.WriteLine("VIDEO_DATABASE: Films count: " + container.Results.Count);
				foreach (SearchMovie movie in container.Results)
				{
					if (movie.ReleaseDate.Value.Year == year)
					{
						theMovie = _client.GetMovie(movie.Id);

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

		#endregion
	}
}
