using Microsoft.AspNetCore.Builder;

namespace Df.ApiExceptionMiddleware;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseApiExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}