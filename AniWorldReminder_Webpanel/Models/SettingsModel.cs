namespace AniWorldReminder_Webpanel.Models
{
    public class SettingsModel
    {
        [JsonProperty("ApiUrl")]
        public string ApiUrl { get; set; } = default!;
    }
}
