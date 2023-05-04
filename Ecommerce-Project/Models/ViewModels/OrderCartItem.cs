namespace Ecommerce_Project.Models.ViewModels
{
    public class OrderCartItem
    {
        public Order Order { get; set; }
        public List<CartItem> CartItems { get; set; }
        public int CartId { get; set; }
    }
}
