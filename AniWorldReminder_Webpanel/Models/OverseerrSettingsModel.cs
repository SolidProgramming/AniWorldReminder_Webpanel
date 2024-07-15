using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
    public class OverseerrSettingsModel
    {
        public TransportProtocol Protocol { get; set; }

        [Required(ErrorMessage = "Host/IP fehlt!")]
        [JsonPropertyName("hostOrIp")]
        public string? HostOrIp { get; set; }
        [JsonPropertyName("port")]
        public int Port { get; set; } = 5055;

        [Required(ErrorMessage = "Api-Key fehlt!")]
        [JsonPropertyName("apiKey")]
        public string? ApiKey { get; set; }
    }
}
