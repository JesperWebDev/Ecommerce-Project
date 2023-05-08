using Microsoft.AspNetCore.Mvc;
using Ecommerce_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationContext Context;

        public TicketsController(ApplicationContext _context)
        {
            Context = _context;
        }
        public IActionResult Index()
        {
            List<Ticket> tickets = Context.Tickets.ToList();
            return View(tickets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            Context.Add(ticket);
            Context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult Details(int ticketId)
        {
            Ticket ticket = Context.Tickets.Include(t => t.TicketMessages).FirstOrDefault(t => t.Id == ticketId);
            return View(ticket);
        }

        public IActionResult DetailsAdmin(int ticketId)
        {
            Ticket ticket = Context.Tickets.Include(t => t.TicketMessages).FirstOrDefault(t => t.Id == ticketId);
            return View(ticket);
        }

        public IActionResult CustomerTickets(string email)
        {
            List<Ticket> tickets = Context.Tickets.Where(t => t.UserEmail == email).ToList();
            return View(tickets);
        }

        [HttpPost]
        public IActionResult AddTicketMessageUser (int TicketId, string Text)
        {
            TicketMessage newMessage = new TicketMessage();
            newMessage.TicketId = TicketId;
            newMessage.Text = Text;
            newMessage.IsAdmin = false;
            Context.TicketMessages.Add(newMessage);
            Context.SaveChanges();

            return RedirectToAction("Details", newMessage);
        }

        [HttpPost]
        public IActionResult AddTicketMessageAdmin(int TicketId, string Text)
        {
            TicketMessage newMessage = new TicketMessage();
            newMessage.TicketId = TicketId;
            newMessage.Text = Text;
            newMessage.IsAdmin = true;
            Context.TicketMessages.Add(newMessage);
            Context.SaveChanges();

            return RedirectToAction("DetailsAdmin", newMessage);
        }

    }
}
