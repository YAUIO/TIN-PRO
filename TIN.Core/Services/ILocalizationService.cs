using TIN.Core.Dtos.Localization;

namespace TIN.Core.Services;

public interface ILocalizationService
{
    Task<IEnumerable<GetSpecNameDto>> GetSpecNamesAsync(Guid productId);
    
    Task<IEnumerable<GetProductDescriptionDto>> GetDescriptionsAsync(Guid productId);
}