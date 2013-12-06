using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSite.Models.DAL
{
    public class TicketRepository
    {
        public static List<Ticket> GetTickets() 
        {
            String sql = "SELECT * FROM [Ticket]";

            List<Ticket> tickets = new List<Ticket>();

            DbDataReader reader = Database.GetData(sql, null);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Ticket ticket = Create(reader);

                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

        private static Ticket Create(DbDataReader reader)
        {
            Ticket ticket = new Ticket();

            ticket.Id = reader["Id"].ToString();
            ticket.TicketHolder = reader["TicketHolder"].ToString();
            ticket.TicketHolderEmail = reader["TicketHolderEmail"].ToString();
            ticket.TicketType = TicketTypeRepository.FindById(reader["TicketType"].ToString());
            ticket.Amount = int.Parse(reader["TicketType"].ToString());

            return ticket;
        }

        public static int SaveTicket(Ticket ticket) 
        {
            String sSQL = "INSERT INTO Ticket(TicketHolder, TicketHolderEmail, TicketType, Amount) VALUES(@TicketHolder, @TicketHolderEmail, @TicketType, @Amount)";

            String ticketType = ticket.TicketType.ToString(); 
            TicketType tt = TicketTypeRepository.getTicketTypeByName(ticketType);

            DbParameter par1 = Database.AddParameter("@TicketHolder", ticket.TicketHolder);
            if (par1.Value == null) par1.Value = DBNull.Value;

            DbParameter par2 = Database.AddParameter("@TicketHolderEmail", ticket.TicketHolderEmail);
            if (par2.Value == null) par2.Value = DBNull.Value;

            DbParameter par3 = Database.AddParameter("@TicketType", tt.Id);
            if (par3.Value == null) par3.Value = DBNull.Value;

            DbParameter par4 = Database.AddParameter("@Amount", ticket.Amount);
            if (par4.Value == null) par4.Value = DBNull.Value;

            DbParameter[] pars = new DbParameter[] { par1, par2, par3, par4 };
            int affected = Database.ModifyData(sSQL, pars);

            return affected;
        }

        public static List<Ticket> GetTicketsByEmail(String email) 
        {
             String sql = "SELECT * FROM [Ticket] WHERE [TicketHolderEmail]=@email";

            List<Ticket> tickets = new List<Ticket>();
            DbParameter idPar = Database.AddParameter("@email", email);

            DbDataReader reader = Database.GetData(sql, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Ticket ticket = Create(reader);
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

    }
}