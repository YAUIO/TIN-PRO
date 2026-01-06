using Microsoft.AspNetCore.Identity;
using TIN.Core.Dtos;
using TIN.Core.Dtos.User;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Services;

public class UserService(IUnitOfWork uow, IPasswordHasher<UserModel> hasher, IAuthService auth) : IUserService
{
    public async Task<List<GetUserDto>> GetAllUsersAsync(PaginationDto? dto)
    {
        var users = await uow.Users.GetAllUsersAsync();

        users = users.Paginate(dto);
        
        return [.. users.Select(u => u.ToDto())];
    }

    public async Task<GetUserDto> GetUserAsync(Guid userId)
    {
        var user = await uow.Users.GetUserAsync(userId)
            ?? throw new NotFoundException();
        
        return user.ToDto();
    }

    public async Task<Guid> AddUserAsync(RegisterUserDto user)
    {
        var model = new UserModel()
        {
            Nickname = user.UserName,
            Role = UserRole.Customer,
        };
        
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

    public async Task MakeAdminById(Guid id)
    {
        var user = await uow.Users.GetUserAsync(id)
            ?? throw new BadRequestException();

        if (user.Role == UserRole.Guest)
            throw new BadRequestException();
        
        user.Role = UserRole.Administrator;

        await uow.SaveChangesAsync();
    }
}