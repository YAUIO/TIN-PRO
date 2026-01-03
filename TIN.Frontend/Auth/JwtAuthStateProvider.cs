using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace TIN.Frontend.Auth;

public class JwtAuthStateProvider(IJSRuntime js) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await js.GetTokenAsync();

        if (string.IsNullOrEmpty(token))
            return new AuthenticationState(new ClaimsPrincipal());
        
        var jwt = new JwtSecurityTokenHandler()
            .ReadJwtToken(token);
        
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, "jwt")));
    }
    
    public async Task Login(string token)
    {
        await js.SetTokenAsync(token);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        await js.RemoveTokenAsync();
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}