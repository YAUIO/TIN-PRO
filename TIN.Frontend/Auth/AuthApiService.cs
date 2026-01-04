using TIN.Frontend.Api;

namespace TIN.Frontend.Auth;

public class AuthApiService(IApiFetcher api)
{
    public async Task<string> LoginAsync(string username, string password)
    {
        return await api.PostAsync("api/auth/login", new { username, password });
    }
}
