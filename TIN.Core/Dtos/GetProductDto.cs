namespace TIN.Core.Dtos;

public class GetProductDto
{
    public string Name { get; init; }
    
    public string ImageUri { get; init; }
    
    public string? Description { get; init; }

    public List<GetSpecDto> Specs { get; init; } = [];
}