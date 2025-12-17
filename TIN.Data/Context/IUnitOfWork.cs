using TIN.Data.Repositories;

namespace TIN.Data.UnitOfWork;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
    
    IProductRepository Products { get; }
    
    IUserRepository Users { get;  }
}