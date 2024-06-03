using Microsoft.JSInterop;

namespace AniWorldReminder_Webpanel.Services
{
    public class LocalStorageService(IJSRuntime jsRuntime) : ILocalStorageService
    {
        public async Task<T?> GetItem<T>(string key)
        {
            try
            {
                string? json = await jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

                if (json is null)
                    return default;

                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task SetItem<T>(string key, T value)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
