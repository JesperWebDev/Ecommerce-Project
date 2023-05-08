namespace Ecommerce_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DeliveryAdress { get; set; }
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string CVC { get; set; }
        public decimal TotalPriceSEK { get; set; }
        public decimal TotalPriceEUR { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
