namespace AniWorldReminder_Webpanel.Classes
{
    public class SeriesInfoModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SeasonCount { get; set; }
        public string? Path { get; set; }
        public string? CoverArtUrl { get; set; }
        public string? CoverArtBase64 { get; set; }
        public string? DirectLink { get; set; }
        public StreamingPortal StreamingPortal { get; set; }
        public List<SeasonModel> Seasons { get; set; } = new List<SeasonModel>();
        public Medium? AniListSearchMedia { get; set; }
        public TMDBSearchTVByIdModel? TMDBSearchTVById { get; set; }
    }
}
