using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.Product;

public class PostProductDto
{
    [Required]
    [Length(PutProductDto.MinStringLength, PutProductDto.MaxStringLength)]
    public string Name { get; set; }
    
    [Required]
    [Length(PutProductDto.MinStringLength, PutProductDto.MaxStringLength)]
    public string ImageUri { get; set; }
        
    [Range(typeof(decimal), "0.01", "1000000")]
    public decimal Price { get; set; }
    
    [MaxLength(4000)]
    public string? Description { get; set; }

    public List<Guid> Specs { get; set; } = [];
}