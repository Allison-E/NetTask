namespace NetTask.Domain.Models;

/// <summary>
/// Additional information for a question that requires a video.
/// </summary>
public class WorkflowStageVideoQuestionInfo
{
    /// <summary>
    /// Video segments.
    /// </summary>
    public IList<WorkflowStageVideoSegment> Segments { get; set; }
}
