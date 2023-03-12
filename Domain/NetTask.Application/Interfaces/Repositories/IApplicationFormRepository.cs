namespace NetTask.Application.Interfaces.Repositories;

/// <summary>
/// Repository for database operation on <see cref="ApplicationForm"/> entities.
/// </summary>
public interface IApplicationFormRepository
{
    /// <summary>
    /// Add application form.
    /// </summary>
    /// <param name="applicationForm">Application form.</param>
    /// <returns>The ID of the newly added application form.</returns>
    Task<Guid> AddAsync(ApplicationForm applicationForm);

    /// <summary>
    /// Get application form for a given program.
    /// </summary>
    /// <param name="programId">Program ID</param>
    /// <returns>An application form if it exists, otherwise <see langword="null"/>.</returns>
    Task<ApplicationForm?> GetForProgramAsync(Guid programId);

    /// <summary>
    /// Update application form.
    /// </summary>
    /// <param name="applicationForm">Application form.</param>
    Task UpdateAsync(ApplicationForm applicationForm);
}
