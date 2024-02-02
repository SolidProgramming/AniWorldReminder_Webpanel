using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
     public class AddReminderRequestModel
    {
        [JsonPropertyName("seriesName")]
        public string SeriesName { get; set; }

        public StreamingPortal StreamingPortal { get; set; }

        public Language Language { get; set; }
    }
}
