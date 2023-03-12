using NetTask.Infrastructure.Persistence.Contexts;
using NetTask.Middlewares;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Registers the <see cref="ErrorHandlingMiddleware"/> in the pipeline.
    /// </summary>
    /// <param name="app">ASP.NET Core app.</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlingMiddleware>();
    }

    /// <summary>
    /// Creates the database.
    /// </summary>
    /// <param name="app">ASP.NET Core app.</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static async Task<IApplicationBuilder> CreateDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            logger.LogInformation("Creating database.");
            var appDataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await appDataContext.Database.EnsureCreatedAsync();
            logger.LogInformation("Database created.");
        }
        catch (Exception e)
        {
            logger.LogError("Database could not be created. Error message: {ErrorMessage}", e.Message);
        }
        return app;
    }
}
