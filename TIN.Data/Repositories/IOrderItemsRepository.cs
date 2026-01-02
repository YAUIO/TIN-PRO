using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface IOrderItemsRepository
{
    Task<IEnumerable<OrderItemModel>> GetAllItemsAsync();
    
    Task<IEnumerable<OrderItemModel>> GetItemsByOrderIdAsync(Guid id);
    
    Task<IEnumerable<OrderItemModel>> GetItemsByProductIdAsync(Guid id);
}