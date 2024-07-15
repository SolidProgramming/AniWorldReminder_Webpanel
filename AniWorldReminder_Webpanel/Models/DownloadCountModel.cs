using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
    public class DownloadCountModel
    {
        [JsonPropertyName("downloadsCount")]
        public int DownloadsCount { get; set; }
    }
}
