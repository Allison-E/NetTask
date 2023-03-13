using NetTask.Application.Dtos.Workflow;
using NetTask.Application.Mappings.Actions;

namespace NetTask.Application.Mappings;
internal class WorkflowProfile: Profile
{
    public WorkflowProfile()
    {
        CreateMap<Workflow, ReadWorkflowDto>();
        CreateMap<UpdateWorkflowDto, Workflow>();

        CreateMap<WorkflowStage, ReadWorkflowStageDto>()
            .BeforeMap<WorkflowStage_To_ReadWorkflowStageDto_MappingAction>();
        CreateMap<UpdateWorkflowStageDto, WorkflowStage>()
            .ForMember(w => w.Type, opt => opt.MapFrom(u => u.TypeId))
            .ForMember(u => u.AdditionalInfo, opt => opt.Ignore());
    }
}
