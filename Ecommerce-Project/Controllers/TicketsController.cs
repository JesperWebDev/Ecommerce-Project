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

        // Hämtar alla tickets från databasen och visar dem vyn.
        public IActionResult Index()
        {
            List<Ticket> tickets = Context.Tickets.ToList();
            return View(tickets);
        }

        // Visar en vy där användaren kan skapa en ny ticket.
        public IActionResult Create()
        {
            return View();
        }

        // Lägg till Ticket
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            Context.Add(ticket);
            Context.SaveChanges();
            return RedirectToAction("Create");
        }

        // Visar detaljer om en specifik Ticket baserat på ticketId
        public IActionResult Details(int ticketId)
        {
            Ticket ticket = Context.Tickets.Include(t => t.TicketMessages).FirstOrDefault(t => t.Id == ticketId);
            return View(ticket);
        }

        // Visar detaljer om en specifik Ticket och alla meddelanden som är kopplade till den, i en "admin-vy".
        public IActionResult DetailsAdmin(int ticketId)
        {
            Ticket ticket = Context.Tickets.Include(t => t.TicketMessages).FirstOrDefault(t => t.Id == ticketId);
            return View(ticket);
        }

        // Visar alla Tickets som är kopplade till en specifik användare (identifierad med email-adress).
        public IActionResult CustomerTickets(string email)
        {
            List<Ticket> tickets = Context.Tickets.Where(t => t.UserEmail == email).ToList();
            return View(tickets);
        }

        // Lägger till ett TicketMessage till en specifik Ticket (från en användare).
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

        // Lägger till ett TicketMessage till en specifik Ticket (från en "admin").
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
