namespace Ecommerce_Project.Models
{
    public class TicketMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TicketId { get; set; }
        public bool IsAdmin { get; set; }
        public Ticket Ticket { get; set; }
    }
}
