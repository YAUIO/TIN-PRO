using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class UserRepository(StoreDbContext context) : IUserRepository
{
    public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
    {
        return await context.Users.Include(u => u.Orders).ToListAsync();
    }

    public async Task<UserModel?> GetUserAsync(Guid userId)
    {
        return await context.Users.FindAsync(userId);
    }

    public async Task<UserModel?> GetUserAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Nickname == username);
    }

    public async Task AddUserAsync(UserModel user)
    {
        await context.Users.AddAsync(user);
    }

    public void DeleteUser(UserModel user)
    {
        context.Users.Remove(user);
    }
}