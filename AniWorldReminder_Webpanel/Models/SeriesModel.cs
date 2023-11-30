namespace AniWorldReminder_Webpanel.Models
{
    public class SeriesModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CoverArtUrl { get; set; }
        public StreamingPortalModel? StreamingPortal { get; set; }
    }
}
