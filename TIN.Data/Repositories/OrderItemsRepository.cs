using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class OrderItemsRepository(StoreDbContext context) : IOrderItemsRepository
{ 
    public async Task<IEnumerable<OrderItemModel>> GetItemsByOrderIdAsync(Guid id)
    {
        return await context.OrderItems
            .Where(x => x.OrderId == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItemModel>> GetItemsByProductIdAsync(Guid id)
    {
        return await context.OrderItems
            .Where(x => x.ProductId == id)
            .ToListAsync();
    }

    public async Task AddItemsAsync(IEnumerable<OrderItemModel> orderItems)
    {
        await context.OrderItems.AddRangeAsync(orderItems);
    }
}