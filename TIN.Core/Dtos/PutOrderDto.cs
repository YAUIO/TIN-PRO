using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos;

public class PutOrderDto
{
    public Guid Id { get; init; }
    
    public DateTime OrderDate { get; init; }
    
    public DateTime? CompletionDate { get; init; }
    
    public OrderStatus OrderStatus { get; init; }
    
    public Guid CustomerId { get; init; }
    
    public ICollection<PostOrderItemDto> Products { get; init; } = [];
}