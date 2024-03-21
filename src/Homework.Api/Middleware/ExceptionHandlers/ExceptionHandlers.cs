using Notes.Api.Middleware.ExceptionHandlers;

namespace Notes.Api;

public static class ExceptionHandlers
{
    public static IServiceProvider AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<CommandValidationExceptionHandler>();
        services.AddExceptionHandler<ApplicationExceptionHandler>();
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        
        return services.BuildServiceProvider();
    }
}