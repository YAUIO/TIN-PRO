using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TIN.Data.Entities.Configurations;

public class SpecEntityConfiguration : IEntityTypeConfiguration<SpecModel>
{
    public void Configure(EntityTypeBuilder<SpecModel> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.HasMany(s => s.Names)
            .WithOne(s => s.Spec)
            .HasForeignKey(s => s.SpecId);

        builder.Property(s => s.Value)
            .HasMaxLength(100);
    }
}