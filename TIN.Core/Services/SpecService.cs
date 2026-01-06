using TIN.Core.Dtos.Product;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Core.Services;

public class SpecService(IUnitOfWork uow) : ISpecService
{
    public async Task<List<Guid>> CreateAllSpecsAsync(List<PostSpecDto> dtos)
    {
        if (dtos.Select(d => d.ProductId).ToHashSet().Count > 1)
            throw new BadRequestException();
        
        var product = await uow.Products.GetProductAsync(dtos.First().ProductId)
            ?? throw new BadRequestException();
        
        var specs = dtos.Select(d => d.ToModel(product)).ToList();
        
        await uow.Specs.AddRangeAsync(specs);

        await uow.SaveChangesAsync();

        return specs.Select(s => s.Id).ToList();
    }

    public async Task UpdateAllSpecsAsync(PutSpecsDto dto)
    {
        List<SpecModel> models = [.. await uow.Specs.GetAllSpecsByIdsAsync(dto.Specs.Select(d => d.Id))];
        
        if (models.Count != dto.Specs.Count)
            throw new BadRequestException();

        var product = await uow.Products.GetProductAsync(dto.ProductId)
                      ?? throw new BadRequestException();
        
        List<SpecModel> toRemove = [.. product.Specs.Where(s => !models.Contains(s))];
        
        for (var i = 0; i < dto.Specs.Count; i++)
            models[i].Value = dto.Specs[i].Value;

        foreach (var specModel in toRemove)
            product.Specs.Remove(specModel);
        
        uow.Specs.RemoveRange(toRemove);

        await uow.SaveChangesAsync();
    }
}