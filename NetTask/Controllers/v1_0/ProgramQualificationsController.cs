using NetTask.Application.Dtos.Enum;
using NetTask.Application.Features.Qualifications.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[Route("api/v{version:apiVersion}/programs/qualifications")]
[ApiVersion("1.0")]
public class QualificationsController: ControllerBase
{
    private readonly IMediator _mediator;

    public QualificationsController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get qualifications availiable
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<ReadEnumDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _mediator.Send(new GetQualificationsQuery()));
    }
}
