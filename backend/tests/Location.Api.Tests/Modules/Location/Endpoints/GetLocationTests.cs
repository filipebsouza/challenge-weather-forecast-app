using System;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Api.Resources.Extensions;
using Core.Api.Resources.Http.Responses;
using Core.Api.Resources.Testing.Handlers;
using Location.Api.Configuration;
using Location.Api.Modules.Location.Endpoints.Responses;
using Location.Api.Tests._Configuration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Location.Api.Tests.Modules.Location.Endpoints;

public class GetLocationTests
{
    private readonly string _endpoint;
    private readonly string _address;
    private HttpClient _httpClient;

    public GetLocationTests()
    {
        _endpoint = "/location";
        _address = "address=555 Hubbard Ave-Suite 12, Pittsfield MA 1201";
        _httpClient = MockedWebApplicationSingleton.Instance.CreateClient();
    }

    [Fact]
    public async Task ShouldReturnValidationErrorWhenAddressIsNull()
    {
        const string expectedErrorMessage = "'address' must not be null or empty";

        var response = await _httpClient.GetAsync($"{_endpoint}");

        var errorResponse = await response!.ReadAsResponseDtoAsync<HttpErrorResponse>();
        Assert.Contains(expectedErrorMessage, errorResponse!.Message!);
    }

    [Fact]
    public async Task ShouldReturnValidLocationWhenAllRequiredQueryParamsAreValid()
    {
        var response = await _httpClient.GetAsync($"{_endpoint}?{_address}");

        var successfulResponse = await response!.ReadAsResponseDtoAsync<GetLocationResponse>();
        Assert.NotEmpty(successfulResponse!.Addresses);
    }

    [Fact]
    public async Task ShouldReturnErrorWhenLocationServiceResponseIsInvalid()
    {
        const string expectedErrorMessage = "Unexpected error during getting location";
        _httpClient = MockedWebApplicationSingleton.Instance.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<InvalidJsonResponseHandler>();
                services.AddHttpClient(ConfigurationProperties.LocationServiceHttpClientName,
                        c => c.BaseAddress = new Uri(MockedWebApplication.LocationServiceHost))
                    .AddHttpMessageHandler<InvalidJsonResponseHandler>();
            });
        }).CreateClient();

        var response = await _httpClient.GetAsync($"{_endpoint}?{_address}");

        var errorResponse = await response!.ReadAsResponseDtoAsync<HttpErrorResponse>();
        Assert.Equal(expectedErrorMessage, errorResponse!.Message);
    }
}