using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApplicationException = Homework.Application.Common.Exceptions.ApplicationException;

namespace Notes.Api.Middleware.ExceptionHandlers;

public class ApplicationExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ApplicationExceptionHandler> _logger;
    
    public ApplicationExceptionHandler(ILogger<ApplicationExceptionHandler> logger)
    {
        _logger = logger;
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ApplicationException ex)
        {
            return false;
        }

        ex.Demystify();
        _logger.LogError(ex, "ApplicationException occurred: {Message}", ex.Message);
        
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "ApplicationError"
        };
        
        problemDetails.Extensions.Add("code", ex.Code);
        
        httpContext.Response.StatusCode = problemDetails.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}