using TIN.Core.Dtos;
using TIN.Data.Context;

namespace TIN.Core.Services;

public class ProductService(StoreUnitOfWork uow) : IProductService
{
    public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public async Task<GetProductDto> GetProductAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddProductAsync(PostProductDto product)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProductAsync(GetProductDto product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(GetProductDto product)
    {
        throw new NotImplementedException();
    }
}