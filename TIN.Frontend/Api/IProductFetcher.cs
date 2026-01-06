using TIN.Core.Dtos;
using TIN.Core.Dtos.Product;

namespace TIN.Frontend.Api;

public interface IProductFetcher
{
    Task<IEnumerable<GetProductDto>?> GetAllProductsAsync(PaginationDto? dto);
    
    Task<GetProductDto?> GetProductAsync(Guid id);

    Task RemoveProductAsync(Guid id);
    
    Task UpdateProductAsync(PutProductWrapperDto product);
    
    Task<Guid> CreateProductAsync(PostProductWrapperDto dto);
}