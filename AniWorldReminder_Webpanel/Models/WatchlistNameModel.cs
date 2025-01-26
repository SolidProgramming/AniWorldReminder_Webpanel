using System.ComponentModel.DataAnnotations;

namespace AniWorldReminder_Webpanel.Models
{
    public class WatchlistNameModel
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 25;

        [Required(ErrorMessage = "Bitte einen Namen angeben")]
        [MinLength(MinNameLength, ErrorMessage = "Mindestlänge beträgt 5")]
        [MaxLength(MaxNameLength, ErrorMessage = "Maximallänge beträgt 25")]
        public string WatchlistName { get; set; } = "";
    }
}
