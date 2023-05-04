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
            List<Product> Products = Context.Products.Include(p => p.Categories).ToList();
            return View(Products);
        }

        public IActionResult Create()
        {
            
            CategoriesAndTags ShowCategoryAndTags = new CategoriesAndTags();
            ShowCategoryAndTags.Categories = Context.Categories.ToList();
            ShowCategoryAndTags.Tags = Context.Tags.ToList();
            return View(ShowCategoryAndTags);
        }

        [HttpPost]
        public IActionResult Create(List<string> categoryName, string Name, string Description, decimal Price, string ImgUrl, List<string> tagName)
        {
            // Skapa en ny produktinstans

            Product NewProduct = new Product();
            NewProduct.Name = Name;
            NewProduct.Description = Description;
            NewProduct.Price = Price;
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

        public IActionResult AddCategory()
        {
            return View();
        }


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
