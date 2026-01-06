using TIN.Core.Dtos.Product;

namespace TIN.Core.Services;

public interface ISpecService
{
    Task<List<Guid>> CreateAllSpecsAsync(List<PostSpecDto> dtos);
    
    Task UpdateAllSpecsAsync(PutSpecsDto dto);
}