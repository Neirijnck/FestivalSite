using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class StageRepository
    {
        public static List<Stage> GetStages()
        {
            String sql = "SELECT * FROM [Stage]";

            List<Stage> stages = new List<Stage>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Stage stage = Create(reader);

                    stages.Add(stage);
                }
            }
            reader.Close();
            return stages;
        }

        private static Stage Create(DbDataReader reader)
        {
            return new Stage()
            {
                Id = reader["Id"].ToString(),
                Name = reader["Name"].ToString()
            };
        }

        public static Stage GetStageById(List<Stage> l, int IdStage)
        {
            foreach (Stage stage in l)
            {
                if (stage.Id == IdStage.ToString())
                {
                    return stage;
                }
            }
            return null;
        }

    }
}