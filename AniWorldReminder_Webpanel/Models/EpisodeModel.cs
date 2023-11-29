﻿namespace AniWorldReminder_Webpanel.Models
{
    public class EpisodeModel
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public string? Name { get; set; }
        public Language Languages { get; set; }
    }
}
