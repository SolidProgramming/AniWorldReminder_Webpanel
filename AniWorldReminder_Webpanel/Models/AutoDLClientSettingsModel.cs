namespace AniWorldReminder_Webpanel.Models
{
    public class AutoDLClientSettingsModel
    {
        [JsonProperty("ApiUrl")]
        public string ApiUrl { get; set; } = default!;

        [JsonProperty("APIKey")]
        public string? ApiKey { get; set; }

        [JsonProperty("DownloadPath")]
        public string? DownloadPath { get; set; } = default!;
    }
}
