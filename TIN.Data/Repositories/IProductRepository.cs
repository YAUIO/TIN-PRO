using TIN.Data.Entities;
using TIN.Data.Models;

namespace TIN.Data.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
}