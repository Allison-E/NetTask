using MediatR;
using NetTask.Application.Dtos.Workflow;
using NetTask.Application.Interfaces.Repositories;
using Newtonsoft.Json.Linq;

namespace NetTask.Application.Features.Workflow.Command;

/// <summary>
/// Command for updating the workflow for a given program.
/// </summary>
/// <param name="ProgramId">Program ID.</param>
/// <param name="Workflow">Updated workflow.</param>
public record UpdateWorkflowCommand(string ProgramId, UpdateWorkflowDto Workflow): IRequest<ReadWorkflowDto>;

internal class UpdateWorkflowCommandHandler: IRequestHandler<UpdateWorkflowCommand, ReadWorkflowDto>
{
    private readonly ILogger<UpdateWorkflowCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IWorkflowRepository _workflowRepository;

    public UpdateWorkflowCommandHandler(ILogger<UpdateWorkflowCommandHandler> logger, IMapper mapper, IWorkflowRepository workflowRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _workflowRepository = workflowRepository;
    }

    public async Task<ReadWorkflowDto> Handle(UpdateWorkflowCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var programGuid = Guid.Parse(request.ProgramId);

            var workflow = await _workflowRepository.GetForProgramAsync(programGuid);

            if (workflow is null)
                throw new NotFoundException();

            _mapper.Map(request.Workflow, workflow);

            UpdateStages(ref workflow, request.Workflow);

            await _workflowRepository.UpdateAsync(workflow);

            var workflowDto = _mapper.Map<ReadWorkflowDto>(workflow);

            return workflowDto;
        }
        catch (FormatException ex)
        {
            throw ex;
        }
    }

    private void UpdateStages(ref Domain.Models.Workflow workflow, UpdateWorkflowDto request)
    {
        for (int i = 0; i < workflow.Stages.Count; i++)
        {
            var requestStageInfo = request.Stages[i];

            if (requestStageInfo.AdditionalInfo is null)
                continue;

            workflow.Stages[i].AdditionalInfo = JObject.FromObject(requestStageInfo.AdditionalInfo);
        }
    }
}
