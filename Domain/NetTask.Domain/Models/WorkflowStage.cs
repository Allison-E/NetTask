using Newtonsoft.Json.Linq;

namespace NetTask.Domain.Models;

/// <summary>
/// A stage in a program's workflow.
/// </summary>
public class WorkflowStage
{
    /// <summary>
    /// Stage name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Stage type.
    /// </summary>
    public WorkflowStageTypes Type { get; set; }

    /// <summary>
    /// Indicates if this stage is visibe to candidates.
    /// </summary>
    public bool IsVisibleToCandidates { get; set; } = false;

    /// <summary>
    /// Additional information for the workflow stage depending on its type.
    /// </summary>
    /// <remarks>
    /// Types and their additional information:<br/>
    /// <list type="bullet">
    /// <item><see cref="WorkflowStageTypes.VideoInterview"/> <span>&#8594; </span><see cref="WorkflowStageVideoQuestionInfo"/></item>
    /// </list>
    /// </remarks>
    public JObject? AdditionalInfo { get; set; }
}
