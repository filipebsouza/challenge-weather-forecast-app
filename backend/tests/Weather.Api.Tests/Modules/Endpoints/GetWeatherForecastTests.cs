using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Weather.Api.Configuration;
using Weather.Api.Modules.Forecast.Endpoints.Requests;
using Weather.Api.Tests._Configuration;
using Xunit;

namespace Weather.Api.Tests.Modules.Endpoints;

public class GetWeatherForecastTests
{
    private HttpClient? _client;
    private readonly string _endpoint;
    private readonly string _latitude;
    private readonly string _longitude;
    private readonly string _temperatureUnit;

    public GetWeatherForecastTests()
    {
        _endpoint = "/forecast";
        _latitude = "latitude=70";
        _longitude = "longitude=96";
        _temperatureUnit = "temperatureUnit=C";
    }

    [Fact]
    public async Task ShouldReturnValidationErrorWhenLatitudeIsInvalid()
    {
        _client = MockedWebApplicationSingleton.Instance.CreateClient();

        var response = await _client.GetAsync($"{_endpoint}?{_longitude}&{_temperatureUnit}");

        Assert.Equal(HttpStatusCode.BadRequest, response!.StatusCode);
    }
}