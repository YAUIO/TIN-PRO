using TIN.Core.Dtos;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;

namespace TIN.Core.Services;

public class OrderService(IUnitOfWork uow) : IOrderService
{
    public async Task<List<GetOrderDto>> GetAllOrdersAsync()
    {
        var orders = await uow.Orders.GetAllOrdersAsync();
        return [.. orders.Select(s => s.ToDto())];
    }

    public async Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid orderId)
    {
        var order = await uow.Orders.GetOrderAsync(orderId)
            ?? throw new BadRequestException();
        return [.. order.Items.Select(s => s.ToDto())];
    }

    public async Task<GetOrderDto> GetOrderAsync(Guid orderId)
    {
        var order = await uow.Orders.GetOrderAsync(orderId)
            ?? throw new NotFoundException();
        return order.ToDto();
    }

    public async Task<Guid> AddOrderAsync(PostOrderDto order)
    {
        var model = order.ToModel();
        model.Customer = await uow.Users.GetUserAsync(order.CustomerId) 
            ?? throw new BadRequestException();
        
        await uow.Orders.AddOrderAsync(model);
        
        var items = order.Products
            .Select(s => s.ToModel(model.Id))
            .ToList();

        model.Items = items;
        
        await uow.SaveChangesAsync();
        
        return model.Id;
    }

    public async Task UpdateOrderAsync(PutOrderDto order)
    {
        var model = await uow.Orders.GetOrderAsync(order.Id)
            ?? throw new BadRequestException();
        model.Customer = await uow.Users.GetUserAsync(order.CustomerId)
                       ?? throw new BadRequestException();
        
        model.UpdateWithDto(order);
        
        var items = order.Products
            .Select(s => s.ToModel(model.Id))
            .ToList();
        model.Items = items;
        
        await uow.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        var order = await uow.Orders.GetOrderAsync(id)
            ?? throw new BadRequestException();
        
        uow.Orders.DeleteOrder(order);

        await uow.SaveChangesAsync();
    }
}