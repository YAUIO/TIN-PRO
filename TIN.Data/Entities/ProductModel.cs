using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(ProductEntityConfiguration))]
public class ProductModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string ImageUri { get; set; }
    
    public decimal Price { get; set; }

    public virtual ICollection<ProductDescriptionModel> Descriptions { get; set; } = [];

    public ICollection<SpecModel> Specs { get; set; } = [];
    
    public ICollection<OrderItemModel> Orders { get; set; } = [];
}