using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public interface ISpecRepository
{
    Task<IEnumerable<SpecModel>> GetAllSpecsByIdsAsync(IEnumerable<Guid> ids);
}