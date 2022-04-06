using Microsoft.AspNetCore.Builder;

namespace Df.AuditLogging.Middleware;

public static class AuditLogCorrelatorMiddlewareExtension
{
    public static IApplicationBuilder UseAuditLogCorrelator(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuditLogCorrelatorMiddleware>();
    }
}