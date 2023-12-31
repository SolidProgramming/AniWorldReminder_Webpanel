﻿using Microsoft.JSInterop;

namespace AniWorldReminder_Webpanel.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T?> GetItem<T>(string key)
        {
            try
            {
                var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

                if (json == null)
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
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
