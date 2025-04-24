using System.Net;
using System.Text.Json;
using FluentValidation;
using KokkunLMS.Shared.DTOs;
using Serilog;

namespace KokkunLMS.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
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

            var (statusCode, response) = HandleException(ex, _env.IsDevelopment());

            context.Response.StatusCode = (int)statusCode;

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }

    private static (HttpStatusCode, ApiErrorResponse) HandleException(Exception ex, bool isDevelopment)
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
                    Details = isDevelopment
                        ? new List<ApiErrorDetail> { new() { Message = ex.Message } }
                        : null
                }),

            ArgumentException argEx => (
                HttpStatusCode.BadRequest,
                new ApiErrorResponse
                {
                    Error = argEx.Message,
                    Details = isDevelopment
                        ? new List<ApiErrorDetail> { new() { Message = argEx.Message } }
                        : null
                }),

            _ => (
                HttpStatusCode.InternalServerError,
                new ApiErrorResponse
                {
                    Error = "Internal server error.",
                    Details = isDevelopment
                        ? new List<ApiErrorDetail> { new() { Message = ex.Message } }
                        : null
                })
        };
    }
}
