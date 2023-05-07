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
            List<Order> orders = Context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToList();

            return View(orders);
        }

        public IActionResult Details(int orderId)
        {
            Order order = Context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.Id == orderId);

            return View(order);
        }
    }
}
