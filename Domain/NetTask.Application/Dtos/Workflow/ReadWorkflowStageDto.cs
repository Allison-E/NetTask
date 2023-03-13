namespace NetTask.Application.Dtos.Workflow;

public class ReadWorkflowStageDto
{
    public string Name { get; set; }
    public WorkflowStageTypes TypeId { get; set; }
    public string Type => TypeId.ToString();
    public bool IsVisibleToCandidates { get; set; }
    public object? AdditionalInfo { get; set; }
}
