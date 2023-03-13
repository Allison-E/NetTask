namespace NetTask.Domain.Common;

/// <summary>
/// Contract for a video that indicates the maximum duration.
/// </summary>
public interface IHasMaxDuration
{
    /// <summary>
    /// Maximum duration.
    /// </summary>
    public int MaxDuration { get; set; }

    /// <summary>
    /// Time unit.
    /// </summary>
    public VideoTimeUnits Unit { get; set; }
}
