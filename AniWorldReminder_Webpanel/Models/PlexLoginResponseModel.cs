
namespace AniWorldReminder_Webpanel.Models
{
    public class Roles
    {
        [JsonPropertyName("roles")]
        public List<string> Role { get; set; }
    }

    public class PlexLoginResponseModel
    {
        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    public class Subscription
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("features")]
        public List<string> Features { get; set; }
    }

    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("hasPassword")]
        public bool HasPassword { get; set; }

        [JsonPropertyName("authToken")]
        public string AuthToken { get; set; }

        [JsonPropertyName("authentication_token")]
        public string AuthenticationToken { get; set; }

        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; set; }

        [JsonPropertyName("roles")]
        public Roles Roles { get; set; }

        [JsonPropertyName("entitlements")]
        public List<string> Entitlements { get; set; }

        [JsonPropertyName("confirmedAt")]
        public DateTime ConfirmedAt { get; set; }

        [JsonPropertyName("forumId")]
        public object ForumId { get; set; }

        [JsonPropertyName("rememberMe")]
        public bool RememberMe { get; set; }
    }


}
