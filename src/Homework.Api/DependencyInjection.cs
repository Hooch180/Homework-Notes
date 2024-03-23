using Notes.Api.Middleware.ExceptionHandlers;
using Notes.Api.Swagger;

namespace Notes.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwagger();
        services.AddExceptionHandlers();
        services.AddProblemDetails();
        services.AddHealthChecks();
        
        return services;
    }
    
    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.OperationFilter<AddOptionalHeaderParameter>();
        });

        return services;
    }
}