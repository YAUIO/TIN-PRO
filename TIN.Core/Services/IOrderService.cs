using System.Security.Claims;
using TIN.Core.Dtos;
using TIN.Core.Dtos.Order;

namespace TIN.Core.Services;

public interface IOrderService
{
    Task<List<GetOrderDto>> GetAllOrdersAsync(PaginationDto? dto);
    
    Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid orderId);

    Task<GetOrderDto> GetOrderAsync(Guid orderId, ClaimsPrincipal user);
    
    Task<Guid> AddOrderAsync(PostOrderDto order);
    
    Task UpdateOrderAsync(PutOrderDto order);
    
    Task DeleteOrderAsync(Guid id);
    
    Task<List<GetOrderDto>> GetAllUserOrdersAsync(string username, ClaimsPrincipal user, PaginationDto paginationDto);
}