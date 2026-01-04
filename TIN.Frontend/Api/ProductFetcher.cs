using Microsoft.Extensions.Options;
using TIN.Core.Dtos;
using TIN.Frontend.Options;

namespace TIN.Frontend.Api;

public class ProductFetcher(IApiFetcher api, IOptions<ApiOptions> options) : IProductFetcher
{
    private readonly ApiOptions _apicfg = options.Value;
    
    public async Task<IEnumerable<GetProductDto>?> GetAllProducts()
    {
        try
        {
            return await api.FetchAsync<IEnumerable<GetProductDto>>(_apicfg.Products);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<GetProductDto?> GetProduct(Guid id)
    {
        try
        {
            return await api.FetchAsync<GetProductDto>($"{_apicfg.Products}/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}