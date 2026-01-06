using System.Text.Json;
using Microsoft.Extensions.Options;
using TIN.Core.Dtos;
using TIN.Core.Dtos.Product;
using TIN.Frontend.Options;

namespace TIN.Frontend.Api;

public class ProductFetcher(IApiFetcher api, IOptions<ApiOptions> options, ILogger<ProductFetcher> logger) : IProductFetcher
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

    public async Task<IEnumerable<GetProductDto>?> GetAllProductsAsync(PaginationDto? dto)
    {
        
        try
        {
            return await api.FetchAsync<IEnumerable<GetProductDto>>($"{_apicfg.Products}/{dto?.PageSize ?? int.MaxValue}/{dto?.Page ?? 1}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<GetProductDto?> GetProductAsync(Guid id)
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

    public async Task RemoveProductAsync(Guid id)
    {
        await api.DeleteAsync(_apicfg.Products, id.ToString());
    }

    public async Task UpdateProductAsync(PutProductWrapperDto product)
    {
        await api.UpdateAsync(_apicfg.Products, product);
    }

    public async Task<Guid> CreateProductAsync(PostProductWrapperDto dto)
    {
        var response = await api.PostAsync(_apicfg.Products, dto);
        
        return JsonSerializer.Deserialize<Guid>(response);
    }
}