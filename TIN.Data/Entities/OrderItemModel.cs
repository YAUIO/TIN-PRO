using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(OrderItemEntityConfiguration))]
public class OrderItemModel
{
    public Guid OrderId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    public virtual ProductModel Product { get; set; }
    
    public virtual OrderModel Order { get; set; }
}