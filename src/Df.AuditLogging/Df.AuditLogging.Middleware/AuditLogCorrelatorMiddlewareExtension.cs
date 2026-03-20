using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Df.AuditLogging.Middleware;

public static class AuditLogCorrelatorMiddlewareExtension
{
    public static IApplicationBuilder UseAuditLogCorrelator(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuditLogCorrelatorMiddleware>();
    }

    public static IServiceCollection AddAuditLogCorrelator(this IServiceCollection services, Action<AuditLogCorrelatorOptions>? configure = null)
    {
        if (configure != null)
            services.Configure(configure);
        else
            services.Configure<AuditLogCorrelatorOptions>(_ => { });

        return services;
    }
}