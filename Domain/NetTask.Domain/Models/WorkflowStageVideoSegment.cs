namespace NetTask.Domain.Models;

/// <summary>
/// 
/// </summary>
public class WorkflowStageVideoSegment: IHasMaxDuration
{
    /// <summary>
    /// Question for this video segment.
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// Additional descripton of what is required foor this video segment.
    /// </summary>
    public string? Description { get; set; }

    /// <inheritdoc/>
    public int MaxDuration { get; set; }

    /// <inheritdoc/>
    public VideoTimeUnits Unit { get; set; }

    /// <summary>
    /// Deadline for video submission.
    /// </summary>
    public int DeadlineInDays { get; set; }
}
