using TIN.Core.Dtos.Product;

namespace TIN.Frontend.Api;

public interface ISpecFetcher
{
    Task<List<Guid>> CreateAllSpecsAsync(List<PostSpecDto> specs);
    Task UpdateSpecsAsync(List<GetSpecDto> specs);
}