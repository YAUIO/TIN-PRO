using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TIN.Data.Entities.Configurations;

public class SpecNameEntityConfiguration : IEntityTypeConfiguration<SpecNameModel>
{
    public void Configure(EntityTypeBuilder<SpecNameModel> builder)
    {
        builder.ToTable("SpecNames");

        builder.HasKey(s => new { s.Name, s.Language });
        
        builder.Property(s => s.Name)
            .IsRequired(true)
            .HasMaxLength(100);

        builder.Property(s => s.Language)
            .IsRequired(true);
    }
}