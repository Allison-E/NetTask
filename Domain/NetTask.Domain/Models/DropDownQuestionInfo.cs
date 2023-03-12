namespace NetTask.Domain.Models;

/// <summary>
/// Additional information for a question containing a drop-down.
/// </summary>
public class DropDownQuestionInfo: IMultipleChoice
{
    /// <inheritdoc/>
    public IList<string> Options { get; set; }

    /// <inheritdoc/>
    public bool IsOtherEnabled { get; set; }
}
