using TIN.Core.Dtos.User;

namespace TIN.Frontend.Api;

public interface IUserFetcher
{
    Task<IEnumerable<GetUserDto>?> GetAllUsersAsync();
    
    Task<GetUserDto?> GetUserAsync(Guid id);

    Task MakeAdminAsync(Guid id);
}