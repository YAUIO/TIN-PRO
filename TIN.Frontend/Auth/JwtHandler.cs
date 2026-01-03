using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace TIN.Frontend.Auth;

public class JwtHandler(IJSRuntime js) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = await js.GetTokenAsync();

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        
        return await base.SendAsync(request, ct);
    }
}