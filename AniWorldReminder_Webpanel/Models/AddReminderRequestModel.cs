using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
     public class AddReminderRequestModel
    {
        [JsonPropertyName("seriesPath")]
        public string? SeriesPath { get; set; }

        public StreamingPortal StreamingPortal { get; set; }

        public Language Language { get; set; }
    }
}
