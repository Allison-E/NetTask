using MediatR;
using NetTask.Application.Dtos.Enum;

namespace NetTask.Application.Features.WorkflowStageTypes.Query;

/// <summary>
/// Query to get the types of workflow stages available.
/// </summary>
public record GetWorkflowStageTypesQuery: IRequest<List<ReadEnumDto>>;

internal class GetWorkflowStageTypesQueryHandler: IRequestHandler<GetWorkflowStageTypesQuery, List<ReadEnumDto>>
{
    private readonly IMapper _mapper;

    public GetWorkflowStageTypesQueryHandler(IMapper mapper) => _mapper = mapper;

    public Task<List<ReadEnumDto>> Handle(GetWorkflowStageTypesQuery request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var enumKeyValues = Util.EnumToDictionary<Domain.Enums.WorkflowStageTypes>();

            var enumDto = _mapper.Map<List<ReadEnumDto>>(enumKeyValues);

            return enumDto;
        });
    }
}