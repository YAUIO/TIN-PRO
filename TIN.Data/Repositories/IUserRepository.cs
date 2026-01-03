using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAllUsersAsync();
    
    Task<UserModel?> GetUserAsync(Guid userId);
    
    Task<UserModel?> GetUserAsync(string username);
    
    Task AddUserAsync(UserModel user);
    
    void DeleteUser(UserModel user);
}