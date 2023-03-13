using NetTask.Application.Dtos.Workflow;

namespace NetTask.Application.Mappings.Actions;
internal class WorkflowStage_To_ReadWorkflowStageDto_MappingAction: IMappingAction<WorkflowStage, ReadWorkflowStageDto>
{
    public void Process(WorkflowStage source, ReadWorkflowStageDto destination, ResolutionContext context)
    {

        if (source.AdditionalInfo is not null)
        {
            destination.AdditionalInfo = source.AdditionalInfo.ToObject<dynamic>();
        }

        destination.TypeId = source.Type;
    }
}
