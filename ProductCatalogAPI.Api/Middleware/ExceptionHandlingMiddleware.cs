using FluentValidation;
using Newtonsoft.Json;
using ProductCatalogAPI.Api.Models;
using ProductCatalogAPI.Application.Exceptions;
using System.Net;

namespace ProductCatalogAPI.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        this._logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomValidationProblemDetails problem = new();

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = validationException.Message,
                    Status = (int)statusCode,
                    Detail = validationException.InnerException?.Message,
                    Type = nameof(ValidationException),
                    Errors = new Dictionary<string, string[]>
                    {
                        { "Errors", validationException.Errors.Select(e => e.ErrorMessage).ToArray() }
                    }
                };
                break;
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = badRequestException.Message,
                    Status = (int)statusCode,
                    Detail = badRequestException.InnerException?.Message,
                    Type = nameof(BadRequestException),
                    Errors = badRequestException.ValidationErrors
                };
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomValidationProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = nameof(NotFoundException),
                };
                break;
            default:
                problem = new CustomValidationProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.StackTrace,
                    Type = nameof(HttpStatusCode.InternalServerError),
                };
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        var logMessage = JsonConvert.SerializeObject(problem);
        _logger.LogError(exception, logMessage);
        await context.Response.WriteAsJsonAsync(problem);
    }
}
