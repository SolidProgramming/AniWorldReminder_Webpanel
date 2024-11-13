using System.ComponentModel.DataAnnotations;

namespace AniWorldReminder_Webpanel.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Benutzername fehlt!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Passwort fehlt!")]
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
