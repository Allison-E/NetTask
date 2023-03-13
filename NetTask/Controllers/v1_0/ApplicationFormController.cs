using NetTask.Application.Dtos.ApplicationForm;
using NetTask.Application.Features.ApplicationForm.Command;
using NetTask.Application.Features.ApplicationForm.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[Route("api/v{version:apiVersion}/programs/{programId}/application-form")]
[ApiVersion("1.0")]
public class ApplicationFormController: ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationFormController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get application form for program
    /// </summary>
    /// <param name="programId">Program ID</param>
    [HttpGet]
    [ProducesResponseType(typeof(ReadApplicationFormDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetForProgramAsync(string programId)
    {
        return Ok(await _mediator.Send(new GetApplicationFormForProgramQuery(programId)));
    }

    /// <summary>
    /// Update application form for program
    /// </summary>
    /// <param name="programId">Program ID</param>
    /// <param name="applicationForm">Application form</param>
    [HttpPut]
    [ProducesResponseType(typeof(ReadApplicationFormDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(string programId, [FromBody] UpdateApplicationFormDto applicationForm)
    {
        return Ok(await _mediator.Send(new UpdateApplicationFormCommand(programId, applicationForm)));
    }
}
