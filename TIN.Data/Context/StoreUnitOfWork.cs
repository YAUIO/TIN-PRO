using TIN.Data.Repositories;

namespace TIN.Data.Context;

public class StoreUnitOfWork(
    StoreDbContext context,
    IOrderRepository orders,
    IOrderItemsRepository orderItems,
    IProductRepository products, 
    IUserRepository users) 
    : IUnitOfWork
{
    public IOrderRepository Orders => orders;
    
    public IOrderItemsRepository OrderItems => orderItems;

    public IProductRepository Products => products;
    
    public IUserRepository Users => users;
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}