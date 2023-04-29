using Microsoft.AspNetCore.Mvc;
using Ecommerce_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationContext Context;

        public CartController(ApplicationContext _context)
        {
            Context = _context;
        }

        public IActionResult Index()
        {
            // Hämtar carts och cartitems. Endast testfunktion för att testa kundvagnen, måste ersättas.
            // Om någon byter databas ta bort c => c.Id == 1, kör programmet och gå till "kundvagnen". Sen när ni fått error lägg till koden igen så funkar det!
            Cart Cart = Context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.Id == 1);
            if (Cart == null)
            {
                Cart newCart = new Cart();
                Context.Carts.Add(newCart);
                Context.SaveChanges();
            }
            return View(Cart);
        }

        public IActionResult AddToCart()
        {
            // Forsätt här. Jesper har pseudokod
            return View();
        }
    }
}
