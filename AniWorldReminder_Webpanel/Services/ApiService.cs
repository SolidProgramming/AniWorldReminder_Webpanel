using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;

namespace AniWorldReminder_Webpanel.Services
{
    public class ApiService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService) : IApiService
    {
        private readonly HttpClient? HttpClient = httpClient;
        private NavigationManager? NavigationManager = navigationManager;
        private ILocalStorageService? LocalStorageService = localStorageService;

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
        public async Task<T?> GetAsyncWithUserApiKey<T>(string uri)
        {
            string? apiKey = await GetAsync<string?>("/getAPIKey");

            HttpRequestMessage request = new(HttpMethod.Get, uri);
            request.Headers.Add("X-API-KEY", apiKey);

            return await SendRequest<T>(request);
        }
        public async Task<T?> GetAsyncWithApiKey<T>(string uri, string apiKey, string keyHeaderName = "X-API-KEY")
        {
            HttpRequestMessage request = new(HttpMethod.Get, uri);
            request.Headers.Add(keyHeaderName, apiKey);

            return await SendRequest<T>(request, true);
        }
        public async Task<T?> GetAsync<T>(string uri, Dictionary<string, string> queryData, object body)
        {
            HttpRequestMessage request = new(HttpMethod.Get, new Uri(QueryHelpers.AddQueryString(HttpClient.BaseAddress + uri, queryData!)))
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };
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
        public async Task<T?> PostAsync<T>(string uri, Dictionary<string, string> queryData, object body)
        {
            HttpRequestMessage request = new(HttpMethod.Post, new Uri(QueryHelpers.AddQueryString(HttpClient.BaseAddress + uri, queryData!)))
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };
            return await SendRequest<T>(request);
        }
        public async Task<T?> PostAsyncWithPlexClientIndentifier<T>(string uri, PlexUserModel user)
        {
            HttpRequestMessage request = new(HttpMethod.Post, uri);

            string guid = Guid.NewGuid().ToString().ToLower();

            request.Headers.Add("X-Plex-Client-Identifier", guid);


            string? authenticationString = $"{user.Email}:{user.Password}";
            string? base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            return await SendRequestWithPlexClientIndentifier<T>(request);
        }
        private async Task<T?> SendRequest<T>(HttpRequestMessage request, bool addThirdPartyApiKey = false)
        {
            UserModel? user = await LocalStorageService.GetItem<UserModel>("user");

            if (user != null && !string.IsNullOrEmpty(user.Token) && !addThirdPartyApiKey)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

            try
            {
                using HttpResponseMessage? response = await HttpClient.SendAsync(request);

                // auto logout on 401 response
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await LocalStorageService.RemoveItem("user");
                    NavigationManager.NavigateTo(Routes.Login);
                    return default;
                }

                // throw exception on error response
                if (!response.IsSuccessStatusCode)
                    return default;

                if (typeof(T) == typeof(bool))
                {
                    return (T)Convert.ChangeType(response.IsSuccessStatusCode, typeof(T));
                }

                if (response.Content.Headers.ContentLength == 0)
                    return default;

                return await response.Content.ReadFromJsonAsync<T?>();
            }
            catch (TaskCanceledException)
            {
                return default;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<T?> SendRequestWithPlexClientIndentifier<T>(HttpRequestMessage request)
        {
            try
            {
                using HttpResponseMessage? response = await HttpClient.SendAsync(request);

                // auto logout on 401 response
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return default;

                // throw exception on error response
                if (!response.IsSuccessStatusCode)
                    return default;

                if (typeof(T) == typeof(bool))
                {
                    return (T)Convert.ChangeType(response.IsSuccessStatusCode, typeof(T));
                }

                if (response.Content.Headers is null || response.Content.Headers.ContentType is null || response.Content.Headers.ContentLength == 0)
                    return default;

                if (response.Content.Headers.ContentType.MediaType == "application/xml")
                {
                    string xmlData = await response.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new(typeof(T));

                    using StringReader reader = new(xmlData);
                    return (T?)serializer.Deserialize(reader);
                }

                return await response.Content.ReadFromJsonAsync<T?>();
            }
            catch (TaskCanceledException)
            {
                return default;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
