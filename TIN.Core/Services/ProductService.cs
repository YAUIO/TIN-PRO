using TIN.Core.Dtos.Order;
using TIN.Core.Dtos.Product;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Services;

public class ProductService(IUnitOfWork uow) : IProductService
{
    public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
    {
        var products = await uow.Products.GetAllProductsAsync();
        return [.. products.Select(s => s.ToDto())];
    }

    public async Task<List<GetOrderItemDto>> GetAllOrderItemsAsync(Guid productId)
    {
        var items = await uow.OrderItems.GetItemsByProductIdAsync(productId);
        return [.. items.Select(s => s.ToDto())];
    }

    public async Task<GetProductDto> GetProductAsync(Guid productId)
    {
        var product = await uow.Products.GetProductAsync(productId)
            ?? throw new NotFoundException();
        return product.ToDto();
    }

    public async Task<Guid> AddProductAsync(PostProductWrapperDto dto)
    {
        var product = dto.Product.ToModel();

        await uow.Products.AddProductAsync(product);
    
        var newSpecs = await CreateAll(dto.CreateSpecs, product);
    
        if (newSpecs.Count != dto.CreateSpecs.Count)
            throw new BadRequestException();
        
        foreach (var spec in newSpecs.Where(spec => !product.Specs.Contains(spec)))
        {
            product.Specs.Add(spec);
        }
    
        await uow.SaveChangesAsync();

        return product.Id;
    }
    
    public async Task DeleteProductAsync(Guid id)
    {
        var model = await uow.Products.GetProductAsync(id)
                    ?? throw new BadRequestException();
        
        uow.Products.DeleteProduct(model);
        
        await uow.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(PutProductWrapperDto dto)
    {
        var product = await uow.Products.GetProductAsync(dto.Product.ProductId)
                      ?? throw new BadRequestException();
    
        var newSpecs = await CreateAll(dto.CreateSpecs, product);
    
        if (newSpecs.Count != dto.CreateSpecs.Count)
            throw new BadRequestException();
        
        List<SpecModel> toUpdate = [.. await uow.Specs.GetAllSpecsByIdsAsync(dto.UpdateSpecs.Select(s => s.Id))];
    
        List<SpecModel> toRemove = [.. product.Specs.Where(s => !toUpdate.Contains(s) && !newSpecs.Contains(s))];
    
        for (var i = 0; i < toUpdate.Count; i++)
            toUpdate[i].Value = dto.UpdateSpecs[i].Value;
        
        foreach (var rm in toRemove)
            product.Specs.Remove(rm);
    
        uow.Specs.RemoveRange(toRemove);
        
        foreach (var spec in newSpecs.Where(spec => !product.Specs.Contains(spec)))
        {
            product.Specs.Add(spec);
        }
    
        product.UpdateWithDto(dto.Product);
    
        await uow.SaveChangesAsync();
    }

    private async Task<List<SpecModel>> CreateAll(List<PostSpecDto> dtos, ProductModel product)
    {
        if (dtos.Count == 0)
            return [];

        var specs = dtos.Select(d => d.ToModel(product)).ToList();
        
        for (var i = 0; i < specs.Count; i++)
        {
            specs[i].Names = new List<SpecNameModel>
            {
                new() {
                    Language = Language.English,
                    Name = dtos[i].Key,
                    Spec = specs[i]
                }
            };
        }
    
        await uow.Specs.AddRangeAsync(specs);
    
        return specs;
    }
}