using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TIN.Data.Entities.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Nickname)
            .HasMaxLength(20);
        
        builder.HasIndex(u => u.Nickname)
            .IsUnique();

        builder.Property(u => u.PasswordHash)
            .HasMaxLength(100);
    }
}