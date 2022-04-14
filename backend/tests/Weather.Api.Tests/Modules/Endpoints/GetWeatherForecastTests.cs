using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Api.Resources.Extensions;
using Core.Api.Resources.Http.Responses;
using Weather.Api.Modules.Forecast.Endpoints.Responses;
using Weather.Api.Tests._Configuration;
using Xunit;

namespace Weather.Api.Tests.Modules.Endpoints;

public class GetWeatherForecastTests
{
    private readonly HttpClient _client;
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
        _client = MockedWebApplicationSingleton.Instance.CreateClient();
    }

    [Fact]
    public async Task ShouldReturnValidationErrorWhenLatitudeIsNull()
    {
        const string expectedErrorMessage = "'latitude' must not be null";

        var response = await _client.GetAsync($"{_endpoint}?{_longitude}&{_temperatureUnit}");

        var errorResponse = await response!.ReadAsResponseDtoAsync<HttpErrorResponse>();
        Assert.Contains(expectedErrorMessage, errorResponse!.Message!);
    }

    [Fact]
    public async Task ShouldReturnValidationErrorWhenLongitudeIsNull()
    {
        const string expectedErrorMessage = "'longitude' must not be null";

        var response = await _client.GetAsync($"{_endpoint}?{_latitude}&{_temperatureUnit}");

        var errorResponse = await response!.ReadAsResponseDtoAsync<HttpErrorResponse>();
        Assert.Contains(expectedErrorMessage, errorResponse!.Message!);
    }

    [Fact]
    public async Task ShouldReturnValidationErrorWhenTemperatureUnitIsNull()
    {
        const string expectedErrorMessage = "'temperatureUnit' must not be null";

        var response = await _client.GetAsync($"{_endpoint}?{_latitude}&{_longitude}");

        var errorResponse = await response!.ReadAsResponseDtoAsync<HttpErrorResponse>();
        Assert.Contains(expectedErrorMessage, errorResponse!.Message!);
    }

    [Theory]
    [InlineData("&temperatureUnit=G")]
    [InlineData("&temperatureUnit=5")]
    public async Task ShouldReturnValidationErrorWhenTemperatureUnitIsDifferentThanCelsiusOrFahrenheit(
        string invalidTemperatureUnit)
    {
        const string expectedErrorMessage = "'temperatureUnit' must be equals to C or F";

        var response = await _client.GetAsync($"{_endpoint}?{_latitude}&{_longitude}{invalidTemperatureUnit}");

        var errorResponse = await response!.ReadAsResponseDtoAsync<HttpErrorResponse>();
        Assert.Contains(expectedErrorMessage, errorResponse!.Message!);
    }
    
    [Fact]
    public async Task ShouldReturnValidWeatherForecastWhenAllRequiredQueryParamsAreValid()
    {
        var response = await _client.GetAsync($"{_endpoint}?{_latitude}&{_longitude}&{_temperatureUnit}");

        var successfulResponse = await response!.ReadAsResponseDtoAsync<GetWeatherForecastResponse>();
        Assert.NotEmpty(successfulResponse!.Days);
    }
}