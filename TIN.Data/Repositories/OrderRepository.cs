using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class OrderRepository(StoreDbContext context) : IOrderRepository
{
    public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
    {
        return await context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderModel>> GetAllOrdersByIdsAsync(IEnumerable<Guid> orderIds)
    {
        return await context.Orders
            .Where(o => orderIds.Contains(o.Id))
            .ToListAsync();
    }

    public async Task<OrderModel?> GetOrderAsync(Guid id)
    {
        return await context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public void DeleteOrder(OrderModel order)
    {
        context.Orders.Remove(order);
    }

    public async Task AddOrderAsync(OrderModel order)
    {
        await context.Orders.AddAsync(order);
    }
}