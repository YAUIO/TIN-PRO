using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;
using TIN.Data.Models;
using TIN.Data.Entities.Configurations;
using TIN.Data.Models.Enums;

namespace TIN.Data.Models;

[EntityTypeConfiguration(typeof(UserEntityConfiguration))]
public class UserModel
{
    public Guid Id { get; set; }
    
    public string Nickname { get; set; }
    
    public string PasswordHash { get; set; }
    
    public UserRole Role { get; set; }

    public virtual ICollection<OrderModel> Orders { get; set; } = [];
}