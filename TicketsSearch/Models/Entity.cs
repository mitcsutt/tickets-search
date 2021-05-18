using System;
using Newtonsoft.Json;

namespace TicketsSearch.Models
{
    public class Entity<T>
    {
        [JsonProperty("_id")]
        public T Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
    public class Entity : Entity<int> { }
}
