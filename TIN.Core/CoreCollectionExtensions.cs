using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TIN.Core.Services;
using TIN.Data.Entities;

namespace TIN.Core;

public static class CoreCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IAuthService, AuthService>();
        
        services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
        
        return services;
    }
}