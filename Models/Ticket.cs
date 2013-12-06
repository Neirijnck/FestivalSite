using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FestivalSite.Models
{
    public class Ticket
    {
        public String Id { get; set; }

        public String TicketHolder { get; set; }

        public String TicketHolderEmail { get; set; }

        public TicketType TicketType { get; set; }

        public int Amount { get;set; }
    }
}