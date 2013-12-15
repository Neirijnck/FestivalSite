using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSite.Models
{
    public class Genre
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}