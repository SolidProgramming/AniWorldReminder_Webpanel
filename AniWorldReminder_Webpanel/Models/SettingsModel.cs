namespace AniWorldReminder_Webpanel.Models
{
    public class SettingsModel
    {
        [JsonPropertyName("ApiUrl")]
        public string ApiUrl { get; set; } = default!;
    }
}
