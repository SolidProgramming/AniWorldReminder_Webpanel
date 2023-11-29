using Microsoft.AspNetCore.Components;

namespace AniWorldReminder_Webpanel.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApiService ApiService;
        private NavigationManager NavigationManager;
        private ILocalStorageService LocalStorageService;

        public UserModel? User { get; private set; }

        public AuthenticationService(IApiService apiService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            ApiService = apiService;
            NavigationManager = navigationManager;
            LocalStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await LocalStorageService.GetItem<UserModel>("user");            
        }

        public async Task Login(string username, string password)
        {
            JwtResponseModel jwtResponse = await ApiService.PostAsync<JwtResponseModel>("login", new UserModel() { Username = username, Password = password });

            if (jwtResponse is null || string.IsNullOrEmpty(jwtResponse.Token))
            {
                User = null;
                return;
            }

            User = new UserModel()
            { 
                Token = jwtResponse.Token,
                Username = username
            };

            await LocalStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await LocalStorageService.RemoveItem("user");
        }
    }
}
