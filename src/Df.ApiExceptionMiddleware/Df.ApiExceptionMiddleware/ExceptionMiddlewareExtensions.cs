using Microsoft.AspNetCore.Builder;

namespace Df.ApiExceptionMiddleware;

public static class ExceptionMiddlewareExtensions
{
    /// <summary>Extension method to setup the middleware.</summary>
    public static IApplicationBuilder UseApiExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}