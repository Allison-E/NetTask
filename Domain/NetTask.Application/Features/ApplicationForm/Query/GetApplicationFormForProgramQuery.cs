using MediatR;
using NetTask.Application.Dtos.ApplicationForm;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.ApplicationForm.Query;

/// <summary>
/// Query for fetching application form for program with ID <paramref name="ProgramId"/>.
/// </summary>
/// <param name="ProgramId">Program ID.</param>
public record GetApplicationFormForProgramQuery(string ProgramId): IRequest<ReadApplicationFormDto>;

internal class GetApplicationFormForProgramQueryHandler: IRequestHandler<GetApplicationFormForProgramQuery, ReadApplicationFormDto>
{
    public readonly IApplicationFormRepository _applicationFormRepository;
    public readonly ILogger<GetApplicationFormForProgramQueryHandler> _logger;
    public readonly IMapper _mapper;

    public GetApplicationFormForProgramQueryHandler(
        IApplicationFormRepository applicationFormRepository,
        ILogger<GetApplicationFormForProgramQueryHandler> logger,
        IMapper mapper)
    {
        _applicationFormRepository = applicationFormRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<ReadApplicationFormDto> Handle(GetApplicationFormForProgramQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var programGuid = Guid.Parse(request.ProgramId);

            var form = await _applicationFormRepository.GetForProgramAsync(programGuid);

            if (form is null)
                throw new NotFoundException();

            var formDto = _mapper.Map<ReadApplicationFormDto>(form);

            return formDto;
        }
        catch (FormatException ex)
        {
            _logger.LogWarning(ex, "An error occurred. Message: {Message}", ex.Message);
            throw new NotFoundException();
        }
    }
}
