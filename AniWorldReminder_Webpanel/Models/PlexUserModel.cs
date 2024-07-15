using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
    public class PlexUserModel
    {
        [Required(ErrorMessage = "Email fehlt!")]
        [JsonPropertyName("login")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Passwort fehlt!")]
        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
