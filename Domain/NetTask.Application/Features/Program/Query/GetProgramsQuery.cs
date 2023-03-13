using MediatR;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.Program.Query;

/// <summary>
/// Query to get all programs.
/// </summary>
public record GetProgramsQuery(): IRequest<List<ReadProgramDto>>;

internal class GetProgramsQueryHandler: IRequestHandler<GetProgramsQuery, List<ReadProgramDto>>
{
    private readonly ILogger<GetProgramsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProgramRepository _programRepository;

    public GetProgramsQueryHandler(ILogger<GetProgramsQueryHandler> logger, IMapper mapper, IProgramRepository programRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _programRepository = programRepository;
    }

    public async Task<List<ReadProgramDto>> Handle(GetProgramsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all programs");

        var programs = await _programRepository.GetAsync();

        var readProgramsDto = _mapper.Map<List<ReadProgramDto>>(programs);

        return readProgramsDto;
    }
}
