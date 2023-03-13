namespace NetTask.Domain.Models;

/// <summary>
/// Workflow for a program.
/// </summary>
public class Workflow: Entity
{
    /// <summary>
    /// Foreign key of the parent parent.
    /// </summary>
    public Guid ProgramId { get; set; }

    /// <summary>
    /// Workflow stages.
    /// </summary>
    public IList<WorkflowStage> Stages { get; set; }
}
