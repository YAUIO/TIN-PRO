using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Context;

public static class StoreSeedingExtensions
{
    private static readonly UserModel Admin = new()
    {
        Id = Guid.Parse("A02F8C91-7070-4EDE-B004-677D7515467E"),
        Nickname = "yauio",
        PasswordHash = "AQAAAAIAAYagAAAAEE+73d0BPjbmhj5JwZn+GguB0nPf5qMGuXTQenbtbcQqT3Vbs6b7PwaS49UYny2VYA==",
        Role = UserRole.Administrator
    };
    
    private static List<ProductModel> Products = [];

    public static DbContextOptionsBuilder UseStoreSeeding(this DbContextOptionsBuilder builder)
    {
        builder.UseSeeding((context, _) => context.SeedAllAsync().Wait());

        builder.UseAsyncSeeding(async (context, ct, _) => await context.SeedAllAsync());

        return builder;
    }

    extension(DbContext context)
    {
        private async Task<DbContext> SeedAllAsync()
        {
            await context.SeedProductsAsync();
            
            await context.SeedOrdersAsync();

            await context.SeedUsersAsync();

            await context.SaveChangesAsync();

            return context;
        }

        private async Task<DbContext> SeedProductsAsync()
        {
            var r7id = Guid.Parse("022b90bb-011b-40ab-a99d-e95485da7e0c");

            List<ProductDescriptionModel> descriptions =
            [
                new()
                {
                    ProductId = r7id,
                    Description = "A processor.",
                    Language = Language.English
                },
                new()
                {
                    ProductId = r7id,
                    Description = "Procesor AMD",
                    Language = Language.Polish
                }
            ];

            var r7coreid = Guid.Parse("a8562645-b44d-473e-b37c-de457fe6b864");

            var r7corespecs = new SpecModel
            {
                Id = r7coreid,
                Value = "8/16"
            };

            List<SpecNameModel> r7speccorenames =
            [
                new()
                {
                    Id = Guid.Parse("50d5a8fe-841c-41c6-a407-ab3b0ab212e1"),
                    SpecId = r7corespecs.Id,
                    Language = Language.English,
                    Name = "Cores"
                },
                new()
                {
                    Id = Guid.Parse("533ad5a1-666b-4baf-9f94-c5f460990be0"),
                    SpecId = r7corespecs.Id,
                    Language = Language.Polish,
                    Name = "Liczba rdzeni"
                }
            ];

            r7corespecs.Names = r7speccorenames;

            List<SpecModel> r7specs =
            [
                r7corespecs
            ];

            List<SpecModel> dspecs =
            [
                new()
                {
                    Id = Guid.Parse("0893119b-0569-4eb3-a260-cfbc0f73c976"),
                    Value = "360mm",
                    Names =
                    [
                        new SpecNameModel
                        {
                            Id = Guid.Parse("5e48ebd4-c664-414f-87c4-c5f1c7d95c10"),
                            Name = "Length",
                            Language = Language.English,
                            SpecId = Guid.Parse("0893119b-0569-4eb3-a260-cfbc0f73c976")
                        },
                        new SpecNameModel
                        {
                            Id = Guid.Parse("269eff68-b9f5-4894-9949-b915a36813a1"),
                            Name = "Długość",
                            Language = Language.Polish,
                            SpecId = Guid.Parse("0893119b-0569-4eb3-a260-cfbc0f73c976")
                        }
                    ]
                }
            ];
            
            Products =
            [
                new()
                {
                    Id = r7id,
                    Name = "Ryzen 7 5700x",
                    ImageUri =
                        "https://allegro.stati.pl/AllegroIMG/PRODUCENCI/AMD/100-100000926WOF/AMD-Ryzen-7-5700X-procesor-box-01.jpg",
                    Price = 100,
                    Descriptions = descriptions,
                    Specs = r7specs
                },
                new()
                {
                    Id = Guid.Parse("eb43d56a-e064-43ea-94d3-fd4646a7ea49"),
                    Name = "RTX 5090",
                    ImageUri = "https://assets.nvidia.partners/images/png/RTX5090-3QTR-Back-Left-small.png",
                    Price = 1000,
                    Descriptions = [],
                    Specs = dspecs,
                }
            ];

            if (!context.Set<ProductModel>().Any())
                await context.AddRangeAsync(Products);

            return context;
        }

        private async Task<DbContext> SeedUsersAsync()
        {
            List<UserModel> users =
            [
                new()
                {
                    Id = Guid.Parse("1d75c874-5589-4c93-a243-09ad0c545127"),
                    Nickname = "Michael",
                    PasswordHash = "impossible-hash-just-for-seed",
                    Role = UserRole.Customer
                },
                new()
                {
                    Id = Guid.Parse("bcd9d471-4190-44e1-a9ec-eecfa057d285"),
                    Nickname = "Alexander",
                    PasswordHash = "impossible-hash-just-for-seed",
                    Role = UserRole.Customer
                },
                Admin
            ];

            if (!context.Set<UserModel>().Any())
                await context.AddRangeAsync(users);

            return context;
        }

        private async Task<DbContext> SeedOrdersAsync()
        {
            List<OrderModel> orders =
            [
                new()
                {
                    Id = Guid.Parse("bc318af7-7cc0-402f-8de0-d4542be5abbf"),
                    CreatedAt = new DateTime(2026, 1, 6, 14, 0, 0, DateTimeKind.Utc),
                    CompletedAt = null,
                    Customer = Admin,
                    Items = 
                    [
                        new() {
                            ProductId = Products[0].Id,
                            Quantity = 6,
                        },
                        new() {
                            ProductId = Products[1].Id,
                            Quantity = 8,
                        },
                    ]
                }
            ];

            if (!context.Set<OrderModel>().Any())
                await context.AddRangeAsync(orders);

            return context;
        }
    }
}
