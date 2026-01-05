using Microsoft.Extensions.Options;
using TIN.Core.Dtos.Order;
using TIN.Data.Entities.Enums;
using TIN.Frontend.Cart;
using TIN.Frontend.Options;

namespace TIN.Frontend.Api;

public class OrderFetcher(IOptions<ApiOptions> options, IApiFetcher api) : IOrderFetcher
{
    private readonly ApiOptions _apicfg = options.Value;
    
    public async Task<IEnumerable<GetOrderDto>?> GetAllOrdersAsync()
    {
        try
        {
            return await api.FetchAsync<IEnumerable<GetOrderDto>>($"{_apicfg.Orders}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<GetOrderDto?> GetOrderAsync(Guid id)
    {
        try
        {
            return await api.FetchAsync<GetOrderDto>($"{_apicfg.Orders}/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<Guid> CreateOrder(List<CartItem> products, Guid customerId)
    {
        var dto = new PostOrderDto()
        {
            OrderDate = DateTime.UtcNow,
            CompletionDate = null,
            OrderStatus = OrderStatus.Created,
            CustomerId = customerId,
            Products = [.. products.Select(p => new PostOrderItemDto()
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity,
            })],
        };
        var id = await api.PostAsync(_apicfg.Orders, dto);
        return Guid.Parse(id);
    }
}