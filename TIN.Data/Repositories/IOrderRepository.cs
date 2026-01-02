using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
    
    Task<OrderModel?> GetOrderAsync(Guid id);
    
    void DeleteOrder(OrderModel order);
    
    Task AddOrderAsync(OrderModel order);
}