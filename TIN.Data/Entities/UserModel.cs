using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(UserEntityConfiguration))]
public class UserModel
{
    public Guid Id { get; set; }
    
    public string Nickname { get; set; }
    
    public string PasswordHash { get; set; }
    
    public UserRole Role { get; set; }

    public virtual ICollection<OrderModel> Orders { get; set; } = [];
}