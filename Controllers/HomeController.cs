using FestivalSite.Models;
using FestivalSite.Models.DAL;
using FestivalSite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            HomeVM vm = new HomeVM();
            vm.AllBands = BandRepository.GetBands();
            vm.AllNews = NewsRepository.GetNews();
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult Bands(String sortOrder, String SearchString)
        {
            BandVM vm = new BandVM();
            vm.LineUpRepository = new LineUpRepository();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            switch (sortOrder)
            {
                case "Name_desc":
                    vm.AllBands = BandRepository.GetBandsOrderByName();
                    break;
                case "Date":
                    vm.AllBands = BandRepository.GetBandsOrderByDate();
                    break;
                case "Date_desc":
                    vm.AllBands = BandRepository.GetBandsOrderByDateDesc();
                    break;
                default:
                    vm.AllBands = BandRepository.GetBands();
                    break;
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                vm.AllBands = BandRepository.GetBandsByString(SearchString);
            }

            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult Details(String id)
        {  
            return View(BandRepository.FindById(id));
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
