using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class LineUpRepository
    {
        public LineUp GetLineUpByBand(Band band)
        {
            List<Stage> lS = StageRepository.GetStages();

            String sql = "SELECT * FROM LineUp WHERE Band=@BandId";

            DbParameter idPar = Database.AddParameter("@BandId", band.Id);

            DbDataReader reader = Database.GetData(sql, idPar);

            while (reader.Read())
            {
                int IdStage = int.Parse(reader["Stage"].ToString());
                //nog aanpassen
                Stage stage = StageRepository.GetStageById(lS, IdStage);
                LineUp lineup = CreateLineUpFromBand(reader, stage);
                return lineup;
            }
            reader.Close();
            return null;

        }

        private static LineUp CreateLineUpFromBand(DbDataReader reader, Stage stage)
        {
            return new LineUp()
            {
                Id = reader["Id"].ToString(),
                Date = Convert.ToDateTime(reader["Date"].ToString()),
                From = reader["From"].ToString(),
                Until = reader["Until"].ToString(),
                Stage = stage
            };
        }
    }
}