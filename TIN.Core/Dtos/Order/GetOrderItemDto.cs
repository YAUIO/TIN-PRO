using TIN.Core.Dtos.Product;

namespace TIN.Core.Dtos.Order;

public class GetOrderItemDto
{
    public GetProductDto Product { get; init; }
    
    public int Quantity { get; init; }
}