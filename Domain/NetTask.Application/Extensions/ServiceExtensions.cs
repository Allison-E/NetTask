using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceExtensions
{
    /// <summary>
    /// Configures the services for application layer of the application.
    /// </summary>
    /// <param name="services"></param>
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}
