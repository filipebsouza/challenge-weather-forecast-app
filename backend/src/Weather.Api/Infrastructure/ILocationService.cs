using Weather.Api.Contracts.Response;

namespace Weather.Api.Infrastructure;

public interface ILocationService
{
    Task<LocationApiResponse?> Get(string address);
}