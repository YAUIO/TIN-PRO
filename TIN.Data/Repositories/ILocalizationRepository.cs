using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Repositories;

public interface ILocalizationRepository
{
    Task AddDescriptionAsync(ProductDescriptionModel productDescription);
    
    Task AddSpecNameAsync(SpecNameModel specName);

    Task<SpecNameModel?> GetSpecName(string name, Language language);
    
    void DeleteSpecName(SpecNameModel specName);
    
    Task<IEnumerable<SpecNameModel>> GetProductSpecNames(Guid productId);
    
    Task<IEnumerable<ProductDescriptionModel>> GetProductDescriptions(Guid productId);
}