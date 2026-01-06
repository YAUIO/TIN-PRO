using System.Security.Claims;
using TIN.Core.Dtos;
using TIN.Core.Dtos.Order;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;

namespace TIN.Core.Services;

public class OrderService(IUnitOfWork uow) : IOrderService
{
    public async Task<List<GetOrderDto>> GetAllOrdersAsync(PaginationDto? dto)
    {
        var orders = await uow.Orders.GetAllOrdersAsync();

        orders = orders.Paginate(dto);
        
        return [.. orders.Select(s => s.ToDto())];
    }

    public async Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid orderId)
    {
        var order = await uow.Orders.GetOrderAsync(orderId)
            ?? throw new BadRequestException();
        return [.. order.Items.Select(s => s.ToDto())];
    }

    public async Task<GetOrderDto> GetOrderAsync(Guid orderId, ClaimsPrincipal user)
    {
        var order = await uow.Orders.GetOrderAsync(orderId)
            ?? throw new NotFoundException();

        if (user.Identity == null || order.Customer.Nickname != user.Identity.Name)
            throw new UnauthorizedAccessException();
        
        return order.ToDto();
    }

    public async Task<Guid> AddOrderAsync(PostOrderDto order)
    {
        var now = DateTime.UtcNow;
        if (order.OrderDate > order.CompletionDate || order.OrderDate > now || order.CompletionDate > now)
            throw new BadRequestException();
        
        var model = order.ToModel();
        model.Customer = await uow.Users.GetUserAsync(order.CustomerName) 
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
        var now = DateTime.UtcNow;
        if (order.OrderDate > order.CompletionDate || order.OrderDate > now || order.CompletionDate > now)
            throw new BadRequestException();
        
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

    public async Task<List<GetOrderDto>> GetAllUserOrdersAsync(string username, ClaimsPrincipal user, PaginationDto paginationDto)
    {
        if (user.Identity == null || username != user.Identity.Name)
            throw new UnauthorizedAccessException();
        
        var orders = await uow.Orders.GetAllOrdersByUsernameAsync(username);

        orders = orders.Paginate(paginationDto);
        
        return [.. orders.Select(s => s.ToDto())];
    }
}