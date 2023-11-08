namespace AniWorldReminder_Webpanel.Interfaces
{
    public interface IApiService
    {
        //Task<List<SeriesInfoModel>?> GetSeriesInfoAsync(string seriesName);
        Task<(bool success, string? errorMessage)> VerifyAsync(VerifyRequestModel verifyRequest);
        Task<(bool success, string? errorMessage)> Login(string username, string password);
    }
}
