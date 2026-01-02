namespace TIN.Core.Dtos;

public class GetOrderItemDto
{
    public GetProductDto Product { get; init; }
    
    public int Quantity { get; init; }
}