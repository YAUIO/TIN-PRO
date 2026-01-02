using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos;

public class PostUserDto
{
    public string UserName { get; init; }
    
    public UserRole UserRole { get; init; }

    public ICollection<GetOrderDto> Orders { get; init; } = [];
}