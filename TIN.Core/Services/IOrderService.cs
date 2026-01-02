using TIN.Core.Dtos;

namespace TIN.Core.Services;

public interface IOrderService
{
    Task<List<GetOrderDto>> GetAllOrdersAsync();
    
    Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid orderId);

    Task<GetOrderDto> GetOrderAsync(Guid orderId);
    
    Task<Guid> AddOrderAsync(PostOrderDto order);
    
    Task UpdateOrderAsync(GetOrderDto order);
    
    void DeleteOrder(GetOrderDto order);
}