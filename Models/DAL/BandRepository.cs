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

            List<Band> bands = new List<Band>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                     Band band = Create(reader);

                     bands.Add(band);
                }
            }
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
            DbParameter idPar = Database.AddParameter("@Id", bandId);
 
            DbDataReader reader = Database.GetData(sql, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Band band = Create(reader);
                    return band;
                }
            }
            return null;
        }
        
    
        }
    }