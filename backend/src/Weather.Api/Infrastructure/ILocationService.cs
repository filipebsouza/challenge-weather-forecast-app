using Weather.Api.Contracts.Response;

namespace Weather.Api.Infrastructure;

public interface ILocationService
{
    Task<LocationResponse?> Get(string address);
}