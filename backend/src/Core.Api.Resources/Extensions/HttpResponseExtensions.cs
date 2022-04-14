using System.Net;
using Core.Api.Resources.Http.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Api.Resources.Extensions;

public static class HttpResponseExtensions
{
    public static async Task WriteValidationErrorsAsync(this HttpResponse res, List<ValidationFailure> validationFailures)
    {
        var errorMessage = string.Empty;
        validationFailures.ForEach(failure => errorMessage += $"Error: {failure.ErrorMessage}. ");
        var json = new HttpErrorResponse
        {
            StatusCode = (int) HttpStatusCode.BadRequest,
            Message = errorMessage
        };
        res.StatusCode = (int)HttpStatusCode.BadRequest;
        await res.WriteAsJsonAsync(json);
    }
}