using System.Text.Json.Serialization;

namespace Weather.Api.Contracts.Response.LocationService;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Benchmark
{
    [JsonPropertyName("id")]
    public string id { get; set; }
    [JsonPropertyName("benchmarkName")]
    public string benchmarkName { get; set; }
    [JsonPropertyName("benchmarkDescription")]
    public string benchmarkDescription { get; set; }
    [JsonPropertyName("isDefault")]
    public bool isDefault { get; set; }
}

public class Address
{
    [JsonPropertyName("address")]
    public string address { get; set; }
}

public class Input
{
    [JsonPropertyName("side")]
    public Benchmark benchmark { get; set; }
    [JsonPropertyName("side")]
    public Address address { get; set; }
}

public class Coordinates
{
    [JsonPropertyName("x")]
    public double x { get; set; }
    [JsonPropertyName("y")]
    public double y { get; set; }
}

public class TigerLine
{
    [JsonPropertyName("tigerLineId")]
    public string tigerLineId { get; set; }
    [JsonPropertyName("side")]
    public string side { get; set; }
}

public class AddressComponents
{
    [JsonPropertyName("fromAddress")]
    public string fromAddress { get; set; }
    [JsonPropertyName("toAddress")]
    public string toAddress { get; set; }
    [JsonPropertyName("preQualifier")]
    public string preQualifier { get; set; }
    [JsonPropertyName("preDirection")]
    public string preDirection { get; set; }
    [JsonPropertyName("preType")]
    public string preType { get; set; }
    [JsonPropertyName("streetName")]
    public string streetName { get; set; }
    [JsonPropertyName("suffixType")]
    public string suffixType { get; set; }
    [JsonPropertyName("suffixDirection")]
    public string suffixDirection { get; set; }
    [JsonPropertyName("suffixQualifier")]
    public string suffixQualifier { get; set; }
    [JsonPropertyName("city")]
    public string city { get; set; }
    [JsonPropertyName("state")]
    public string state { get; set; }
    [JsonPropertyName("zip")]
    public string zip { get; set; }
}

public class AddressMatch
{
    [JsonPropertyName("matchedAddress")]
    public string matchedAddress { get; set; }
    [JsonPropertyName("coordinates")]
    public Coordinates coordinates { get; set; }
    [JsonPropertyName("tigerLine")]
    public TigerLine tigerLine { get; set; }
    [JsonPropertyName("addressComponents")]
    public AddressComponents addressComponents { get; set; }
}

public class Result
{
    [JsonPropertyName("input")]
    public Input input { get; set; }
    [JsonPropertyName("addressMatches")]
    public List<AddressMatch> addressMatches { get; set; }
}

public class Root
{
    [JsonPropertyName("result")]
    public Result result { get; set; }
}

