using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities;

namespace TIN.Data.Context;

public class StoreDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<OrderModel> Orders => Set<OrderModel>();
    
    public DbSet<OrderItemModel> OrderItems => Set<OrderItemModel>();
    
    public DbSet<ProductModel> Products => Set<ProductModel>();
 
    private DbSet<SpecModel> Specs => Set<SpecModel>();
    
    public DbSet<UserModel> Users => Set<UserModel>();
}