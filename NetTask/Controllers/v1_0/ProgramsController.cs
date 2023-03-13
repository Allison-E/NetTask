using NetTask.Application.Dtos.Parameters;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Features.Program.Command;
using NetTask.Application.Features.Program.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProgramsController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProgramsController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get programs
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<ReadProgramDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _mediator.Send(new GetProgramsQuery()));
    }

    /// <summary>
    /// Create program
    /// </summary>
    /// <param name="program">Program</param>
    [HttpPost]
    [ProducesResponseType(typeof(ReadProgramDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProgramDto program)
    {
        var createdProgram = await _mediator.Send(new CreateProgramCommand(program));

        return CreatedAtRoute("GetProgramById", new { Id = createdProgram.Id.ToString() }, createdProgram);
    }

    /// <summary>
    /// Get program by its ID
    /// </summary>
    /// <param name="id">Program ID</param>
    /// <param name="parameters">Program parameters</param>
    [HttpGet("{id}", Name = "GetProgramById")]
    [ProducesResponseType(typeof(PreviewProgramDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(string id, [FromQuery] ProgramParameters parameters)
    {
        if (parameters.Preview)
            return Ok(await _mediator.Send(new GetProgramPreviewQuery(id)));
        else
            return Ok(await _mediator.Send(new GetProgramByIdQuery(id)));
    }

    /// <summary>
    /// Update program
    /// </summary>
    /// <param name="id">Program ID</param>
    /// <param name="program">Program</param>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ReadProgramDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateProgramDto program)
    {
        return Ok(await _mediator.Send(new UpdateProgramCommand(id, program)));
    }
}
