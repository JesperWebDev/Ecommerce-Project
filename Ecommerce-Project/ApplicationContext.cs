using Ecommerce_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project
{
    public class ApplicationContext : DbContext
        //Test
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category
				{
					Id = -1,
					Name = "flower"
				},
				new Category
				{
					Id = -2,
					Name = "bouquet"
				});
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = -1,
					Name = "lily001",
					Description = "lily001",
					Price = 100,
					ImgUrl = "https://images.pexels.com/photos/132466/pexels-photo-132466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Product
				{
					Id = -2,
					Name = "lily002",
					Description = "lily002",
					Price = 200,
					ImgUrl = "https://images.pexels.com/photos/65031/pexels-photo-65031.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Product
				{
					Id = -3,
					Name = "white spider lily001",
					Description = "spider lily001",
					Price = 2000,
					ImgUrl = "https://cdn.pixabay.com/photo/2023/04/16/02/11/spider-lily-7928877_960_720.jpg"
				},
				new Product
				{
					Id = -4,
					Name = "red spider lily002",
					Description = "spider lily002",
					Price = 2000,
					ImgUrl = "https://images.rawpixel.com/image_1000/cHJpdmF0ZS9zdGF0aWMvaW1hZ2Uvd2Vic2l0ZS8yMDIyLTA0L2xyL3B4MTU5NTYzNy1pbWFnZS1rd3Z2cGlqMS5qcGc.jpg"
				},
				new Product
				{
					Id = -5,
					Name = "red rose 001",
					Description = "rose 001",
					Price = 300,
					ImgUrl = "https://www.stockvault.net/data/2007/03/01/99607/preview16.jpg"
				},
				new Product
				{
					Id = -6,
					Name = "white rose 002",
					Description = "rose 002",
					Price = 300,
					ImgUrl = "https://www.stockvault.net/data/2007/03/01/100311/preview16.jpg"
				},
				new Product
				{
					Id = -7,
					Name = "red flower bouquet 001",
					Description = "bouquet 001",
					Price = 800,
					ImgUrl = "https://images.unsplash.com/photo-1561181286-d3fee7d55364?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"
				},
				new Product
				{
					Id = -8,
					Name = "pink flower bouquet 002",
					Description = "bouquet 002",
					Price = 900,
					ImgUrl = "https://images.unsplash.com/photo-1561181226-e8a7edd504c6?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"
				},
				new Product
				{
					Id = -9,
					Name = "colorfull flower bouquet 003",
					Description = "bouquet 003",
					Price = 700,
					ImgUrl = "https://images.unsplash.com/photo-1580316008590-43d5fb8cc3cd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"
				});
			modelBuilder.Entity<Product>()
				.HasMany(x => x.Categories)
				.WithMany(x => x.Products)
				.UsingEntity<Dictionary<string, object>>(
					"CategoryProduct",
					l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
					r => r.HasOne<Product>().WithMany().HasForeignKey("ProductsId"),
					j =>
					{
						j.HasKey("CategoriesId", "ProductsId");
						j.HasData(
							new { CategoriesId = -1, ProductsId = -1 },
							new { CategoriesId = -1, ProductsId = -2 },
							new { CategoriesId = -1, ProductsId = -3 },
							new { CategoriesId = -1, ProductsId = -4 },
							new { CategoriesId = -1, ProductsId = -5 },
							new { CategoriesId = -1, ProductsId = -6 },
							new { CategoriesId = -2, ProductsId = -7 },
							new { CategoriesId = -2, ProductsId = -8 },
							new { CategoriesId = -2, ProductsId = -9 });
					});
			modelBuilder.Entity<Cart>()
				.HasData(new { Id = 1, });
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
    }
}
