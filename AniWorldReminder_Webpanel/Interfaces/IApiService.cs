namespace AniWorldReminder_Webpanel.Interfaces
{
    public interface IApiService
    {
        Task<(bool success, string? errorMessage)> VerifyAsync(VerifyRequestModel verifyRequest);
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
    }
}
