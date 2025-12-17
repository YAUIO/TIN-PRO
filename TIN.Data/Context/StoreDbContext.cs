using Microsoft.EntityFrameworkCore;
using TIN.Data.Models;

namespace TIN.Data.Context;

public class StoreDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<OrderModel> Orders => Set<OrderModel>();
    
    public DbSet<ProductModel> Products => Set<ProductModel>();
    
    public DbSet<UserModel> Users => Set<UserModel>();
}