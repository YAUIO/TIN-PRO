using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.Product;

public class PutProductDto
{
    public const int MinStringLength = 4;
    public const int MaxStringLength = 400;
    
    public Guid ProductId { get; init; }
    
    [Required]
    [Length(MinStringLength, MaxStringLength)]
    public string Name { get; set; }
    
    [Required]
    [Length(MinStringLength, MaxStringLength)]
    public string ImageUri { get; set; }
        
    [Range(typeof(decimal), "0.01", "1000000")]
    public decimal Price { get; set; }
    
    public List<Guid> Specs { get; set; } = [];
}