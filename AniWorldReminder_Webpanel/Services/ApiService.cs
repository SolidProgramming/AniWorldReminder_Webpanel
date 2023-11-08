using AniWorldReminder_Webpanel.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AniWorldReminder_Webpanel.Services
{
    public class ApiService : IApiService
    {
        private HttpClient HttpClient;
        private NavigationManager NavigationManager;
        private ILocalStorageService LocalStorageService;


        public ApiService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            HttpClient = httpClient;
            NavigationManager = navigationManager;
            LocalStorageService = localStorageService;
        }

        public async Task<(bool success, string? errorMessage)> VerifyAsync(VerifyRequestModel verifyRequest)
        {
            using HttpResponseMessage response = await HttpClient.PostAsJsonAsync("verify", verifyRequest);

            if (!response.IsSuccessStatusCode)
                return (false, $"Server returned {response.StatusCode}");

            string content = await response.Content.ReadAsStringAsync();

            return (true, content);
        }

        public async Task<T> Get<T>(string uri)
        {
            HttpRequestMessage request = new(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            HttpRequestMessage request = new(HttpMethod.Post, uri)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };
            return await SendRequest<T>(request);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            UserModel? user = await LocalStorageService.GetItem<UserModel>("user");
            bool isApiUrl = !request.RequestUri.IsAbsoluteUri;

            if (user != null && isApiUrl)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

            using HttpResponseMessage? response = await HttpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //NavigationManager.NavigateTo("logout");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
