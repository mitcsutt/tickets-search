using Newtonsoft.Json;

namespace TicketsSearch.Models
{
    public class Ticket : Entity<string>
    {
        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
        }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("priority")]
        public string Priority { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("submitter_id")]
        public int SubmitterId { get; set; }
        [JsonProperty("assignee_id")]
        public int? AssigneeId { get; set; }
        [JsonProperty("organization_id")]
        public int? OrganizationId { get; set; }
        [JsonProperty("has_incidents")]
        public bool HasIncidents { get; set; }
        [JsonProperty("due_at")]
        public string DueAt { get; set; }
        [JsonProperty("via")]
        public string Via { get; set; }
    }
}
