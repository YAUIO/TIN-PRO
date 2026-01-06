namespace TIN.Core.Dtos.Product;

public class PostProductWrapperDto
{
    public PostProductDto Product { get; init; }
    
    public List<PostSpecDto> CreateSpecs { get; init; }
}