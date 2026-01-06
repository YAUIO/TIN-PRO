using Microsoft.EntityFrameworkCore;
using TIN.Data.Entities.Configurations;
using TIN.Data.Entities.Enums;

namespace TIN.Data.Entities;

[EntityTypeConfiguration(typeof(SpecNameEntityConfiguration))]
public class SpecNameModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Language Language { get; set; }
    
    public Guid SpecId { get; set; }
    
    public virtual SpecModel Spec { get; set; }
}