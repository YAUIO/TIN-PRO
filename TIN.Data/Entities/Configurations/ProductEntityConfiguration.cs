using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TIN.Data.Entities.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.ImageUri)
            .HasMaxLength(400);

        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(4000);

        builder.HasMany(p => p.Specs)
            .WithOne(s => s.Product);
        
        builder.HasMany(p => p.Orders)
            .WithOne(o => o.Product);
    }
}