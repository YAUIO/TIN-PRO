namespace TIN.Core.Dtos.Product;

public class PutSpecsDto
{
    public Guid ProductId { get; init; }
    
    public List<GetSpecDto> Specs { get; init; }
}