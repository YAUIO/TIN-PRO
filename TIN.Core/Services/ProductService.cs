using Microsoft.Extensions.Logging;
using TIN.Core.Dtos.Order;
using TIN.Core.Dtos.Product;
using TIN.Core.Exceptions;
using TIN.Core.Mappings;
using TIN.Data.Context;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Services;

public class ProductService(IUnitOfWork uow, ILogger<ProductService> logger) : IProductService
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

    public async Task<Guid> AddProductAsync(PostProductDto product)
    {
        var model = product.ToModel();

        var specs = await uow.Specs.GetAllSpecsByIdsAsync(product.Specs);

        model.Specs = [.. specs];

        if (product.Description != null)
            model.Descriptions =
            [
                new()
                {
                    Description = product.Description,
                    Language = Language.English,
                    Product = model,
                }
            ];

        await uow.Products.AddProductAsync(model);
        
        await uow.SaveChangesAsync();
        
        return model.Id;
    }

    public async Task UpdateProductAsync(PutProductDto product)
    {
        var model = await uow.Products.GetProductAsync(product.ProductId)
            ?? throw new BadRequestException();
        
        model.UpdateWithDto(product);
        
        var specs = await uow.Specs.GetAllSpecsByIdsAsync(product.Specs);

        model.Specs = [.. specs];
        
        await uow.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var model = await uow.Products.GetProductAsync(id)
                    ?? throw new BadRequestException();
        
        uow.Products.DeleteProduct(model);
        
        await uow.SaveChangesAsync();
    }
}