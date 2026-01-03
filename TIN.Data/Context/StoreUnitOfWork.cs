using TIN.Data.Repositories;

namespace TIN.Data.Context;

public class StoreUnitOfWork(
    StoreDbContext context,
    IOrderRepository orders,
    IOrderItemsRepository orderItems,
    IProductRepository products, 
    IUserRepository users,
    ILocalizationRepository localizations,
    ISpecRepository specs) 
    : IUnitOfWork
{
    public IOrderRepository Orders => orders;
    
    public IOrderItemsRepository OrderItems => orderItems;

    public IProductRepository Products => products;
    
    public IUserRepository Users => users;
    
    public ILocalizationRepository Localizations => localizations;
    
    public ISpecRepository Specs => specs;
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}