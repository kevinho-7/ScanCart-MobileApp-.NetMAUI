using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanCart.Services
{
    public class LocalStorageService
    {
        private readonly IJSRuntime _js;
        public LocalStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetItemAsync(string key, string value)
        {
            await _js.InvokeVoidAsync(
                "localStorage.setItem",
                key,
                value
            );
        }

        public async Task<string?> GetItemAsync(string key)
        {
           return await _js.InvokeAsync<string?>(
                "localStorage.getItem",
                key
            );
        }

    }
}
