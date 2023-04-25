namespace Ecommerce_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }

    }
}

