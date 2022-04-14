using System.Text.Json.Serialization;

namespace Location.Api.Modules.Location.Endpoints.Responses;

public class GetLocationResponse
{
    [JsonPropertyName("addresses")] public GetLocationItemResponse[] Addresses { get; set; } = null!;
}

public class GetLocationItemResponse
{
    [JsonPropertyName("latitude")] public double Latitude { get; set; }
    [JsonPropertyName("longitude")] public double Longitude { get; set; }
    [JsonPropertyName("completeAddress")] public string CompleteAddress { get; set; } = null!;
}