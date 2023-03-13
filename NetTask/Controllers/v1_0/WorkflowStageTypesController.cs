using NetTask.Application.Dtos.Enum;
using NetTask.Application.Features.WorkflowStageTypes.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[Route("api/v{version:apiVersion}/programs/workflow/stage/types")]
[ApiVersion("1.0")]
public class WorkflowStageTypesController: ControllerBase
{
    private readonly IMediator _mediator;

    public WorkflowStageTypesController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get types of workflow stages availiable
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<ReadEnumDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _mediator.Send(new GetWorkflowStageTypesQuery()));
    }
}
