namespace AniWorldReminder_Webpanel.Models
{
    public class KnownFor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mediaType")]
        public string MediaType { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("genreIds")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("voteAverage")]
        public double VoteAverage { get; set; }

        [JsonProperty("voteCount")]
        public int VoteCount { get; set; }

        [JsonProperty("backdropPath")]
        public string BackdropPath { get; set; }

        [JsonProperty("posterPath")]
        public string PosterPath { get; set; }

        [JsonProperty("firstAirDate")]
        public string FirstAirDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("originCountry")]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("originalName")]
        public string OriginalName { get; set; }
    }

    public class MediaInfo
    {
        [JsonProperty("downloadStatus")]
        public List<object> DownloadStatus { get; set; }

        [JsonProperty("downloadStatus4k")]
        public List<object> DownloadStatus4k { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mediaType")]
        public string MediaType { get; set; }

        [JsonProperty("tmdbId")]
        public int TmdbId { get; set; }

        [JsonProperty("tvdbId")]
        public object TvdbId { get; set; }

        [JsonProperty("imdbId")]
        public object ImdbId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("status4k")]
        public int Status4k { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("lastSeasonChange")]
        public DateTime LastSeasonChange { get; set; }

        [JsonProperty("mediaAddedAt")]
        public DateTime? MediaAddedAt { get; set; }

        [JsonProperty("serviceId")]
        public object ServiceId { get; set; }

        [JsonProperty("serviceId4k")]
        public object ServiceId4k { get; set; }

        [JsonProperty("externalServiceId")]
        public object ExternalServiceId { get; set; }

        [JsonProperty("externalServiceId4k")]
        public object ExternalServiceId4k { get; set; }

        [JsonProperty("externalServiceSlug")]
        public object ExternalServiceSlug { get; set; }

        [JsonProperty("externalServiceSlug4k")]
        public object ExternalServiceSlug4k { get; set; }

        [JsonProperty("ratingKey")]
        public string RatingKey { get; set; }

        [JsonProperty("ratingKey4k")]
        public object RatingKey4k { get; set; }

        [JsonProperty("seasons")]
        public List<object> Seasons { get; set; }

        [JsonProperty("plexUrl")]
        public string PlexUrl { get; set; }

        [JsonProperty("iOSPlexUrl")]
        public string IOSPlexUrl { get; set; }
    }

    public class OverseerrResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mediaType")]
        public string MediaType { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("genreIds")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("voteAverage")]
        public double VoteAverage { get; set; }

        [JsonProperty("voteCount")]
        public int VoteCount { get; set; }

        [JsonProperty("backdropPath")]
        public string BackdropPath { get; set; }

        [JsonProperty("posterPath")]
        public string PosterPath { get; set; }

        [JsonProperty("mediaInfo")]
        public MediaInfo MediaInfo { get; set; }

        [JsonProperty("firstAirDate")]
        public string FirstAirDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("originCountry")]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("originalName")]
        public string OriginalName { get; set; }

        [JsonProperty("profilePath")]
        public string ProfilePath { get; set; }

        [JsonProperty("knownFor")]
        public List<KnownFor> KnownFor { get; set; }
    }

    public class OverseerrSearchResultModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("results")]
        public List<OverseerrResult> Results { get; set; }
    }

}
