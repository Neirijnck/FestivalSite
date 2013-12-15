using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class NewsRepository
    {
        public static List<News> GetNews() 
        {
            String sql = "SELECT * FROM News ORDER BY Date desc";

            List<News> newsList = new List<News>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    News news = Create(reader);

                    newsList.Add(news);
                }
            }
            reader.Close();
            return newsList;
        }

        private static News Create(DbDataReader reader)
        {
            News news = new News();
            news.Id = reader["Id"].ToString();
            news.Author = reader["Author"].ToString();
            news.Title = reader["Title"].ToString();
            news.Content = reader["Content"].ToString();
            news.Date = DateTime.Parse(reader["Date"].ToString());
            return news;
        }
    }
}