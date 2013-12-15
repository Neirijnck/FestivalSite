using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class GenreRepository
    {
        public static List<Genre> GetGenres()
        {
            String sql = "SELECT * FROM [Genre]";

            List<Genre> genres = new List<Genre>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Genre genre = Create(reader);

                    genres.Add(genre);
                }
            }
            reader.Close();
            return genres;
        }

        private static Genre Create(DbDataReader reader)
        {
            return new Genre()
            {
                Id = reader["Id"].ToString(),
                Name = reader["Name"].ToString()
            };
        }

        public static List<Genre> GetGenresByBand(List<Genre> l, String IdBand)
        {
            List<Genre> genres = new List<Genre>();

            String sql = "SELECT * FROM Band_Genre WHERE BandId=@BandId";

            DbParameter idPar = Database.AddParameter("@BandId", IdBand);

            DbDataReader reader = Database.GetData(sql, idPar);

            while (reader.Read())
            {
                int GenreId = int.Parse(reader["GenreId"].ToString());
                Genre genre = GenreRepository.GetGenreById(l, GenreId);
                genres.Add(genre);
            }
            reader.Close();
            return genres;

        }

        public static Genre GetGenreById(List<Genre> l, int IdGenre)
        {
            foreach (Genre genre in l)
            {
                if (genre.Id == IdGenre.ToString())
                {
                    return genre;
                }
            }
            return null;
        }

    }
}