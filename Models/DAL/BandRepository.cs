using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class BandRepository
    {
        public static List<Band> GetBands() 
        {
            String sql = "SELECT * FROM [Band]";

            List<Genre> genres = GenreRepository.GetGenres();
            List<Band> bands = new List<Band>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                     Band band = Create(reader);
                     band.Genres = GenreRepository.GetGenresByBand(genres, band.Id);
                     bands.Add(band);
                }
            }
            reader.Close();
            return bands;
        }

        private static Band Create(DbDataReader reader)
        {
 	                Band band = new Band();
                    band.Id = reader["Id"].ToString();
                    band.Name = reader["Name"].ToString();
                    band.Picture = reader["Picture"].ToString();
                    band.Description = reader["Description"].ToString();
                    band.Facebook = reader["Facebook"].ToString();
                    band.Twitter = reader["Twitter"].ToString();
                    return band;
        }

        public static Band FindById(String bandId) 
        {
            String sql = "SELECT * FROM [Band] WHERE [Id]=@Id";

            List<Genre> genres = GenreRepository.GetGenres();
            DbParameter idPar = Database.AddParameter("@Id", bandId);
 
            DbDataReader reader = Database.GetData(sql, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Band band = Create(reader);
                    band.Genres = GenreRepository.GetGenresByBand(genres, band.Id);
                    reader.Close();
                    return band;
                }
            }
            return null;
        }

        public static List<Band> GetBandsOrderByName()
        {
            String sql = "SELECT * FROM [Band] ORDER BY NAME";

            List<Genre> genres = GenreRepository.GetGenres();
            List<Band> bands = new List<Band>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Band band = Create(reader);
                    band.Genres = GenreRepository.GetGenresByBand(genres, band.Id);
                    bands.Add(band);
                }
            }
            reader.Close();
            return bands;
        }

        public static List<Band> GetBandsOrderByDate()
        {
            String sql = "SELECT * FROM [Band] INNER JOIN LineUp ON Band.Id = LineUp.Band ORDER BY Date,[From]";

            List<Genre> genres = GenreRepository.GetGenres();
            List<Band> bands = new List<Band>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Band band = Create(reader);
                    band.Genres = GenreRepository.GetGenresByBand(genres, band.Id);
                    bands.Add(band);
                }
            }
            reader.Close();
            return bands;
        }

        public static List<Band> GetBandsOrderByDateDesc()
        {
            String sql = "SELECT * FROM [Band] INNER JOIN LineUp ON Band.Id = LineUp.Band ORDER BY Date desc,[From]";

            List<Genre> genres = GenreRepository.GetGenres();
            List<Band> bands = new List<Band>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Band band = Create(reader);
                    band.Genres = GenreRepository.GetGenresByBand(genres, band.Id);
                    bands.Add(band);
                }
            }
            reader.Close();
            return bands;
        }

        public static List<Band> GetBandsByString(String search)
        {
            List<Band> bands = BandRepository.GetBands();
            List<Band> ListFoundBands = new List<Band>();
            foreach (Band band in bands)
            {
                if (band.Name.ToUpper().Contains(search.ToUpper()))
                {
                    ListFoundBands.Add(band);
                }
            }
            return ListFoundBands;
        }

        }
    }