using TIN.Core.Dtos;
using TIN.Core.Dtos.User;

namespace TIN.Frontend.Api;

public interface IUserFetcher
{
    Task<IEnumerable<GetUserDto>?> GetAllUsersAsync(PaginationDto? dto);
    
    Task<GetUserDto?> GetUserAsync(Guid id);

    Task MakeAdminAsync(Guid id);
}