using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.Order;

public class PostOrderItemDto
{
    [Required]
    public Guid ProductId { get; init; }
    
    [Required]
    public int Quantity { get; init; }
}