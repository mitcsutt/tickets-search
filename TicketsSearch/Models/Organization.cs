using System.Collections.Generic;
using Newtonsoft.Json;

namespace TicketsSearch.Models
{
    public class Organization : Entity
    {
        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
        }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("domain_names")]
        public List<string> DomainNames { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
        [JsonProperty("shared_tickets")]
        public bool SharedTickets { get; set; }
    }
}
