using System.Text.Json;

namespace Weather.Api.Extensions;

public static class HttpResponseExtensions
{
    public static async Task<T?> ReadAsResponseDtoAsync<T>(this HttpResponseMessage res)
        where T : class
    {
        try
        {
            var stream = await res.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<T>(stream);

            return data;
        }
        catch
        {
            return null;
        }
    }
}