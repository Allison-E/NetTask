using MediatR;
using NetTask.Application.Dtos.Workflow;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.Workflow.Query;

/// <summary>
/// Query for fetching a workflow for a given program.
/// </summary>
/// <param name="ProgramId">Program ID.</param>
public record GetWorkflowForProgramQuery(string ProgramId): IRequest<ReadWorkflowDto>;

internal class GetWorkflowForProgramQueryHandler: IRequestHandler<GetWorkflowForProgramQuery, ReadWorkflowDto>
{
    private readonly ILogger<GetWorkflowForProgramQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IWorkflowRepository _workflowRepository;

    public GetWorkflowForProgramQueryHandler(ILogger<GetWorkflowForProgramQueryHandler> logger, IMapper mapper, IWorkflowRepository workflowRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _workflowRepository = workflowRepository;
    }

    public async Task<ReadWorkflowDto> Handle(GetWorkflowForProgramQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var programGuid = Guid.Parse(request.ProgramId);

            var workflow = await _workflowRepository.GetForProgramAsync(programGuid);

            if (workflow is null)
                throw new NotFoundException();

            var workflowDto = _mapper.Map<ReadWorkflowDto>(workflow);

            return workflowDto;
        }
        catch (FormatException ex)
        {
            _logger.LogWarning(ex, "An error occurred. Message: {Message}", ex.Message);
            throw new NotFoundException();
        }
    }
}