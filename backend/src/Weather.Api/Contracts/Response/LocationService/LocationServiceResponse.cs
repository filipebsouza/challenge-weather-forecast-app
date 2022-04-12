using System.Text.Json.Serialization;

namespace Weather.Api.Contracts.Response.LocationService;

public class Benchmark
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("benchmarkName")]
    public string BenchmarkName { get; set; }
    [JsonPropertyName("benchmarkDescription")]
    public string BenchmarkDescription { get; set; }
    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }
}

public class Address
{
    [JsonPropertyName("address")]
    public string Description { get; set; }
}

public class Input
{
    [JsonPropertyName("benchmark")]
    public Benchmark Benchmark { get; set; }
    [JsonPropertyName("address")]
    public Address Address { get; set; }
}

public class Coordinates
{
    [JsonPropertyName("x")]
    public double Longitude { get; set; }
    [JsonPropertyName("y")]
    public double Latitude { get; set; }
}

public class TigerLine
{
    [JsonPropertyName("tigerLineId")]
    public string TigerLineId { get; set; }
    [JsonPropertyName("side")]
    public string Side { get; set; }
}

public class AddressComponents
{
    [JsonPropertyName("fromAddress")]
    public string FromAddress { get; set; }
    [JsonPropertyName("toAddress")]
    public string ToAddress { get; set; }
    [JsonPropertyName("preQualifier")]
    public string PreQualifier { get; set; }
    [JsonPropertyName("preDirection")]
    public string PreDirection { get; set; }
    [JsonPropertyName("preType")]
    public string PreType { get; set; }
    [JsonPropertyName("streetName")]
    public string StreetName { get; set; }
    [JsonPropertyName("suffixType")]
    public string SuffixType { get; set; }
    [JsonPropertyName("suffixDirection")]
    public string SuffixDirection { get; set; }
    [JsonPropertyName("suffixQualifier")]
    public string SuffixQualifier { get; set; }
    [JsonPropertyName("city")]
    public string City { get; set; }
    [JsonPropertyName("state")]
    public string State { get; set; }
    [JsonPropertyName("zip")]
    public string Zip { get; set; }
}

public class AddressMatch
{
    [JsonPropertyName("matchedAddress")]
    public string MatchedAddress { get; set; }
    [JsonPropertyName("coordinates")]
    public Coordinates Coordinates { get; set; }
    [JsonPropertyName("tigerLine")]
    public TigerLine TigerLine { get; set; }
    [JsonPropertyName("addressComponents")]
    public AddressComponents AddressComponents { get; set; }
}

public class Result
{
    [JsonPropertyName("input")]
    public Input Input { get; set; }
    [JsonPropertyName("addressMatches")]
    public List<AddressMatch> AddressMatches { get; set; }
}

public class LocationServiceResponse
{
    [JsonPropertyName("result")]
    public Result Result { get; set; }
}

