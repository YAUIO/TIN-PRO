namespace TIN.Core.Dtos.Product;

public class PostProductDto
{
    public string Name { get; set; }
    
    public string ImageUri { get; set; }
        
    public decimal Price { get; set; }
    
    public string? Description { get; set; }

    public List<Guid> Specs { get; set; } = [];
}