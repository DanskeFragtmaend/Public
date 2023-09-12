using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Df.ServiceControllerExtensions;

public static class ServiceControllerExtensions
{
    /// <summary>Extension method to add configuration to the service collection.</summary>
    /// <returns>Returns the added object.</returns>
    /// <remarks>This method makes it easier to both add the configuration object to the service collection and get it for other uses in startup.</remarks>
    public static T AddConfiguration<T>(this IServiceCollection services, IConfiguration configuration) where T : class
    {
        var settings = configuration.GetSection(typeof(T).Name).Get<T>();
        services.AddSingleton(_ => settings);
        return settings;
    }
}