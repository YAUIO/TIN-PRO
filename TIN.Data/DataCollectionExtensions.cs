using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TIN.Data.Context;
using TIN.Data.Repositories;

namespace TIN.Data;

public static class DataCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreDbContext>(builder =>
        {
            builder.UseSqlite(configuration.GetConnectionString("Default"));
            builder.UseStoreSeeding();
        });
        
        services.AddScoped<IUserRepository,  UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
        
        services.AddScoped<IUnitOfWork, StoreUnitOfWork>();
        
        return services;
    }
}