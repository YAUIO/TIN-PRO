using TIN.Core.Dtos;
using TIN.Core.Dtos.Product;

namespace TIN.Frontend.Api;

public interface IProductFetcher
{
    Task<IEnumerable<GetProductDto>?> GetAllProducts();
    
    Task<GetProductDto?> GetProduct(Guid id);

    Task RemoveProduct(Guid id);
    
    Task UpdateProductAsync(PutProductWrapperDto product);
    
    Task<Guid> CreateProductAsync(PostProductWrapperDto dto);
}