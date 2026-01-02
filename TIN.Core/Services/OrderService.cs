using TIN.Core.Dtos;
using TIN.Data.Context;

namespace TIN.Core.Services;

public class OrderService(StoreUnitOfWork uow) : IOrderService
{
    public async Task<List<GetOrderDto>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<GetOrderDto> GetOrderAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddOrderAsync(PostOrderDto order)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateOrderAsync(GetOrderDto order)
    {
        throw new NotImplementedException();
    }

    public void DeleteOrder(GetOrderDto order)
    {
        throw new NotImplementedException();
    }
}