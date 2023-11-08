using Microsoft.AspNetCore.Components;

namespace AniWorldReminder_Webpanel.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApiService ApiService;
        private NavigationManager NavigationManager;
        private ILocalStorageService LocalStorageService;

        public UserModel User { get; private set; }

        public AuthenticationService(IApiService apiService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            ApiService = apiService;
            NavigationManager = navigationManager;
            LocalStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await LocalStorageService.GetItem<UserModel>("user");
            await Console.Out.WriteLineAsync(User.Username);
        }

        public async Task Login(string username, string password)
        {
            User = await ApiService.Post<UserModel>("login", new UserModel() { Username = username, Password = password });
            await LocalStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await LocalStorageService.RemoveItem("user");
            NavigationManager.NavigateTo("login");
        }
    }
}
