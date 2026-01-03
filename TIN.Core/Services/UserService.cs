using Microsoft.AspNetCore.Identity;
using TIN.Core.Dtos;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Core.Services;

public class UserService(IUnitOfWork uow, IPasswordHasher<UserModel> hasher, IAuthService auth) : IUserService
{
    public async Task<List<GetUserDto>> GetAllUsersAsync()
    {
        var users = await uow.Users.GetAllUsersAsync();

        return [.. users.Select(u => u.ToDto())];
    }

    public async Task<GetUserDto> GetUserAsync(Guid userId)
    {
        var user = await uow.Users.GetUserAsync(userId)
            ?? throw new NotFoundException();
        
        return user.ToDto();
    }

    public async Task<Guid> AddUserAsync(PostUserDto user)
    {
        var model = user.ToModel();
        
        model.PasswordHash = hasher.HashPassword(model, user.Password);
        
        await uow.Users.AddUserAsync(model);

        await uow.SaveChangesAsync();
        
        return model.Id;
    }

    public async Task UpdateUserAsync(PutUserDto user)
    {
        var model = await uow.Users.GetUserAsync(user.UserId)
            ?? throw new BadRequestException();
        
        model.UpdateWithDto(user);
        
        await uow.Users.AddUserAsync(model);

        await uow.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var model = await uow.Users.GetUserAsync(id)
            ?? throw new BadRequestException();
        
        uow.Users.DeleteUser(model);
        
        await uow.SaveChangesAsync();
    }

    public async Task<string> LoginUserAsync(AuthUserDto user)
    {
        var model = await uow.Users.GetUserAsync(user.UserName)
                    ?? throw new UnauthorizedException();

        var status = hasher.VerifyHashedPassword(model, model.PasswordHash, user.Password);

        if (status == PasswordVerificationResult.Failed)
            throw new UnauthorizedException();

        if (status == PasswordVerificationResult.SuccessRehashNeeded)
        {
            model.PasswordHash = hasher.HashPassword(model, user.Password);
            await uow.SaveChangesAsync();
        }

        return auth.GenerateToken(model);
    }
}