using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
    public class AutoDLClientSettingsModel
    {
        [JsonPropertyName("ApiUrl")]
        public string ApiUrl { get; set; } = default!;

        [JsonPropertyName("APIKey")]
        public string? ApiKey { get; set; }

        [JsonPropertyName("DownloadPath")]
        public string? DownloadPath { get; set; } = default!;
    }
}
