using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TIN.Data.Entities.Configurations;

public class ProductDescriptionEntityConfiguration : IEntityTypeConfiguration<ProductDescriptionModel>
{
    public void Configure(EntityTypeBuilder<ProductDescriptionModel> builder)
    {
        builder.ToTable("ProductDescription");
        
        builder.HasKey(s => new { s.ProductId, s.Language });
        
        builder.Property(p => p.Description)
            .HasMaxLength(4000);
    }
}