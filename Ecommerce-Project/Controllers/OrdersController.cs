using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationContext Context;

        public OrdersController(ApplicationContext _context)
        {
            Context = _context;
        }

        public IActionResult Index()
        {
            // Hämtar en lista över Order-objekt och inkludera de relaterade OrderItems och produkter.
            List<Order> orders = Context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToList();

            // Skicka listan till vyn.
            return View(orders);
        }

        public IActionResult Details(int orderId)
        {
            // Hämtar Order-objekt med id orderId och inkludera de relaterade OrderItems och produkter
            Order order = Context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.Id == orderId);

            return View(order);
        }
    }
}
