using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(SpecEntityConfiguration))]
public class SpecModel
{
    public Guid Id { get; set; }

    public virtual ICollection<SpecNameModel> Names { get; set; } = [];
    
    public string Value { get; set; }
    
    public virtual ProductModel Product { get; set; }
}