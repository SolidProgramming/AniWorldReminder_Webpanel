using AniWorldReminder_Webpanel.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;

namespace AniWorldReminder_Webpanel.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient HttpClient;
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

        public async Task<T?> GetAsync<T>(string uri)
        {
            HttpRequestMessage request = new(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }
        public async Task<T?> GetAsync<T>(string uri, Dictionary<string, string> queryData)
        {
            HttpRequestMessage request = new(HttpMethod.Get, new Uri(QueryHelpers.AddQueryString(HttpClient.BaseAddress + uri, queryData!)));
            return await SendRequest<T>(request);
        }

        public async Task<T?> PostAsync<T>(string uri, object value)
        {
            HttpRequestMessage request = new(HttpMethod.Post, uri)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };
            return await SendRequest<T>(request);
        }

        public async Task<bool> PostAsync(string uri, object value)
        {
            HttpRequestMessage request = new(HttpMethod.Post, uri)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };
            return await SendRequest<bool>(request);
        }

        private async Task<T?> SendRequest<T>(HttpRequestMessage request)
        {
            UserModel? user = await LocalStorageService.GetItem<UserModel>("user");

            if (user != null && !string.IsNullOrEmpty(user.Token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

            using HttpResponseMessage? response = await HttpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                NavigationManager.NavigateTo("login");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
                return default;

            if (typeof(T) == typeof(bool))
            {
                return (T)Convert.ChangeType(response.IsSuccessStatusCode, typeof(T));
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
