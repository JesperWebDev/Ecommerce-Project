using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationContext _context;

        public CheckoutController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // Spara beställningen till databasen
                _context.Orders.Add(order);
                _context.SaveChanges();

                // Skicka kunden till startsidan om allt går igenom
                return RedirectToAction("Index", "Home");


            }

            // Visa kassa sidan igen om något går fel.
            return View("Checkout", order);
        }
    }
}
