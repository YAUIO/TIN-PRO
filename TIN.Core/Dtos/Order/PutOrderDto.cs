using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.Order;

public class PutOrderDto
{
    public Guid Id { get; init; }
    
    public DateTime OrderDate { get; set; }
    
    public DateTime? CompletionDate { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public ICollection<PostOrderItemDto> Products { get; set; } = [];
}