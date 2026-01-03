namespace TIN.Core.Dtos;

public class GetProductDto
{
    public Guid ProductId { get; init; }
    
    public string Name { get; init; }
    
    public string ImageUri { get; init; }
    
    public decimal Price { get; init; }
    
    public string? Description { get; init; }

    public List<GetSpecDto> Specs { get; init; } = [];
}