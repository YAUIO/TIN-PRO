using TIN.Core.Dtos;
using TIN.Core.Dtos.User;
using TIN.Data.Entities;

namespace TIN.Core.Mappings;

public static class UserMapping
{
    public static GetUserDto ToDto(this UserModel model) => new()
    {
        UserId = model.Id,
        UserName = model.Nickname,
        UserRole = model.Role,
        Orders = [.. model.Orders.Select(s => s.ToDto())],
    };
    
    public static GetUserDto ToDtoWithoutOrders(this UserModel model) => new()
    {
        UserId = model.Id,
        UserName = model.Nickname,
        UserRole = model.Role,
    };

    public static UserModel ToModel(this PostUserDto dto) => new()
    {
        Nickname = dto.UserName,
        Role = dto.UserRole,
    };
    
    public static UserModel UpdateWithDto(this UserModel model, PutUserDto dto)
    {
        if (model.Id != dto.UserId)
            throw new ArgumentException("User Id doesn't match");
        
        model.Nickname = dto.UserName;
        model.Role = dto.UserRole;
        
        return model;
    }
}