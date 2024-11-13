
namespace AniWorldReminder_Webpanel.Services
{
    public class AuthenticationService(IApiService apiService, ILocalStorageService localStorageService) : IAuthenticationService
    {
        public UserModel? User { get; private set; }

        public async Task Initialize()
        {
            User = await localStorageService.GetItemAsync<UserModel>(nameof(User));
        }

        public async Task Login(string username, string password)
        {
            JwtResponseModel? jwtResponse = await apiService.PostAsync<JwtResponseModel>("login", new UserModel() { Username = username, Password = password });

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

            await localStorageService.SetItemAsync(nameof(User), User);
        }

        public async Task Logout()
        {
            User = null;
            await localStorageService.RemoveItemAsync(nameof(User));
        }

        public async Task<string?> GetAPIKey()
        {
            return await apiService.GetAsync<string?>("/getAPIKey");
        }
    }
}
