using TIN.Core.Dtos;
using TIN.Core.Dtos.Order;

namespace TIN.Core.Services;

public interface IOrderService
{
    Task<List<GetOrderDto>> GetAllOrdersAsync();
    
    Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid orderId);

    Task<GetOrderDto> GetOrderAsync(Guid orderId);
    
    Task<Guid> AddOrderAsync(PostOrderDto order);
    
    Task UpdateOrderAsync(PutOrderDto order);
    
    Task DeleteOrderAsync(Guid id);
}