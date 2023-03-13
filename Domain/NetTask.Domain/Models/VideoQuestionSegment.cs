namespace NetTask.Domain.Models;

/// <summary>
/// A segment in a video question.
/// </summary>
public class VideoQuestionSegment: IHasMaxDuration
{
    /// <summary>
    /// Question for this video segment.
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// Additional description of what is required for this video segment.
    /// </summary>
    public string? Description { get; set; }

    /// <inheritdoc/>
    public int MaxDuration { get; set; }

    /// <inheritdoc/>
    public VideoTimeUnits Unit { get; set; }
}
