using System.Net;
using System.Text.Json;
using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Shared.DTOs;

namespace KokkunLMS.API.Middlewares;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly bool _showExceptionDetails;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger,
        IConfiguration configuration)
    {
        _next = next;
        _logger = logger;
        _showExceptionDetails = configuration
            .GetSection("ErrorHandling")
            .GetValue<bool>("ShowExceptionDetails");
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");

            context.Response.ContentType = "application/json";

            var (statusCode, response) = HandleException(ex, _showExceptionDetails);

            context.Response.StatusCode = (int)statusCode;

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }

    private static (HttpStatusCode, ApiErrorResponse) HandleException(Exception ex, bool showDetails)
    {
        return ex switch
        {
            ValidationException validation => (
                HttpStatusCode.BadRequest,
                new ApiErrorResponse
                {
                    Error = "Validation failed.",
                    Details = validation.Errors.Select(e => new ApiErrorDetail
                    {
                        Field = e.PropertyName,
                        Message = e.ErrorMessage
                    }).ToList()
                }),

            UnauthorizedAccessException => (
                HttpStatusCode.Unauthorized,
                new ApiErrorResponse
                {
                    Error = "Unauthorized access.",
                    Details = showDetails
                        ? new List<ApiErrorDetail> { new() { Message = ex.Message } }
                        : null
                }),

            ArgumentException argEx => (
                HttpStatusCode.BadRequest,
                new ApiErrorResponse
                {
                    Error = argEx.Message,
                    Details = showDetails
                        ? new List<ApiErrorDetail> { new() { Message = argEx.Message } }
                        : null
                }),
            NotFoundException nfEx => (
                HttpStatusCode.NotFound,
                new ApiErrorResponse
                {
                    Error = nfEx.Message,
                    Details = showDetails
                        ? new List<ApiErrorDetail> { new() { Message = nfEx.Message } }
                        : null
                }),
            ConflictException cfEx => (
                HttpStatusCode.Conflict,
                new ApiErrorResponse
                {
                    Error = cfEx.Message,
                    Details = showDetails
                        ? new List<ApiErrorDetail> { new() { Message = cfEx.Message } }
                        : null
                }),
            _ => (
                HttpStatusCode.InternalServerError,
                new ApiErrorResponse
                {
                    Error = "Internal server error.",
                    Details = showDetails
                        ? new List<ApiErrorDetail> { new() { Message = ex.Message } }
                        : null
                })
        };
    }
}
