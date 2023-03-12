namespace NetTask.Domain.Models;

/// <summary>
/// Additional information for a question containing yes/no options.
/// </summary>
public class YesNoQuestionInfo
{
    /// <summary>
    /// Indicates if the candidate is automatically disqualified
    /// if their response is no.
    /// </summary>
    public bool IsDisqualifiedOnNo { get; set; }
}
