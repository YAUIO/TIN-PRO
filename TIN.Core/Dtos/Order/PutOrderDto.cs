using System.ComponentModel.DataAnnotations;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.Order;

public class PutOrderDto
{
    [Required]
    public Guid Id { get; init; }
    
    [Required]
    public DateTime OrderDate { get; set; }
    
    [Required]
    public DateTime? CompletionDate { get; set; }
    
    [Required]
    public OrderStatus OrderStatus { get; set; }
    
    [Required]
    public Guid CustomerId { get; set; }
    
    [Required]
    [MinLength(1)]
    public ICollection<PostOrderItemDto> Products { get; set; } = [];
}