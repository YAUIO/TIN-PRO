using Microsoft.EntityFrameworkCore;
using TIN.Data.Context;
using TIN.Data.Entities;

namespace TIN.Data.Repositories;

public class ProductRepository(StoreDbContext context) : IProductRepository
{
    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        return await context.Products
            .Include(p => p.Descriptions)
            .Include(p => p.Specs)
            .ThenInclude(s => s.Names)
            .ToListAsync();
    }

    public async Task<ProductModel?> GetProductAsync(Guid id)
    {
        return await context.Products
            .Include(p => p.Descriptions)
            .Include(p => p.Specs)
            .ThenInclude(s => s.Names)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
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