using Microsoft.Extensions.Options;
using TIN.Core.Dtos.Localization;
using TIN.Frontend.Options;

namespace TIN.Frontend.Api;

public class LocalizationFetcher(IOptions<ApiOptions> options, IApiFetcher api) : ILocalizationFetcher
{
    private readonly ApiOptions _apicfg = options.Value;
    
    public async Task<IEnumerable<GetSpecNameDto>?> GetSpecNamesAsync(Guid productId)
    {
        try
        {
            return await api.FetchAsync<IEnumerable<GetSpecNameDto>>($"{_apicfg.Localizations}/specnames/{productId}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<IEnumerable<GetProductDescriptionDto>?> GetProductDescriptionsAsync(Guid productId)
    {
        try
        {
            return await api.FetchAsync<IEnumerable<GetProductDescriptionDto>>($"{_apicfg.Localizations}/descriptions/{productId}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}