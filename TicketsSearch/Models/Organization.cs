using Newtonsoft.Json;

namespace TicketsSearch.Models
{
    public class Organization : Entity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("domain_names")]
        public string[] DomainNames { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
        [JsonProperty("shared_tickets")]
        public bool SharedTickets { get; set; }
    }
}
