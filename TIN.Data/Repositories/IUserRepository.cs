using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAllUsersAsync();
}