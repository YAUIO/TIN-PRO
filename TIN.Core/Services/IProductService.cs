using TIN.Core.Dtos;

namespace TIN.Core.Services;

public interface IProductService
{
    Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
    
    Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid productId);

    Task<GetProductDto> GetProductAsync(Guid productId);
    
    Task<Guid> AddProductAsync(PostProductDto product);
    
    Task UpdateProductAsync(GetProductDto product);
    
    void DeleteProduct(GetProductDto product);
}