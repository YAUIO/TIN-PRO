using Microsoft.EntityFrameworkCore;

namespace TIN.Data.Context;

public static class StoreSeedingExtensions
{
    public static DbContextOptionsBuilder UseStoreSeeding(this DbContextOptionsBuilder builder)
    {
        builder.UseSeeding((context, _) =>
        {
            
        });

        builder.UseAsyncSeeding(async (context, ct, _) =>
        {
            
        });

        return builder;
    }
}