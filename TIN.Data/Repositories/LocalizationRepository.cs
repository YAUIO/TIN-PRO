using TIN.Data.Context;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Repositories;

public class LocalizationRepository(StoreDbContext context) : ILocalizationRepository
{
    public async Task AddDescriptionAsync(ProductDescriptionModel productDescription)
    {
        await context.ProductDescriptions.AddAsync(productDescription);
    }

    public async Task AddSpecNameAsync(SpecNameModel specName)
    {
        await context.SpecNames.AddAsync(specName);
    }

    public async Task<SpecNameModel?> GetSpecName(string name, Language language)
    {
        return await context.SpecNames.FindAsync(name, language);
    }

    public void DeleteSpecName(SpecNameModel specName)
    {
        context.SpecNames.Remove(specName);
    }
}