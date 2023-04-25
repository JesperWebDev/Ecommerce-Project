using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationContext Context;

        public ProductsController(ApplicationContext _context)
        {
            Context = _context;
        }

        public IActionResult Index()
        {
            List<Product> Products = Context.Products.Include(p => p.Categories).ToList();
            return View(Products);
        }

        public IActionResult Create()
        {
            List<Category> Categories = Context.Categories.ToList();
            return View(Categories);
        }

        [HttpPost]
        public IActionResult Create(string categoryName, string Name, string Description, decimal Price, string ImgUrl)
        {
            // Skapa en ny produktinstans

            Product NewProduct = new Product();
            NewProduct.Name = Name;
            NewProduct.Description = Description;
            NewProduct.Price = Price;
            NewProduct.ImgUrl = ImgUrl;
            NewProduct.Categories = new List<Category>();


            // Lägg till kategorin baserat på id
            Category category = Context.Categories.FirstOrDefault(c => c.Name == categoryName);
            Console.WriteLine(categoryName + "TESTING KATEGORIID HEEEEEJ");
            if (category != null)
            {
                NewProduct.Categories.Add(category);
            }

            // Lägg till den nya produkten i databasen
            Context.Products.Add(NewProduct);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
