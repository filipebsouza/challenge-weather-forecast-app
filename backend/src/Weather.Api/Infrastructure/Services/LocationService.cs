using Weather.Api.Configuration;
using Weather.Api.Contracts.Response;
using Weather.Api.Contracts.Response.LocationService;
using Weather.Api.Extensions;

namespace Weather.Api.Infrastructure.Services;

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

    public async Task<LocationApiResponse?> Get(string address)
    {
        var response = await _httpClient.GetAsync($"onelineaddress?address={address}&benchmark=2020&format=json");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Address not found");
            return null;
        }

        var data = await response.ReadAsResponseDtoAsync<LocationServiceResponse>();
        if (data is null) return null;

        var addresses = data.Result.AddressMatches.Select(address =>
            new LocationApiAddressResponse(address.Coordinates.Latitude, address.Coordinates.Longitude,
                address.MatchedAddress)).ToArray();

        return new LocationApiResponse(addresses);
    }
}