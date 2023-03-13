namespace NetTask.Application.Interfaces.Repositories;

/// <summary>
/// Repository for database operation on <see cref="Workflow"/> entities.
/// </summary>
public interface IWorkflowRepository
{
    /// <summary>
    /// Add workflow.
    /// </summary>
    /// <param name="workflow">Workflow.</param>
    /// <returns>The ID of the newly created workflow.</returns>
    Task<Guid> AddAsync(Workflow workflow);

    /// <summary>
    /// Get workflow for a given program.
    /// </summary>
    /// <param name="programId">Program ID.</param>
    /// <returns>A workflow if it exists, otherwise <see langword="null"/>.</returns>
    Task<Workflow?> GetForProgramAsync(Guid programId);

    /// <summary>
    /// Update workflow.
    /// </summary>
    /// <param name="workflow">Workflow.</param>
    Task UpdateAsync(Workflow workflow);
}
