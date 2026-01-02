using TIN.Core.Dtos;

namespace TIN.Core.Services;

public interface IUserService
{
    Task<List<GetUserDto>> GetAllUsersAsync();

    Task<GetUserDto> GetUserAsync(Guid orderId);
    
    Task<Guid> AddUserAsync(PostUserDto order);
    
    Task UpdateUserAsync(GetUserDto order);
    
    void DeleteUser(GetUserDto order);
}