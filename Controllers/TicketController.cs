using FestivalSite.Models;
using FestivalSite.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

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
            String id = WebSecurity.CurrentUserId.ToString();
            User u = UserRepository.GetUserById(id);
            ticket.TicketHolderEmail = u.Email;
            TicketRepository.SaveTicket(ticket);
            return RedirectToAction("TicketOverzicht", new {Email = u.Email });
        }

        [Authorize(Roles= "Admin, Visitor")]
        public ActionResult TicketOverzicht(String email) 
        {
            return View(TicketRepository.GetTicketsByEmail(email));
        }

    }
}
