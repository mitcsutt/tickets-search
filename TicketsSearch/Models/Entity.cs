using System;
namespace TicketsSearch.Models
{
    public class Entity
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string ExternalId { get; set; }
        public string[] Tags { get; set; }
        public string CreatedAt { get; set; }
    }
}
