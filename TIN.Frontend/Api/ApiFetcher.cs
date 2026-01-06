using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TIN.Frontend.Api;

public class ApiFetcher(HttpClient http) : IApiFetcher
{
    public static readonly JsonSerializerOptions Options = new(){
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
    
    public async Task<T> FetchAsync<T>(string path)
    {
        var result = await http.GetFromJsonAsync<T>(path, Options);

        return result!;
    }
    
    public async Task UpdateAsync(string path, object json)
    {
        var result = await http.PutAsJsonAsync(path, json);
        result.EnsureSuccessStatusCode();
    }
    
    public async Task CreateAsync(string path, object json)
    {
        var result = await http.PostAsJsonAsync(path, json);
        result.EnsureSuccessStatusCode();
    }

    public async Task<string> PostAsync(string path, object json)
    {
        var result = await http.PostAsJsonAsync(path, json);
        result.EnsureSuccessStatusCode();

        return await result.Content.ReadAsStringAsync();
    }

    public async Task DeleteAsync(string path, string id)
    {
        var result = await http.DeleteAsync($"{path}/{id}");
        result.EnsureSuccessStatusCode();
    }
}