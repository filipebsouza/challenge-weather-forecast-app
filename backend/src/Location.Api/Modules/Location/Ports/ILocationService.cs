using Location.Api.Modules.Location.Endpoints.Responses;

namespace Location.Api.Modules.Location.Ports;

public interface ILocationService
{
    Task<GetAddressResponse?> Get(string address);
}