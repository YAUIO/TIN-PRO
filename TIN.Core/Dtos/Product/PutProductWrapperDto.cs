using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.Product;

public class PutProductWrapperDto
{
    [Required]
    public PutProductDto Product { get; init; }
    
    [Required]
    public List<GetSpecDto> UpdateSpecs { get; init; }
    
    [Required]
    public List<PostSpecDto> CreateSpecs { get; init; }
}