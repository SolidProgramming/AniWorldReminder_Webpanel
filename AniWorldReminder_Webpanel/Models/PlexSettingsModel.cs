using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
    public class PlexSettingsModel
    {
        public PlexUserModel User { get; set; } = new();
    }
}
