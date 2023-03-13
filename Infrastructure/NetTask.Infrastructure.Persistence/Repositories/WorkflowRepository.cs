namespace NetTask.Infrastructure.Persistence.Repositories;
internal class WorkflowRepository: IWorkflowRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<WorkflowRepository> _logger;

    public WorkflowRepository(ApplicationDbContext dbContext, ILogger<WorkflowRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> AddAsync(Workflow workflow)
    {
        _logger.LogDebug("Adding workflow for program {ProgramId} to database", workflow.ProgramId);

        await _dbContext.Workflows.AddAsync(workflow);
        await _dbContext.SaveChangesAsync();

        return workflow.Id;
    }

    public async Task<Workflow?> GetForProgramAsync(Guid programId)
    {
        _logger.LogDebug("Fetching workflow for program {ProgramId}", programId);

        return await _dbContext.Workflows
            .Where(a => a.ProgramId == programId)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Workflow workflow)
    {
        _logger.LogDebug("Updating workflow {ID}", workflow.Id);

        _dbContext.Workflows.Update(workflow);

        await _dbContext.SaveChangesAsync();
    }
}
