using TIN.Data.Entities;

namespace TIN.Core.Services;

public interface IAuthService
{
    string GenerateToken(UserModel user);
}