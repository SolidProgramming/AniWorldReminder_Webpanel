using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
     public class AddReminderRequestModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("seriesName")]
        public string SeriesName { get; set; }
    }
}
