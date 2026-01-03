using System.Net.Http.Json;

namespace TIN.Frontend.Auth;

public class AuthApiService(HttpClient client)
{
    public async Task<string> LoginAsync(string username, string password)
    {
        var response = await client.PostAsJsonAsync("api/auth/login", new { username, password });
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
}
