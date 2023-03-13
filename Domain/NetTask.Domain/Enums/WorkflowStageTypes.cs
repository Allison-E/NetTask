namespace NetTask.Domain.Enums;

/// <summary>
/// Types of stages in a program workflow.
/// </summary>
public enum WorkflowStageTypes
{
    /// <summary>
    /// Shortlisting stage for filtering candidates.
    /// </summary>
    Shortlisting = 1,

    /// <summary>
    /// A video interview stage.
    /// </summary>
    VideoInterview,

    /// <summary>
    /// Stage which opens up job opportunities within
    /// the program for the candidates.
    /// </summary>
    Placement,
}
