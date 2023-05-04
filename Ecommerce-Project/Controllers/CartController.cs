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

        // Testmetoder för kundvagnen, ERSÄTT ID 1 SENARE.

        public IActionResult Index()
        {
            // Hämtar cart med id 1 och tillhörande cartitems och produkter. Produkter nås via relationen i CartItems
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(p => p.Product).FirstOrDefault();

            // Skapar cart om den inte finns
            if (cart == null)
            {
                Cart newCart = new Cart();
                Context.Carts.Add(newCart);
                Context.SaveChanges();
            }
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            // Hämtar Cart från databasen med id 1 (detta behöver vi ändra till userid/session eller liknande)
            Cart cart = Context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.Id == 1);

            // Hämtar CartItem från Cart baserat på productId
            CartItem cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);

            // Undersöker om cartItem redan finns i kundvagnen
            if (cartItem != null)
            {
                // Ökar mängden av en befintlig produkt i kundvagnen om den redan finns och uppdaterar i databasen
                cartItem.Quantity += quantity;
                Context.Update(cartItem);
                Context.SaveChanges();
                Console.WriteLine("TESTING!!!" + cartItem.Quantity);
            }
            else
            {
                // Skapar ett nytt CartItem-objekt, tilldelar egenskaperna och lägger till det i kundvagnen i databasen.
                cartItem = new CartItem();
                cartItem.ProductId = productId;
                cartItem.Quantity = quantity;
                cartItem.CartId = cart.Id;
                cart.CartItems.Add(cartItem);
                Context.SaveChanges();
            }
            // Returnerar inte cart här eftersom vi vill visa produktvyn
            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public IActionResult DeleteCartItem(int removeId)
        {
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.Id == 1);
            CartItem cartItem = cart.CartItems.FirstOrDefault(c => c.Id == removeId);

            Context.CartItems.Remove(cartItem);
            Context.SaveChanges();

            // Indexvyn i Cart använder modellen Cart
            return View("Index", cart); 
        }

        [HttpPost]
        public IActionResult EmptyCart (int emptyCart)
        {
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.Id == emptyCart);

            // Skapar en lista med alla cartitems som tillhör den kundvagn med id emptyCart.
            List<CartItem> cartItem = cart.CartItems.ToList();

            // Loopar över listan och tar bort dom från databasen
            foreach (CartItem item in cartItem)
            {
                Context.CartItems.Remove(item);
            }
            Context.SaveChanges();
            return View("Index", cart);
        }

        // Incrementsmetod som används direkt i kundvagnsvyn (+)
        [HttpPost]
        public IActionResult IncrementProductInCart(int productId)
        {
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.Id == 1);
            CartItem cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);

            // Öka med 1 och uppdaterar databasen
            cartItem.Quantity ++;
            Context.Update(cartItem);
            Context.SaveChanges();
            return View("Index", cart);
        }

        // Decrementsmetod som används direkt i kundvagnsvyn (-)
        [HttpPost]
        public IActionResult DecrementProductInCart(int productId)
        {
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.Id == 1);
            CartItem cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);

            // Minskar med 1 och uppdaterar databasen
            cartItem.Quantity--;
            Context.Update(cartItem);
            Context.SaveChanges();
            return View("Index", cart);
        }
    }
}
