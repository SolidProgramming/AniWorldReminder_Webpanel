using System.Net.Http.Headers;

namespace AniWorldReminder_Webpanel.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient HttpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            HttpClient = httpClientFactory.CreateClient("apiclient");
            Console.WriteLine(HttpClient.BaseAddress);
        }

        public async Task<(bool success, string? errorMessage)> VerifyAsync(VerifyRequestModel verifyRequest)
        {
            using HttpResponseMessage response = await HttpClient.PostAsJsonAsync("verify", verifyRequest);

            if (!response.IsSuccessStatusCode)
                return (false, $"Server returned {response.StatusCode}");

            string content = await response.Content.ReadAsStringAsync();

            return (true, content);
        }

        public async Task<(bool success, string? errorMessage)> Login(string username, string password)
        {
            using HttpRequestMessage requestMessage = new(HttpMethod.Post, Endpoints.Login);

            requestMessage.Headers.Add("username", username);
            requestMessage.Headers.Add("password", password);

            HttpResponseMessage? response = await HttpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
                return (false, $"Server returned {response.StatusCode}");

            string json = await response.Content.ReadAsStringAsync();

            TokenResponseModel? tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(json);

            if (tokenResponse is null || string.IsNullOrEmpty(tokenResponse.Token))
                return (false, "Could not create token");

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.Token);

            return (true, null);
        }
    }
}
