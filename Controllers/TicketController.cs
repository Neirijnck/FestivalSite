using FestivalSite.Models;
using FestivalSite.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSite.Controllers
{
    public class TicketController : Controller
    {
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View(TicketRepository.GetTickets());
        }


        [Authorize(Roles = "Admin, Visitor")]
        public ActionResult Bestel() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bestel(Ticket ticket) 
        {
            TicketRepository.SaveTicket(ticket);
            return RedirectToAction("Bestel");
        }



    }
}
