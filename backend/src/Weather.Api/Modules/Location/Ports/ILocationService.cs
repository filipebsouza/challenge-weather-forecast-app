using Weather.Api.Modules.Location.Endpoints;
using Weather.Api.Modules.Location.Endpoints.Responses;

namespace Weather.Api.Modules.Location.Ports;

public interface ILocationService
{
    Task<GetAddressResponse?> Get(string address);
}