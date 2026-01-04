namespace TIN.Frontend.Api;

public interface IApiFetcher
{
    Task<T> FetchAsync<T>(string path);

    Task UpdateAsync(string path, object json);

    Task CreateAsync(string path, object json);
    
    Task<string> PostAsync(string path, object json);

    Task DeleteAsync(string path, string id);
}