using TIN.Core.Dtos.User;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.Order;

public class GetOrderDto
{
    public Guid Id { get; init; }
    
    public DateTime OrderDate { get; init; }
    
    public DateTime? CompletionDate { get; init; }
    
    public OrderStatus OrderStatus { get; init; }
    
    public GetUserDto Customer { get; init; }
    
    public ICollection<GetOrderItemDto> Products { get; init; } = [];
}