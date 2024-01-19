namespace AniWorldReminder_Webpanel.Interfaces
{
    public interface IApiService
    {
        Task<(bool success, string? errorMessage)> VerifyAsync(VerifyRequestModel verifyRequest);
        Task<T?> GetAsync<T>(string uri);
        Task<T?> GetAsync<T>(string uri, Dictionary<string, string> queryData, object body);
        Task<T?> GetAsync<T>(string uri, Dictionary<string, string> queryData);
        Task<T?> PostAsync<T>(string uri, object value);
        Task<bool> PostAsync(string uri, object value);
    }
}
