using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TIN.Core.Exceptions;

namespace TIN_PRO.Middlewares;

public class StoreExceptionHandler(ILogger<StoreExceptionHandler> logger) : IExceptionHandler
{
    private const string ErrorMessageContentType = "application/json";
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        switch (exception)
        {
            // Code 400
            case BadRequestException:
                await HandleAsync(httpContext, 
                    StatusCodes.Status400BadRequest, 
                    "Bad Request",
                    null,
                    exception,
                    LogLevel.Information);
                return true;
            
            // Code 401
            case UnauthorizedException:
                await HandleAsync(httpContext,
                    StatusCodes.Status401Unauthorized,
                    "Unauthorized",
                    null,
                    exception,
                    LogLevel.Information);
                return true;
            
            // Code 404
            case NotFoundException:
                await HandleAsync(httpContext, 
                    StatusCodes.Status404NotFound, 
                    "Not Found",
                    null,
                    exception,
                    LogLevel.Information);
                return true;
            
            // Code 500
            default:
                await HandleAsync(httpContext, 
                    StatusCodes.Status500InternalServerError, 
                    "Internal Server Error",
                    null,
                    exception,
                    LogLevel.Error);
                return true;
        }
    }
    
    private async Task HandleAsync(
        HttpContext httpContext,
        int statusCode,
        string title,
        string? msg,
        Exception e,
        LogLevel logLevel)
    {
        logger.Log(logLevel, e, msg ?? title);
        httpContext.Response.ContentType = ErrorMessageContentType;
        httpContext.Response.StatusCode = statusCode;

        var details = new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Detail = msg,
        };

        await httpContext.Response.WriteAsJsonAsync(details);
    }
}