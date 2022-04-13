using Core.Api.Resources.Extensions;
using Weather.Api.Configuration;
using Weather.Api.Modules.Location.Endpoints.Responses;
using Weather.Api.Modules.Location.Ports;

namespace Weather.Api.Modules.Location.Adapters;

public class LocationService : ILocationService
{
    private readonly ILogger<LocationService> _logger;
    private readonly HttpClient _httpClient;

    public LocationService(ILogger<LocationService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(configuration[ConfigurationProperties.LocationService]);
    }

    public async Task<GetAddressResponse?> Get(string address)
    {
        var response = await _httpClient.GetAsync($"onelineaddress?address={address}&benchmark=2020&format=json");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Address not found");
            return null;
        }

        var data = await response.ReadAsResponseDtoAsync<LocationServiceResponse>();
        if (data is null) return null;

        var addresses = data?.Result?.AddressMatches
            ?.Where(address => address.Coordinates is not null && address.MatchedAddress is not null).Select(address =>
                new GetAddressItemResponse(address!.Coordinates!.Latitude, address!.Coordinates!.Longitude,
                    address.MatchedAddress!)).ToArray();

        if (addresses is null) return null;

        return new GetAddressResponse(addresses);
    }
}