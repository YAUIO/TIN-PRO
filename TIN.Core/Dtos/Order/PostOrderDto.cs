using System.ComponentModel.DataAnnotations;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.Order;

public class PostOrderDto
{
    [Required]
    public DateTime OrderDate { get; init; }
    
    [Required]
    public DateTime? CompletionDate { get; init; }
    
    [Required]
    public OrderStatus? OrderStatus { get; init; }
    
    [Required]
    public string CustomerName { get; init; }
    
    public ICollection<PostOrderItemDto> Products { get; init; } = [];
}