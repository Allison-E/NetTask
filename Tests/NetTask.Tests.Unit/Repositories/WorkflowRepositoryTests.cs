using Microsoft.Extensions.Logging.Abstractions;
using NetTask.Application.Interfaces.Repositories;
using NetTask.Infrastructure.Persistence.Repositories;
using NetTask.Tests.Unit.Repositories.Common;

namespace NetTask.Tests.Unit.Repositories;
public class WorkflowRepositoryTests: IClassFixture<BaseRepositoryFixture>
{
    private readonly IWorkflowRepository repo;

    public WorkflowRepositoryTests(BaseRepositoryFixture baseFixture)
    {
        repo = new WorkflowRepository(baseFixture.DbContext, new NullLogger<WorkflowRepository>());
    }


    [Fact]
    public async Task GetForProgramAsync_Should_ReturnWorkflow()
    {
        Guid programId = Guid.NewGuid();

        await CreateWorkflowAsync(programId);

        var workflowEntry = await repo.GetForProgramAsync(programId);

        Assert.True(workflowEntry != null);
    }

    [Fact]
    public async Task GetForProgramAsync_Should_ReturnNull_When_ApplicationFormForProgramDoesNotExist()
    {
        var workflowEntry = await repo.GetForProgramAsync(Guid.NewGuid());

        Assert.True(workflowEntry == null);
    }

    private async Task<Guid> CreateWorkflowAsync(Guid programId)
    {
        Workflow workflow = new()
        {
            ProgramId = programId,
            Stages = new List<WorkflowStage>
            {
                new() { Name = "Applied", IsVisibleToCandidates = true, Type = WorkflowStageTypes.Shortlisting },
            }
        };

        var id = await repo.AddAsync(workflow);
        return id;
    }
}
