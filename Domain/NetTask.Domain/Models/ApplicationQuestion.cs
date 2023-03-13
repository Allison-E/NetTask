using Newtonsoft.Json.Linq;

namespace NetTask.Domain.Models;

/// <summary>
/// A question in the application form.
/// </summary>
public class ApplicationQuestion
{
    /// <summary>
    /// Question type.
    /// </summary>
    public ApplicationQuestionTypes Type { get; set; }

    /// <summary>
    /// Prompt message for the question.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Indicates if the question is hidden.
    /// </summary>
    public bool IsHidden { get; set; } = false;

    /// <summary>
    /// Indicates if the answer is internal.
    /// </summary>
    public bool IsInternal { get; set; } = false;

    /// <summary>
    /// Indicates if the question is mandatory for the candidate to answer.
    /// </summary>
    public bool IsMandatory { get; set; } = false;

    /// <summary>
    /// Additional information for the question depending on its type.
    /// </summary>
    /// <remarks>
    /// Types and their additional information:<br/>
    /// <list type="bullet">
    /// <item><see cref="ApplicationQuestionTypes.Video"/> <span>&#8594; </span><see cref="VideoQuestionInfo"/></item>
    /// <item><see cref="ApplicationQuestionTypes.YesNo"/> <span>&#8594; </span><see cref="YesNoQuestionInfo"/></item>
    /// <item><see cref="ApplicationQuestionTypes.MultipleChoice"/> <span>&#8594; </span><see cref="MultipleChoiceQuestionInfo"/></item>
    /// <item><see cref="ApplicationQuestionTypes.DropDown"/> <span>&#8594; </span><see cref="DropDownQuestionInfo"/></item>
    /// </list>
    /// </remarks>
    public JObject? AdditionalInfo { get; set; }
}
