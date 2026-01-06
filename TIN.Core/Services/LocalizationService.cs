using TIN.Core.Dtos.Localization;
using TIN.Core.Mappings;
using TIN.Data.Context;

namespace TIN.Core.Services;

public class LocalizationService(IUnitOfWork uow) : ILocalizationService
{
    public async Task<IEnumerable<GetSpecNameDto>> GetSpecNamesAsync(Guid productId)
    {
        var names = await uow.Localizations.GetProductSpecNames(productId);
        
        return [.. names.Select(n => n.ToDto())];
    }

    public async Task<IEnumerable<GetProductDescriptionDto>> GetDescriptionsAsync(Guid productId)
    {
        var descriptions = await uow.Localizations.GetProductDescriptions(productId);

        return [.. descriptions.Select(d => d.ToDto())];
    }
}