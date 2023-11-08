namespace AniWorldReminder_Webpanel.Interfaces
{
    public interface IAuthenticationService
    {
        UserModel User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}
