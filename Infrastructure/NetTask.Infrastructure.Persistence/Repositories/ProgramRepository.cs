namespace NetTask.Infrastructure.Persistence.Repositories;
internal class ProgramRepository: IProgramRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ProgramRepository> _logger;

    public ProgramRepository(ApplicationDbContext dbContext, ILogger<ProgramRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> AddAsync(Program program)
    {
        _logger.LogInformation("Adding program to database");

        await _dbContext.Programs.AddAsync(program);
        await _dbContext.SaveChangesAsync();

        return program.Id;
    }

    public async Task<List<string>> FindExistingSkillsAsync(string searchQuery)
    {
        _logger.LogDebug("Fetching skills that match {query}", searchQuery);

        var skills = (await _dbContext.Programs
            .Where(p => p.KeySkills != null)
            .ToListAsync())
            .SelectMany(p => p.KeySkills)
            .Distinct(StringComparer.CurrentCultureIgnoreCase)
            .Where(s => s.Contains(searchQuery.Trim(), StringComparison.CurrentCultureIgnoreCase))
            .ToList();

        _logger.LogDebug("Found {Count} skills matching {query}", skills.Count, searchQuery);

        return skills;
    }

    public async Task<List<Program>> GetAsync()
    {
        _logger.LogDebug("Fetching all programs.");

        return await _dbContext.Programs.ToListAsync();
    }

    public async Task<Program?> GetByIdAsync(Guid id)
    {
        _logger.LogDebug("Trying to retrieve program with ID {Id}", id);

        return await _dbContext.Programs.FindAsync(id);
    }

    public async Task UpdateAsync(Program program)
    {
        _logger.LogDebug("Updating program {ID}", program.Id);

        _dbContext.Programs.Update(program);

        await _dbContext.SaveChangesAsync();
    }
}
