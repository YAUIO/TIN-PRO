using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    
    Task<ProductModel?> GetProductAsync(Guid id);
    
    Task AddProductAsync(ProductModel product);
    
    void DeleteProduct(ProductModel product);
}