using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FestivalSite.Models
{
    public class Band
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
        public String Twitter { get; set; }
        public String Facebook { get; set; }
    }
}