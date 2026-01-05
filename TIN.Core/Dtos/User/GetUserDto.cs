using TIN.Core.Dtos.Order;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.User;

public class GetUserDto
{
    public Guid UserId { get; init; }
    
    public string UserName { get; init; }
    
    public UserRole UserRole { get; init; }

    public ICollection<GetOrderDto> Orders { get; init; } = [];
}