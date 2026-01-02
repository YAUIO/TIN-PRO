using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class ProductRepository(StoreDbContext context) : IProductRepository
{
    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<ProductModel?> GetProductAsync(Guid id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task AddProductAsync(ProductModel product)
    {
        await context.Products.AddAsync(product);
    }

    public void DeleteProduct(ProductModel product)
    {
        context.Products.Remove(product);
    }
}