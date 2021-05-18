using Newtonsoft.Json;

namespace TicketsSearch.Models
{
    public class Ticket : Entity<string>
    {
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
        public string AssigneeId { get; set; }
        [JsonProperty("organization_id")]
        public int OrganisationId { get; set; }
        [JsonProperty("has_incidents")]
        public string HasIncidents { get; set; }
        [JsonProperty("due_at")]
        public string DueAt { get; set; }
        [JsonProperty("via")]
        public string Via { get; set; }
    }
}
