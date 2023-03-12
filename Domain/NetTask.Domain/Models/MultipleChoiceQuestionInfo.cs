namespace NetTask.Domain.Models;

/// <summary>
/// Additional information for a question containing multiple choice options.
/// </summary>
public class MultipleChoiceQuestionInfo: IMultipleChoice
{
    /// <inheritdoc/>
    public IList<string> Options { get; set; }

    /// <inheritdoc/>
    public bool IsOtherEnabled { get; set; }

    /// <summary>
    /// Maximum amount of choices that can be selected by the user.
    /// </summary>
    public int MaxChoicesAllowed { get; set; }
}
