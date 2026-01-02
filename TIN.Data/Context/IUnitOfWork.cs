using TIN.Data.Repositories;

namespace TIN.Data.Context;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
    
    IOrderItemsRepository OrderItems { get; }
    
    IProductRepository Products { get; }
    
    IUserRepository Users { get;  }
    
    Task SaveChangesAsync();
}