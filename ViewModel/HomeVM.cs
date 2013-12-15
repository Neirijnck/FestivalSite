using FestivalSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSite.ViewModel
{
    public class HomeVM
    {
        public List<Band> AllBands { get; set; }
        public List<News> AllNews { get; set; }
    }
}