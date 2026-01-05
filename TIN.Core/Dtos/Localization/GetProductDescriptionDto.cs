using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.Localization;

public class GetProductDescriptionDto
{
    public Guid ProductId { get; init; }
    
    public string Description { get; init; }
    
    public Language Language { get; init; }
}