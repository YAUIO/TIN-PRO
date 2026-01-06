using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using TIN.Frontend.Cart;

namespace TIN.Frontend.Auth;

public class JwtAuthStateProvider(IJSRuntime js, ICartService cart) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await js.GetTokenAsync();

        if (string.IsNullOrEmpty(token))
            return new AuthenticationState(new ClaimsPrincipal());

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var claims = jwt.Claims.ToList();

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
        catch
        {
            await js.RemoveTokenAsync();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
    
    public async Task<string?> GetClaimAsync(string claimType)
    {
        var state = await GetAuthenticationStateAsync();
        return state.User.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
    }
    
    public async Task LoginAsync(string token)
    {
        await js.SetTokenAsync(token);
        var state = await GetAuthenticationStateAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }

    public async Task LogoutAsync()
    {
        await js.RemoveTokenAsync();
        await cart.ClearCart();
        var state = await GetAuthenticationStateAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }
}