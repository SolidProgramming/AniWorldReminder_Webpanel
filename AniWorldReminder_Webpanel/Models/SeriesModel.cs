﻿namespace AniWorldReminder_Webpanel.Models
{
    public class SeriesModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CoverArtUrl { get; set; }
        public string? CoverArtBase64 { get; set; }
        public StreamingPortal StreamingPortal { get; set; }
        public Language LanguageFlag { get; set; }
        public bool IsSearchResult = false;
        public string? Link { get; set; }
        public string? Path { get; set; }
    }
}
