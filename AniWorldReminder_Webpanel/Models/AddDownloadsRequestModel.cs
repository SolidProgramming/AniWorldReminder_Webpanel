namespace AniWorldReminder_Webpanel.Models
{
    public class AddDownloadsRequestModel
    {
        public string? SeriesId { get; set; }
        public List<EpisodeModel>? Episodes { get; set; }
    }
}
