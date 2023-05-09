using Ecommerce_Project.Models;
using Ecommerce_Project.Models.ViewModels;
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
            // Hämtar en lista över Category-objekt och inkludera relaterade produkter och taggar.
            List<Category> categoriesProductsTags = Context.Categories.Include(c => c.Products).ThenInclude(p => p.Tags).ToList();

            return View(categoriesProductsTags);
        }

        // Egen vy för att visa valuta i euro.
        public IActionResult IndexEUR()
        {
            List<Category> categoriesWithProducts = Context.Categories.Include(c => c.Products).ThenInclude(p => p.Tags).ToList();

            return View(categoriesWithProducts);
        }

        public IActionResult Create()
        {
            // Hämtar en lista av alla kategorier och taggar för ge möjlighet att välja flera i drop-down menyer med checkboxes.
            CategoriesAndTags ShowCategoryAndTags = new CategoriesAndTags();
            ShowCategoryAndTags.Categories = Context.Categories.ToList();
            ShowCategoryAndTags.Tags = Context.Tags.ToList();
            return View(ShowCategoryAndTags);
        }

        [HttpPost]
        // Stränglistorna är till för att kunna skicka flera kategorier och taggar
        public IActionResult Create(List<string> categoryName, string Name, string Description, decimal Price, string ImgUrl, List<string> tagName)
        {
            // Skapa en ny produktinstans
            Product NewProduct = new Product();
            NewProduct.Name = Name;
            NewProduct.Description = Description;
            NewProduct.PriceSEK = Price;

            // Växla till euro med fast växelkurs
            NewProduct.PriceEUR = Price * 0.1m;

            NewProduct.ImgUrl = ImgUrl;
            NewProduct.Categories = new List<Category>();
            NewProduct.Tags = new List<Tag>();

            // Lägg till kategorin baserat på namn
            foreach (var name in categoryName)
            {
                var category = Context.Categories.FirstOrDefault(c => c.Name == name);
                if (category != null)
                {
                    NewProduct.Categories.Add(category);
                }
            }

            foreach (var name in tagName)
            {
                var tag = Context.Tags.FirstOrDefault(t => t.Name == name);
                if (tag != null)
                {
                    NewProduct.Tags.Add(tag);
                }
            }

            // Lägg till den nya produkten i databasen
            Context.Products.Add(NewProduct);
            Context.SaveChanges();

            return RedirectToAction("Create");
        }

        public IActionResult Details(int productId)
        {
            Product product = Context.Products.Include(c => c.Categories).FirstOrDefault(p => p.Id == productId);

            return View(product);
        }

        public IActionResult DetailsEUR(int productId)
        {
            Product product = Context.Products.FirstOrDefault(p => p.Id == productId);

            return View(product);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        // Lägg till kategorifunktion
        [HttpPost]
        public IActionResult AddCategory(string Name) 
        { 
            Category Newcategory = new Category();
            Newcategory.Name = Name;
            Context.Categories.Add(Newcategory);
            Context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult AddTags() 
        {
            return View();
        }

        // Lägg till tagsfunktion
        [HttpPost]
        public IActionResult AddTags(string name)
        {
            Tag NewTag = new Tag();
            NewTag.Name = name;
            Context.Tags.Add(NewTag);
            Context.SaveChanges();
            return RedirectToAction("Create");
        }

    }
}
