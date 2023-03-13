using NetTask.Application.Dtos.Workflow;
using NetTask.Application.Features.Workflow.Command;
using NetTask.Application.Features.Workflow.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[Route("api/v{version:apiVersion}/programs/{programId}/workflow")]
[ApiVersion("1.0")]
public class WorkflowController: ControllerBase
{
    private readonly IMediator _mediator;

    public WorkflowController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get workflow for program
    /// </summary>
    /// <param name="programId">Program ID</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ReadWorkflowDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetForProgramAsync(string programId)
    {
        return Ok(await _mediator.Send(new GetWorkflowForProgramQuery(programId)));
    }

    /// <summary>
    /// Update workflow for program
    /// </summary>
    /// <param name="programId">Program ID</param>
    /// <param name="workflow">Workflow</param>
    [HttpPut]
    [ProducesResponseType(typeof(ReadWorkflowDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(string programId, [FromBody] UpdateWorkflowDto workflow)
    {
        return Ok(await _mediator.Send(new UpdateWorkflowCommand(programId, workflow)));
    }
}
