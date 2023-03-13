namespace NetTask.Domain.Common;

/// <summary>
/// Contract for questions that contain multiple options.
/// </summary>
public interface IMultipleChoice
{
    /// <summary>
    /// Question options.
    /// </summary>
    public IList<string> Options { get; set; }

    /// <summary>
    /// Indicates if there is an "Other" option.
    /// </summary>
    public bool IsOtherEnabled { get; set; }
}
