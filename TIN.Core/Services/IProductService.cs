using TIN.Core.Dtos;
using TIN.Core.Dtos.Order;
using TIN.Core.Dtos.Product;

namespace TIN.Core.Services;

public interface IProductService
{
    Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
    
    Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid productId);

    Task<GetProductDto> GetProductAsync(Guid productId);
    
    Task<Guid> AddProductAsync(PostProductDto product);
    
    Task UpdateProductAsync(PutProductWrapperDto product);
    
    Task DeleteProductAsync(Guid id);
}