using TIN.Core.Dtos;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class UserMapping
{
    public static GetUserDto ToDto(this UserModel model, Language language) => new()
    {
        UserId = model.Id,
        UserName = model.Nickname,
        UserRole = model.Role,
        Orders = [.. model.Orders.Select(s => s.ToDto(language))],
    };
}