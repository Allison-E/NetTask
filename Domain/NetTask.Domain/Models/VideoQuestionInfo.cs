namespace NetTask.Domain.Models;

/// <summary>
/// Additional information for a question that requires a video.
/// </summary>
public class VideoQuestionInfo
{
    /// <summary>
    /// Video segments.
    /// </summary>
    public List<VideoQuestionSegment> Segments { get; set; }
}
