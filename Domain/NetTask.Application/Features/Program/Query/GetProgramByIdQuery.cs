using MediatR;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.Program.Query;

/// <summary>
/// Query to get a program by its ID.
/// </summary>
/// <param name="Id">Program ID.</param>
public record GetProgramByIdQuery(string Id): IRequest<ReadProgramDto>;

internal class GetProgramByIdQueryHandler: IRequestHandler<GetProgramByIdQuery, ReadProgramDto>
{
    private readonly ILogger<GetProgramsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProgramRepository _programRepository;

    public GetProgramByIdQueryHandler(ILogger<GetProgramsQueryHandler> logger, IMapper mapper, IProgramRepository programRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _programRepository = programRepository;
    }

    public async Task<ReadProgramDto> Handle(GetProgramByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Guid id = Guid.Parse(request.Id);

            var program = await _programRepository.GetByIdAsync(id);

            if (program is null)
                throw new NotFoundException();

            var readProgramDto = _mapper.Map<ReadProgramDto>(program);

            return readProgramDto;
        }
        // Thrown by Guid.Parse().
        catch (FormatException ex)
        {
            _logger.LogWarning(ex, "An error occured. Message: {Message}", ex.Message);
            throw new NotFoundException();
        }
    }
}
