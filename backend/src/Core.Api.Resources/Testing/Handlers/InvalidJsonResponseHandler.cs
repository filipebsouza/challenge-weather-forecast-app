using System.Net;
using System.Text;
using System.Text.Json;

namespace Core.Api.Resources.Testing.Handlers;

public class InvalidJsonResponseHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new {wrong = "json"};
        var taskCompletion = new TaskCompletionSource<HttpResponseMessage>();
        taskCompletion.SetResult(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(response), Encoding.UTF8, "application/json"),
        });
        
        return taskCompletion.Task;
    }
}