using Location.Api.Modules.Location.Endpoints.Responses;

namespace Location.Api.Modules.Location.Ports;

public interface ILocationService
{
    Task<GetLocationResponse?> Get(string address);
}