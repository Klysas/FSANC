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

namespace FSANC.Database
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

			if (container.Results.Count == 0) throw new InfoNotFound("No film was found by given title.");

			VideoFromDatabase[] list = new VideoFromDatabase[container.Results.Count];
			int i = 0;
			foreach( SearchMovie movie in container.Results){
				list[i++] = createVideoFromDatabase(movie.Id, movie.Title, movie.ReleaseDate);	
			}

			return list;
		}

		public static VideoFromDatabase[] getSerialList(String name)
		{
			SearchContainer<TvShowBase> container = _client.SearchTvShow(name);

			if (container.Results.Count == 0) throw new InfoNotFound("No serial was found by given title.");

			VideoFromDatabase[] list = new VideoFromDatabase[container.Results.Count];
			int i = 0;
			foreach (TvShowBase serial in container.Results)
			{
				list[i++] = createVideoFromDatabase(serial.Id, serial.Name, serial.FirstAirDate);
			}

			return list;
		}

		public static String getEpisodeName(int id, int season, int episode)
		{
			return _client.GetTvEpisode(id, season, episode).Name;
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

		#endregion

		#region Private static methods

		// Protects date value being null.
		private static VideoFromDatabase createVideoFromDatabase(int id, String name, DateTime? date)
		{
			if (date == null)	return new VideoFromDatabase(id, name, 0);
			else				return new VideoFromDatabase(id, name, date.Value.Year);
		}

		#endregion
	}
}
