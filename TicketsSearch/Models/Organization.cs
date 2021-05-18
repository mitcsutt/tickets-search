namespace TicketsSearch.Models
{
    public class Organization : Entity
    {
        public string Name { get; set; }
        public string DomainNames { get; set; }
        public string Details { get; set; }
        public bool SharedTickets { get; set; }
    }
}
