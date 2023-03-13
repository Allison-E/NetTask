using NetTask.Application.Dtos.Enum;
using NetTask.Application.Features.ProgramTypes.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[Route("api/v{version:apiVersion}/programs/types")]
[ApiVersion("1.0")]
public class ProgramTypesController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProgramTypesController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get program types availiable
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<ReadEnumDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _mediator.Send(new GetProgramTypesQuery()));
    }
}
