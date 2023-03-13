using Microsoft.Extensions.Configuration;
using NetTask.Infrastructure.Persistence.Repositories;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceExtensions
{
    /// <summary>
    /// Configures the services for persistence layer of the application.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration">Application configuration properties.</param>
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseCosmos(configuration.GetConnectionString("DefaultConnection")!, databaseName: configuration["AzureCosmos:DatabaseName"]!);
        });

        services.AddScoped<IProgramRepository, ProgramRepository>();
        services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>();
    }
}
