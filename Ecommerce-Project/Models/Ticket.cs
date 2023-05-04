namespace Ecommerce_Project.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }
        public List <TicketMessage> TicketMessages { get; set; }

    }
}
