namespace AniWorldReminder_Webpanel.Models
{
    public class OverseerrLoginResponseModel
    {        public int permissions { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string plexUsername { get; set; }
        public object username { get; set; }
        public object recoveryLinkExpirationDate { get; set; }
        public int userType { get; set; }
        public int plexId { get; set; }
        public string avatar { get; set; }
        public object movieQuotaLimit { get; set; }
        public object movieQuotaDays { get; set; }
        public object tvQuotaLimit { get; set; }
        public object tvQuotaDays { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object settings { get; set; }
        public int requestCount { get; set; }
        public string displayName { get; set; }
    }
}
