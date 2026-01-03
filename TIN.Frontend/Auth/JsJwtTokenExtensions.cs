using Microsoft.JSInterop;

namespace TIN.Frontend;

public static class JsJwtTokenExtensions
{
    extension(IJSRuntime js)
    {
        public async Task<string> GetTokenAsync()
        {
            return await js.InvokeAsync<string>("localStorage.getItem", "token");
        }

        public async Task SetTokenAsync(string token)
        {
            await js.InvokeVoidAsync("localStorage.setItem", "token", token);
        }

        public async Task RemoveTokenAsync()
        {
            await js.InvokeVoidAsync("localStorage.removeItem", "token");
        }
    }
}