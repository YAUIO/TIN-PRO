using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Context;

public static class StoreSeedingExtensions
{
    public static DbContextOptionsBuilder UseStoreSeeding(this DbContextOptionsBuilder builder)
    {
        builder.UseSeeding((context, _) => context.SeedAllAsync().Wait());

        builder.UseAsyncSeeding(async (context, ct, _) => await context.SeedAllAsync());

        return builder;
    }

    private static async Task<DbContext> SeedAllAsync(this DbContext context)
    {
        await context.SeedProductsAsync();

        await context.SaveChangesAsync();
        
        return context;
    }

    private static async Task<DbContext> SeedProductsAsync(this DbContext context)
    {
        var r7id = Guid.Parse("022b90bb-011b-40ab-a99d-e95485da7e0c");
        
        List<ProductDescriptionModel> descriptions =
        [
            new()
            {
                ProductId = r7id,
                Description = "A processor.",
                Language = Language.English,
            },
            new()
            {
                ProductId = r7id,
                Description = "Procesor AMD",
                Language = Language.Polish,
            },
        ];

        var r7coreid = Guid.Parse("a8562645-b44d-473e-b37c-de457fe6b864");

        var r7corespecs = new SpecModel()
        {
            Id = r7coreid,
            Value = $"8/16",
        };
        
        List<SpecNameModel> r7speccorenames =
        [
            new()
            {
                Id = Guid.Parse("50d5a8fe-841c-41c6-a407-ab3b0ab212e1"),
                SpecId = r7corespecs.Id,
                Language = Language.English,
                Name = "Cores",
            },
            new()
            {
                Id = Guid.Parse("533ad5a1-666b-4baf-9f94-c5f460990be0"),
                SpecId = r7corespecs.Id,
                Language = Language.Polish,
                Name = "Liczba rdzeni",
            }
        ];

        r7corespecs.Names = r7speccorenames;
        
        List<SpecModel> r7specs =
        [
            r7corespecs,
        ];
        
        List<ProductModel> products =
        [
            new()
            {
                Id = r7id,
                Name = "Ryzen 7 5700x",
                ImageUri = "https://allegro.stati.pl/AllegroIMG/PRODUCENCI/AMD/100-100000926WOF/AMD-Ryzen-7-5700X-procesor-box-01.jpg",
                Price = 100,
                Descriptions = descriptions,
                Specs = r7specs,
            }
        ];

        await context.AddRangeAsync(products);

        return context;
    }
}