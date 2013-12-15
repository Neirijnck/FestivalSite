using FestivalSite.Models;
using FestivalSite.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSite.ViewModel
{
    public class BandVM
    {
       public List<Band> AllBands { get; set; }
       public LineUpRepository LineUpRepository { get; set; }
    }
}