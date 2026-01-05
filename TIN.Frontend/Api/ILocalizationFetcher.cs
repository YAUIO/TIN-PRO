using TIN.Core.Dtos.Localization;

namespace TIN.Frontend.Api;

public interface ILocalizationFetcher
{
    Task<IEnumerable<GetSpecNameDto>?> GetSpecNamesAsync(Guid productId);
    
    Task<IEnumerable<GetProductDescriptionDto>?> GetProductDescriptionsAsync(Guid productId);
}