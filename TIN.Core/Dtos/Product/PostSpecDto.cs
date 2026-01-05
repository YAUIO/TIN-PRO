using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.Product;

public class PostSpecDto
{
    [Required]
    public Guid ProductId { get; set; }
    
    [Required]
    [Length(4, 100)]
    public string Key { get; set; }
    
    [Required]
    [Length(4, 100)]
    public string Value { get; set; }
}