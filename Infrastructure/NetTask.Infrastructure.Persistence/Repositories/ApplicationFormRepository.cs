namespace NetTask.Infrastructure.Persistence.Repositories;
internal class ApplicationFormRepository: IApplicationFormRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ApplicationFormRepository> _logger;

    public ApplicationFormRepository(ApplicationDbContext dbContext, ILogger<ApplicationFormRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> AddAsync(ApplicationForm applicationForm)
    {
        _logger.LogDebug("Adding application form for program {ProgramId} to database", applicationForm.ProgramId);

        await _dbContext.ApplicationForms.AddAsync(applicationForm);
        await _dbContext.SaveChangesAsync();

        return applicationForm.Id;
    }

    public async Task<ApplicationForm?> GetForProgramAsync(Guid programId)
    {
        _logger.LogDebug("Fetching application form for program {ProgramId}", programId);

        return await _dbContext.ApplicationForms
            .Where(a => a.ProgramId == programId)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(ApplicationForm applicationForm)
    {
        _logger.LogDebug("Updating application form {ID}", applicationForm.Id);

        _dbContext.ApplicationForms.Update(applicationForm);

        await _dbContext.SaveChangesAsync();
    }
}
