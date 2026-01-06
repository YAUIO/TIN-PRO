using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface ISpecRepository
{
    Task<IEnumerable<SpecModel>> GetAllSpecsByIdsAsync(IEnumerable<Guid> ids);
    
    Task AddRangeAsync(IEnumerable<SpecModel> models);
    
    void RemoveRange(IEnumerable<SpecModel> toRemove);
}