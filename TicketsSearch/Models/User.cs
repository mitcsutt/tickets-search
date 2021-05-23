using Newtonsoft.Json;

namespace TicketsSearch.Models
{
    public class User : Entity
    {
        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
        }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("verified")]
        public bool Verified { get; set; }
        [JsonProperty("shared")]
        public bool Shared { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("last_login_at")]
        public string LastLoginAt { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
        [JsonProperty("organization_id")]
        public int? OrganizationId { get; set; }
        [JsonProperty("suspended")]
        public bool Suspended { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
