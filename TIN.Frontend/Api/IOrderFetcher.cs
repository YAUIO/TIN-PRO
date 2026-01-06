using TIN.Core.Dtos;
using TIN.Core.Dtos.Order;
using TIN.Frontend.Cart;

namespace TIN.Frontend.Api;

public interface IOrderFetcher
{
    Task<IEnumerable<GetOrderDto>?> GetAllOrdersAsync(PaginationDto? dto);

    Task<GetOrderDto?> GetOrderAsync(Guid id);
    
    Task<Guid> CreateOrder(List<CartItem> products, string customerName);
}