using Ecommerce_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Cart>().HasData(new Cart { Id = 1 });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Herrkläder" },
                new Category { Id = 2, Name = "Damkläder" },
                new Category { Id = 3, Name = "Accessoarer" });

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "VÅRREA" },
                new Tag { Id = 2, Name = "Höstmode" },
                new Tag { Id = 3, Name = "Fest" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Kavaj", Description = "Snygg kavaj för herr", PriceSEK = 999, PriceEUR = 99.9m, ImgUrl = "https://via.placeholder.com/300x200" },
                new Product { Id = 2, Name = "Klänning", Description = "Elegant klänning för dam", PriceSEK = 899, PriceEUR = 89.9m, ImgUrl = "https://via.placeholder.com/300x200" },
                new Product { Id = 3, Name = "Skärp", Description = "Snyggt skärp i läder", PriceSEK = 299, PriceEUR = 29.9m, ImgUrl = "https://via.placeholder.com/300x200" },
                new Product { Id = 4, Name = "Shorts", Description = "Dessa snygga herrshorts är perfekta för en avslappnad sommarstil.", PriceSEK = 799, PriceEUR = 79.9m, ImgUrl = "https://via.placeholder.com/300x200" });

            modelBuilder.Entity("CategoryProduct").HasData(
                new { CategoriesId = 1, ProductsId = 1 },
                new { CategoriesId = 2, ProductsId = 2 },
                new { CategoriesId = 3, ProductsId = 3 },
                new { CategoriesId = 1, ProductsId = 3 },
                new { CategoriesId = 1, ProductsId = 4 });

            modelBuilder.Entity("ProductTag").HasData(
                new { ProductsId = 1, TagsId = 2 },
                new { ProductsId = 1, TagsId = 3 },
                new { ProductsId = 2, TagsId = 3 },
                new { ProductsId = 3, TagsId = 1 },
                new { ProductsId = 4, TagsId = 2 });
        }
    }


}
