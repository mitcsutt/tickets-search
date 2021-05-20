using System.Collections.Generic;
namespace TicketsSearch.Models
{
    public class OrganizationDictionaryValues
    {
        public Organization Entity;
        public List<Ticket> Tickets;
        public List<User> Users;
    }
    public class TicketDictionaryValues
    {
        public Ticket Entity;
        public List<Organization> Organizations;
        public List<User> SubmitterUsers;
        public List<User> AssignedUsers;
    }
    public class UserDictionaryValues
    {
        public User Entity;
        public List<Organization> Organizations;
        public List<Ticket> SubmittedTickets;
        public List<Ticket> AssignedTickets;
    }
}
