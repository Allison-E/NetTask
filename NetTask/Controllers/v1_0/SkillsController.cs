using NetTask.Application.Features.Program.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SkillsController: ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get skills that match the query
    /// </summary>
    /// <param name="query">Search query</param>
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FindAsync([FromQuery] string query = "")
    {
        return Ok(await _mediator.Send(new GetSkillsQuery(query)));
    }
}
