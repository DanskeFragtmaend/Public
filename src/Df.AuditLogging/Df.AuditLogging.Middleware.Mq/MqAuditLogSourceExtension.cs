using Microsoft.Extensions.DependencyInjection;

namespace Df.AuditLogging.Middleware.Mq;

public static class MqAuditLogSourceExtension
{
    public static IServiceCollection AddMqAuditLogSource(this IServiceCollection services, Action<MqAuditLogSourceOptions>? configure = null)
    {
        if (configure != null)
            services.Configure(configure);
        else
            services.Configure<MqAuditLogSourceOptions>(_ => { });

        services.AddScoped<IAuditLogSource, MqAuditLogSource>();

        return services;
    }
}
