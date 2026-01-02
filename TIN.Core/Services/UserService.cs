using TIN.Core.Dtos;
using TIN.Data.Context;

namespace TIN.Core.Services;

public class UserService(StoreUnitOfWork uow) : IUserService
{
    public async Task<List<GetUserDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<GetUserDto> GetUserAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddUserAsync(PostUserDto order)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserAsync(GetUserDto order)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(GetUserDto order)
    {
        throw new NotImplementedException();
    }
}