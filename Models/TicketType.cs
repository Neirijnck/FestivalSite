using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSite.Models
{
    public class TicketType
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public int AvailableTickets { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
    
}