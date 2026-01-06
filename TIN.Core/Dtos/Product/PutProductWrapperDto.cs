namespace TIN.Core.Dtos.Product;

public class PutProductWrapperDto
{
    public PutProductDto Product { get; init; }
    
    public List<GetSpecDto> UpdateSpecs { get; init; }
    
    public List<PostSpecDto> CreateSpecs { get; init; }
}