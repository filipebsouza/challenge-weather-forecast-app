using System.Net;
using System.Text.Json.Serialization;

namespace Core.Api.Resources.Http.Responses;

public class HttpErrorResponse
{
    [JsonPropertyName("statusCode")] public int StatusCode { get; set; }

    [JsonPropertyName("message")] public string? Message { get; set; }

    public HttpErrorResponse(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int) statusCode;
        Message = message;
    }

    public HttpErrorResponse()
    {
    }
}