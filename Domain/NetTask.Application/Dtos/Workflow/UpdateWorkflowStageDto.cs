namespace NetTask.Application.Dtos.Workflow;

public class UpdateWorkflowStageDto
{
    public string Name { get; set; }
    public WorkflowStageTypes TypeId { get; set; }
    public bool IsVisibleToCandidates { get; set; }
    public dynamic? AdditionalInfo { get; set; }
}
