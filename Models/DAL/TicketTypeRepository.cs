using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class TicketTypeRepository
    {
        public static List<TicketType> GetTicketTypes() 
        {
            String sql = "SELECT * FROM [TicketType]";

            List<TicketType> ticketTypes = new List<TicketType>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    TicketType ticketType = Create(reader);

                    ticketTypes.Add(ticketType);
                }
            }
            return ticketTypes;
        }

        private static TicketType Create(DbDataReader reader)
        {
            TicketType ticketType = new TicketType();

            ticketType.Id = reader["Id"].ToString();
            ticketType.Name = reader["Name"].ToString();
            ticketType.Price = double.Parse(reader["Price"].ToString());
            ticketType.AvailableTickets = int.Parse(reader["AvailableTickets"].ToString());

            return ticketType;
        }

        public static TicketType FindById(String TicketTypeId)
        {
            String sql = "SELECT * FROM [TicketType] WHERE [Id]=@Id";
            DbParameter idPar = Database.AddParameter("@Id", TicketTypeId);

            DbDataReader reader = Database.GetData(sql, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    TicketType ticketType = Create(reader);
                    return ticketType;
                }
            }
            return null;
        }

        public static TicketType getTicketTypeByName(String Name) 
        {
            String sql = "SELECT * FROM [TicketType] WHERE [Name]=@Name";
            DbParameter idPar = Database.AddParameter("@Name", Name);

            DbDataReader reader = Database.GetData(sql, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    TicketType ticketType = Create(reader);
                    return ticketType;
                }
            }
            return null;
        }

    }
}