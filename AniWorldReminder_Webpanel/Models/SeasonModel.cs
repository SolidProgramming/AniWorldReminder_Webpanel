namespace AniWorldReminder_Webpanel.Models
{
    public class SeasonModel
    {
        public int Id { get; set; }
        public int EpisodeCount { get; set; }
        public List<EpisodeModel> Episodes { get; set; } = new List<EpisodeModel>();
    }
}
