using System.Diagnostics;
using Homework.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Api.Middleware.ExceptionHandlers;

public class CommandValidationExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CommandValidationExceptionHandler> _logger;
    
    public CommandValidationExceptionHandler(ILogger<CommandValidationExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not CommandValidationException ex)
        {
            return false;
        }

        ex.Demystify();
        _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
        
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "ValidationError"
        };
        
        problemDetails.Extensions.Add("code", ex.Code);
        problemDetails.Extensions.Add("validationErrors", ex.Errors);
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}