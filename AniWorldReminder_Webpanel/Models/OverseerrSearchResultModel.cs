using System.Text.Json.Serialization;

namespace AniWorldReminder_Webpanel.Models
{
    public class KnownFor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }

        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("genreIds")]
        public List<int> GenreIds { get; set; }

        [JsonPropertyName("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonPropertyName("voteAverage")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("voteCount")]
        public int VoteCount { get; set; }

        [JsonPropertyName("backdropPath")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("posterPath")]
        public string PosterPath { get; set; }

        [JsonPropertyName("firstAirDate")]
        public string FirstAirDate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("originCountry")]
        public List<string> OriginCountry { get; set; }

        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }
    }

    public class MediaInfo
    {
        [JsonPropertyName("downloadStatus")]
        public List<object> DownloadStatus { get; set; }

        [JsonPropertyName("downloadStatus4k")]
        public List<object> DownloadStatus4k { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }

        [JsonPropertyName("tmdbId")]
        public int TmdbId { get; set; }

        [JsonPropertyName("tvdbId")]
        public object TvdbId { get; set; }

        [JsonPropertyName("imdbId")]
        public object ImdbId { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("status4k")]
        public int Status4k { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("lastSeasonChange")]
        public DateTime LastSeasonChange { get; set; }

        [JsonPropertyName("mediaAddedAt")]
        public DateTime? MediaAddedAt { get; set; }

        [JsonPropertyName("serviceId")]
        public object ServiceId { get; set; }

        [JsonPropertyName("serviceId4k")]
        public object ServiceId4k { get; set; }

        [JsonPropertyName("externalServiceId")]
        public object ExternalServiceId { get; set; }

        [JsonPropertyName("externalServiceId4k")]
        public object ExternalServiceId4k { get; set; }

        [JsonPropertyName("externalServiceSlug")]
        public object ExternalServiceSlug { get; set; }

        [JsonPropertyName("externalServiceSlug4k")]
        public object ExternalServiceSlug4k { get; set; }

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("ratingKey4k")]
        public object RatingKey4k { get; set; }

        [JsonPropertyName("seasons")]
        public List<object> Seasons { get; set; }

        [JsonPropertyName("plexUrl")]
        public string PlexUrl { get; set; }

        [JsonPropertyName("iOSPlexUrl")]
        public string IOSPlexUrl { get; set; }
    }

    public class OverseerrResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }

        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("genreIds")]
        public List<int> GenreIds { get; set; }

        [JsonPropertyName("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonPropertyName("voteAverage")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("voteCount")]
        public int VoteCount { get; set; }

        [JsonPropertyName("backdropPath")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("posterPath")]
        public string PosterPath { get; set; }

        [JsonPropertyName("mediaInfo")]
        public MediaInfo MediaInfo { get; set; }

        [JsonPropertyName("firstAirDate")]
        public string FirstAirDate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("originCountry")]
        public List<string> OriginCountry { get; set; }

        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }

        [JsonPropertyName("profilePath")]
        public string ProfilePath { get; set; }

        [JsonPropertyName("knownFor")]
        public List<KnownFor> KnownFor { get; set; }
    }

    public class OverseerrSearchResultModel
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("results")]
        public List<OverseerrResult> Results { get; set; }
    }

}
