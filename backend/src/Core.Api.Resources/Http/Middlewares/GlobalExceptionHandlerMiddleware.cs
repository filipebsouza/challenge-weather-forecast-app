using System.Net;
using System.Reflection;
using System.Text.Json;
using Core.Api.Resources.Http.Exceptions;
using Core.Api.Resources.Http.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Api.Resources.Http.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext) state;
                httpContext.Response.ContentType = "application/json";
                return Task.CompletedTask;
            }, context);

            await _next(context);

            if (context.Response.StatusCode >= 400)
            {
                var statusCode = (HttpStatusCode) context.Response.StatusCode;
                throw new HttpException(statusCode, statusCode.ToString());
            }
        }
        catch (Exception? ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception? exception)
    {
        _logger.LogError(exception, $"{Assembly.GetExecutingAssembly().FullName} threw an exception");

        if (!context.Response.HasStarted)
        {
            HttpErrorResponse response;
            if (exception is HttpException httpException)
            {
                response = new HttpErrorResponse(httpException.StatusCode, httpException.Message);
            }
            else
            {
                response = new HttpErrorResponse(HttpStatusCode.InternalServerError,
                    $"An error occurred while processing the request. Exception: {exception?.Message} {exception?.InnerException}"
                );
            }

            context.Response.StatusCode = response.StatusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        return context.Response.WriteAsync(string.Empty);
    }
}