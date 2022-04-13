using System.Net;
using System.Runtime.Serialization;

namespace Core.Api.Resources.Http.Exceptions;

[Serializable]
public class HttpException : Exception
{
    private readonly HttpStatusCode _statusCode;

    public HttpStatusCode StatusCode => _statusCode;

    public HttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        _statusCode = statusCode;
    }

    public HttpException(HttpStatusCode statusCode, string message, object? details) : base(message)
    {
        _statusCode = statusCode;
    }

    protected HttpException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        var statusCode = info.GetValue("StatusCode", typeof(HttpStatusCode));
        _statusCode = (HttpStatusCode) statusCode!;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null) throw new ArgumentNullException("info");

        info.AddValue("StatusCode", StatusCode);

        base.GetObjectData(info, context);
    }
}