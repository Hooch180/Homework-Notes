using Homework.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using ApplicationException = Homework.Application.Common.Exceptions.ApplicationException;

namespace Notes.Api;

public static class CustomizedProblemDetails
{
    public static IServiceCollection AddCustomizedProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails(configure =>
        {
            configure.CustomizeProblemDetails = (problemDetails) =>
            {
                var ex = problemDetails.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
                var result = problemDetails.ProblemDetails;

                if (ex is ApplicationException applicationException)
                {
                    result.Extensions.Add("code", applicationException.Code);
                }

                switch (ex)
                {
                    case NotFoundException:
                        result.Type = "NotFound";
                        result.Status = StatusCodes.Status404NotFound;
                        break;
                    case CommandValidationException commandValidationException:
                        result.Status = StatusCodes.Status400BadRequest;
                        result.Type = "ValidationError";
                        result.Extensions.Add("validationErrors", commandValidationException.Errors);
                        break;
                    case ApplicationException:
                        result.Status = StatusCodes.Status500InternalServerError;
                        result.Type = "ApplicationError";
                        break;
                    default:
                        result.Status = StatusCodes.Status500InternalServerError;
                        result.Type = "UnknownError";
                        break;
                }
            };
        });
        
        return services;
    }
}