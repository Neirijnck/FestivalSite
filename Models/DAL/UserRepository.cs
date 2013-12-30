using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class UserRepository
    {
        public static User GetUserById(String Id) 
        {
            String sql = "SELECT * FROM [UserProfile] WHERE [UserId]=@Id";

            DbParameter idPar = Database.AddParameter("@Id", Id);

            DbDataReader reader = Database.GetData(sql, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = Create(reader);
                    reader.Close();
                    return user;
                }
            }
            reader.Close();
            return null;
        }

        private static User Create(DbDataReader reader)
        {
            User user = new User();

            user.Id = reader["UserId"].ToString();
            user.Name = reader["UserName"].ToString();
            user.Email = reader["Email"].ToString();

            return user;
        }

    }
}