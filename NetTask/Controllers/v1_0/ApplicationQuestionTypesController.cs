using NetTask.Application.Dtos.Enum;
using NetTask.Application.Features.ApplicationQuestionTypes.Query;

namespace NetTask.Controllers.v1_0;

[ApiController]
[Route("api/v{version:apiVersion}/programs/application-form/question/types")]
[ApiVersion("1.0")]
public class ApplicationQuestionTypesController: ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationQuestionTypesController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get types of application questions availiable
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<ReadEnumDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _mediator.Send(new GetApplicationQuestionTypesQuery()));
    }
}
