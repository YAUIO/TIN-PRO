namespace TIN.Core.Dtos;

public class PostProductDto
{
    public string Name { get; init; }
    
    public string ImageUri { get; init; }
    
    public string? Description { get; init; }

    public List<Guid> Specs { get; init; } = [];
}