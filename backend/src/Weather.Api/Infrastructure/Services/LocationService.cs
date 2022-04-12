using Weather.Api.Configuration;
using Weather.Api.Contracts.Response;
using Weather.Api.Extensions;

namespace Weather.Api.Infrastructure.Services;

public class LocationService : ILocationService
{
    private readonly ILogger<LocationService> _logger;
    private readonly HttpClient _httpClient;

    public LocationService(ILogger<LocationService> logger, IConfiguration configuration, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(configuration[ConfigurationProperties.LocationService]);
    }

    public async Task<LocationResponse?> Get(string address)
    {
        var response = await _httpClient.GetAsync($"&address={address}");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Address not found");
            return null;
        }

        response.ReadAsResponseDtoAsync<>();

        
        throw new NotImplementedException();
    }
}

