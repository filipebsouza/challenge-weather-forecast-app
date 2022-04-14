using Core.Api.Resources.Extensions;
using Location.Api.Configuration;
using Location.Api.Modules.Location.Endpoints.Responses;
using Location.Api.Modules.Location.Ports;

namespace Location.Api.Modules.Location.Adapters;

public class LocationService : ILocationService
{
    private readonly ILogger<LocationService> _logger;
    private readonly HttpClient _httpClient;

    public LocationService(ILogger<LocationService> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        _httpClient = factory.CreateClient(ConfigurationProperties.LocationServiceHttpClientName);
    }

    public async Task<GetLocationResponse?> Get(string address)
    {
        var response = await _httpClient.GetAsync($"onelineaddress?address={address}&benchmark=2020&format=json");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Address not found");
            return null;
        }

        var data = await response.ReadAsResponseDtoAsync<LocationServiceResponse>();
        if (data is null || data.Result is null)
        {
            _logger.LogInformation($"Json parse error from {nameof(LocationService)}");
            return null;
        }

        var addresses = data?.Result?.AddressMatches
            ?.Where(a => a.Coordinates is not null && a.MatchedAddress is not null).Select(a =>
                new GetLocationItemResponse
                {
                    Latitude = a!.Coordinates!.Latitude,
                    Longitude = a!.Coordinates!.Longitude,
                    CompleteAddress = a.MatchedAddress!
                }).ToArray();

        if (addresses is null)
        {
            _logger.LogInformation("Invalid addresses!");
            return null;
        }

        return new GetLocationResponse
        {
            Addresses = addresses
        };
    }
}