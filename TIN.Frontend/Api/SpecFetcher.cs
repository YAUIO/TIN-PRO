using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using TIN.Core.Dtos.Product;
using TIN.Frontend.Options;

namespace TIN.Frontend.Api;

public class SpecFetcher(IOptions<ApiOptions> options, IApiFetcher api) : ISpecFetcher
{
    private readonly ApiOptions _apicfg = options.Value;

    private static readonly JsonSerializerOptions Options = new();

    static SpecFetcher()
    {
        Options.Converters.Add(new JsonStringEnumConverter());
    }
    
    
    public async Task<List<Guid>> CreateAllSpecsAsync(List<PostSpecDto> specs)
    {
        if (specs.Count == 0)
            return [];
        
        var json = await api.PostAsync(_apicfg.Specs, specs);

        return string.IsNullOrEmpty(json) ? 
            [] : 
            JsonSerializer.Deserialize<List<Guid>>(json, Options)!;
    }

    public async Task UpdateSpecsAsync(List<GetSpecDto> specs)
    {
        await api.UpdateAsync(_apicfg.Specs, specs);
    }
}