using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TIN.Core;

public static class CoreCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        return services;
    }
}