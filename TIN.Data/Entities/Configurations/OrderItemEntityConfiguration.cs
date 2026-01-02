using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TIN.Data.Entities.Configurations;

public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemModel>
{
    public void Configure(EntityTypeBuilder<OrderItemModel> builder)
    {
        builder.HasKey(x => new { x.OrderId, x.ProductId });
        
        builder.Property(x => x.Quantity)
            .IsRequired(true);
    }
}