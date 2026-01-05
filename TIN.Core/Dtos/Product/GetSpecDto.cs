namespace TIN.Core.Dtos.Product;

public class GetSpecDto
{
    public Guid Id { get; init; }
    
    public string Key { get; init; }
    
    public string Value { get; set; }
}