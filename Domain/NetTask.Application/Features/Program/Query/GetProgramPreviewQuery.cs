using MediatR;
using NetTask.Application.Dtos.ApplicationForm;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Dtos.Workflow;
using NetTask.Application.Features.ApplicationForm.Query;
using NetTask.Application.Features.Workflow.Query;

namespace NetTask.Application.Features.Program.Query;

/// <summary>
/// Query to get the summary of a program.
/// </summary>
/// <param name="Id">Program ID.</param>
public record GetProgramPreviewQuery(string Id): IRequest<PreviewProgramDto>;

internal class GetProgramPreviewQueryHandler: IRequestHandler<GetProgramPreviewQuery, PreviewProgramDto>
{
    private readonly ILogger<GetProgramPreviewQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetProgramPreviewQueryHandler(ILogger<GetProgramPreviewQueryHandler> logger, IMapper mapper, IMediator mediator)
    {
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<PreviewProgramDto> Handle(GetProgramPreviewQuery request, CancellationToken cancellationToken)
    {
        var readProgramDto = await _mediator.Send(new GetProgramByIdQuery(request.Id), cancellationToken);

        ReadApplicationFormDto? readApplicationFormDto;

        try
        {
            readApplicationFormDto = await _mediator.Send(new GetApplicationFormForProgramQuery(request.Id), cancellationToken);
        }
        catch (NotFoundException)
        {
            _logger.LogWarning("Application form for program {Id} not found. Assigning null instead", request.Id);
            readApplicationFormDto = null;
        }

        ReadWorkflowDto? readWorkflowDto;

        try
        {
            readWorkflowDto = await _mediator.Send(new GetWorkflowForProgramQuery(request.Id), cancellationToken);
        }
        catch (NotFoundException)
        {
            _logger.LogWarning("Application form for program {Id} not found. Assigning null instead", request.Id);
            readWorkflowDto = null;
        }

        var previewProgramDto = _mapper.Map<PreviewProgramDto>(readProgramDto);
        previewProgramDto.ApplicationForm = readApplicationFormDto;
        previewProgramDto.Workflow = readWorkflowDto;

        return previewProgramDto;
    }
}
