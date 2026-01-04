using TIN.Core.Dtos;

namespace TIN.Frontend.Api;

public interface IProductFetcher
{
    Task<IEnumerable<GetProductDto>?> GetAllProducts();
    
    Task<GetProductDto?> GetProduct(Guid id);
}