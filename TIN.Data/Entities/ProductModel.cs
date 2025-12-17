using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(ProductEntityConfiguration))]
public class ProductModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string ImageUri { get; set; }
    
    public string? Description { get; set; }

    public ICollection<SpecModel> Specs { get; set; } = [];
}