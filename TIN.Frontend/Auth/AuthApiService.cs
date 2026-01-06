using System.Text.Json;
using TIN.Core.Dtos.User;
using TIN.Frontend.Api;

namespace TIN.Frontend.Auth;

public class AuthApiService(IApiFetcher api, ILogger<AuthApiService> auth)
{
    public async Task<string> LoginAsync(AuthUserDto dto)
    {
        var token = await api.PostAsync("api/auth/login", dto);
        
        var jwt = JsonSerializer.Deserialize<TokenDto>(token, ApiFetcher.Options)!;
        
        return jwt.Token;
    }

    public async Task RegisterAsync(RegisterUserDto dto)
    {
        await api.PostAsync("api/auth/register", dto);
    }
}
