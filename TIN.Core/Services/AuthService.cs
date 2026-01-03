using System.Security.Claims;
using System.Text;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;
using TIN_PRO.Options;
using TIN.Data.Entities;

namespace TIN.Core.Services;

public class AuthService(IOptions<JwtOptions> options) : IAuthService
{
    public string GenerateToken(UserModel user)
    {
        var token = new JwtBuilder()
            .AddClaim(ClaimTypes.Name, user.Nickname)
            .AddClaim(ClaimTypes.NameIdentifier, user.Id.ToString())
            .AddClaim(ClaimTypes.Role, user.Role.ToString())
            .ExpirationTime(DateTimeOffset.UtcNow.AddMinutes(options.Value.ExpirationInMinutes).UtcDateTime)
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(Encoding.UTF8.GetBytes(options.Value.Key))
            .Encode()!;
        
        return token;
    }
}