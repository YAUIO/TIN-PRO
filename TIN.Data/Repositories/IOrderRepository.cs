using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
}