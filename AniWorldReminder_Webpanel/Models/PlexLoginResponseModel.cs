
namespace AniWorldReminder_Webpanel.Models
{
    public class Roles
    {
        [JsonProperty("roles")]
        public List<string> Role { get; set; }
    }

    public class PlexLoginResponseModel
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class Subscription
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("hasPassword")]
        public bool HasPassword { get; set; }

        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [JsonProperty("authentication_token")]
        public string AuthenticationToken { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("roles")]
        public Roles Roles { get; set; }

        [JsonProperty("entitlements")]
        public List<string> Entitlements { get; set; }

        [JsonProperty("confirmedAt")]
        public DateTime ConfirmedAt { get; set; }

        [JsonProperty("forumId")]
        public object ForumId { get; set; }

        [JsonProperty("rememberMe")]
        public bool RememberMe { get; set; }
    }


}
