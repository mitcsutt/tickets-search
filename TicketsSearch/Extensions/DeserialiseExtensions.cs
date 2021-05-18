using Newtonsoft.Json;
using TicketsSearch.Models;
namespace TicketsSearch.Extensions
{
    public static class DeserialiseExtensions
    {
        public static Organization[] DeserializeOrganizations(this string json)
        {
            return JsonConvert.DeserializeObject<Organization[]>(json);
        }
        public static Ticket[] DeserializeTickets(this string json)
        {
            return JsonConvert.DeserializeObject<Ticket[]>(json);
        }
        public static User[] DeserializeUsers(this string json)
        {
            return JsonConvert.DeserializeObject<User[]>(json);
        }
    }
}
