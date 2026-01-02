using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class OrderRepository(StoreDbContext context) : IOrderRepository
{
    public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task<OrderModel?> GetOrderAsync(Guid id)
    {
        return await context.Orders.FindAsync(id);
    }

    public void DeleteOrderAsync(OrderModel order)
    {
        context.Orders.Remove(order);
    }

    public async Task AddOrderAsync(OrderModel order)
    {
        await context.Orders.AddAsync(order);
    }
}