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
}
