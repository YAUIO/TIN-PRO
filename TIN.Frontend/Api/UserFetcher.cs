using Microsoft.Extensions.Options;
using TIN.Core.Dtos;
using TIN.Core.Dtos.User;
using TIN.Frontend.Options;

namespace TIN.Frontend.Api;

public class UserFetcher(IOptions<ApiOptions> options, IApiFetcher api) : IUserFetcher
{
    private readonly ApiOptions _apicfg = options.Value;

    public async Task<IEnumerable<GetUserDto>?> GetAllUsersAsync()
    {
        try
        {
            return await api.FetchAsync<IEnumerable<GetUserDto>>(_apicfg.Users);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<IEnumerable<GetUserDto>?> GetAllUsersAsync(PaginationDto? dto)
    {
        try
        {
            return await api.FetchAsync<IEnumerable<GetUserDto>>($"{_apicfg.Users}/{dto?.PageSize ?? int.MaxValue}/{dto?.Page ?? 1}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<GetUserDto?> GetUserAsync(Guid id)
    {
        try
        {
            return await api.FetchAsync<GetUserDto>($"{_apicfg.Users}/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task MakeAdminAsync(Guid id)
    {
        await api.UpdateAsync($"{_apicfg.Users}/{id}/admin", new {});
    }
}