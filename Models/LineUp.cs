using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSite.Models
{
    public class LineUp
    {
        public String Id { get; set; }
        public DateTime Date { get; set; }
        public String From { get; set; }
        public String Until { get; set; }
        public Stage Stage { get; set; }
        public Band Band { get; set; }

        public override string ToString()
        {
            return Date.ToShortDateString() + "  -  " + Stage;
        }
    }
}