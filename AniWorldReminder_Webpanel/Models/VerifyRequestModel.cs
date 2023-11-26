using System.ComponentModel.DataAnnotations;

namespace AniWorldReminder_Webpanel.Models
{
    public class VerifyRequestModel
    {
        [Required(ErrorMessage = "Bitte ein Passwort festlegen")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Bitte einen Benutzernamen festlegen")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Bitte den Verifizierungstoken angeben")]
        public string? VerifyToken { get; set; }
    }
}
