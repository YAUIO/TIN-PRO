using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class SpecRepository(StoreDbContext context) : ISpecRepository
{
    public async Task<IEnumerable<SpecModel>> GetAllSpecsByIdsAsync(IEnumerable<Guid> ids)
    {
        return await context.Specs
            .Where(s => ids.Contains(s.Id))
            .ToListAsync();
    }

    public async Task AddRangeAsync(IEnumerable<SpecModel> models)
    {
        await context.Specs.AddRangeAsync(models);
    }

    public void RemoveRange(IEnumerable<SpecModel> toRemove)
    {
        context.Specs.RemoveRange(toRemove);
    }
}