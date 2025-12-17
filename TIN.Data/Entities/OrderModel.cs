using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(OrderEntityConfiguration))]
public class OrderModel
{
    public Guid Id { get; set; }

    // Not DateTimeOffset because SQLite doesn't know about its existence, use SQLServer :D
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime? CompletedAt { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Created;
    
    public virtual UserModel Customer { get; set; }
}