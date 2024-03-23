using Serilog.Context;

namespace Notes.Api.Middleware;

public class RequestContextLoggingMiddleware(RequestDelegate next)
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";
    private const string CorrelationIdLogPropertyName = "CorrelationId";
    
    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId = GetCorrelationId(context);
        using (LogContext.PushProperty(CorrelationIdLogPropertyName, correlationId))
        {
            await next(context);
        }
    }
    
    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, 
            out var correlationId);
        
        return correlationId.FirstOrDefault() ?? context.TraceIdentifier;
    }
}