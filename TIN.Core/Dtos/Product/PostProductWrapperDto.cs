using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.Product;

public class PostProductWrapperDto
{
    [Required]
    public PostProductDto Product { get; init; }
    
    [Required]
    public List<PostSpecDto> CreateSpecs { get; init; }
}