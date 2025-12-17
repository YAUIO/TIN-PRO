using TIN.Core.Dtos;

namespace TIN.Core.Services;

public interface IProductService
{
    Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
}