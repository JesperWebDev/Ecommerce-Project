namespace Ecommerce_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeliveryAdress { get; set; }
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string CVC { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
