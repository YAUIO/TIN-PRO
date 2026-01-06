using TIN.Core.Dtos;
using TIN.Core.Dtos.User;

namespace TIN.Core.Services;

public interface IUserService
{
    Task<List<GetUserDto>> GetAllUsersAsync(PaginationDto? dto);

    Task<GetUserDto> GetUserAsync(Guid userId);
    
    Task<Guid> AddUserAsync(RegisterUserDto user);
    
    Task DeleteUserAsync(Guid id);
    
    Task<string> LoginUserAsync(AuthUserDto user);
    
    Task MakeAdminById(Guid id);
}