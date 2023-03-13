using Microsoft.EntityFrameworkCore;
using NetTask.Infrastructure.Persistence.Contexts;

namespace NetTask.Tests.Unit.Repositories.Common;
public class BaseRepositoryFixture: IDisposable
{
    public ApplicationDbContext DbContext { get; private set; }

    public BaseRepositoryFixture()
    {
        var dbName = $"TestDb";
        var connectionString = @"AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseCosmos(connectionString, dbName)
            .Options;

        DbContext = new ApplicationDbContext(dbContextOptions);

        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}
