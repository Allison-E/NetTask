using System.Reflection;
using FluentValidation;
using MediatR;
using NetTask.Application.Behaviours;

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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
    }
}
