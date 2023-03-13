namespace NetTask.Application.Interfaces.Repositories;

/// <summary>
/// Repository for database operation on <see cref="Program"/> entities.
/// </summary>
public interface IProgramRepository
{
    /// <summary>
    /// Add program.
    /// </summary>
    /// <param name="program">Program.</param>
    /// <returns>The ID of the newly added program.</returns>
    Task<Guid> AddAsync(Program program);

    /// <summary>
    /// Get a program by its ID.
    /// </summary>
    /// <param name="id">Program ID.</param>
    /// <returns>A program if it exists, otherwise <see langword="null"/>.</returns>
    Task<Program?> GetByIdAsync(Guid id);

    /// <summary>
    /// Get all programs.
    /// </summary>
    /// <returns>A list of programs.</returns>
    Task<List<Program>> GetAsync();

    /// <summary>
    /// Update program.
    /// </summary>
    /// <param name="program">Program.</param>
    Task UpdateAsync(Program program);

    /// <summary>
    /// Searches for skills existing in the database that contain the given <paramref name="searchQuery"/>.
    /// </summary>
    /// <remarks>If <paramref name="searchQuery"/> is empty, it returns all skills.</remarks>
    /// <param name="searchQuery">Search query.</param>
    /// <returns>A list of skills.</returns>
    Task<List<string>> FindExistingSkillsAsync(string searchQuery);
}
