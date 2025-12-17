using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TIN.Data.Context;

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
        
        return services;
    }
}