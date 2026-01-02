using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(ProductDescriptionEntityConfiguration))]
public class ProductDescriptionModel
{
    public Guid ProductId { get; set; }
    
    public string Description { get; set; }
    
    public Language Language { get; set; }
    
    public virtual ProductModel Product { get; set; }
}