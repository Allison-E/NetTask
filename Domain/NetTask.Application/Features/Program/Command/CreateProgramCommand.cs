using MediatR;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.Program.Command;

/// <summary>
/// Command to create a program.
/// </summary>
/// <param name="Program">Program.</param>
public record CreateProgramCommand(CreateProgramDto Program): IRequest<ReadProgramDto>;

internal class CreateProgramCommandHandler: IRequestHandler<CreateProgramCommand, ReadProgramDto>
{
    private readonly ILogger<CreateProgramCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProgramRepository _programRepository;

    public CreateProgramCommandHandler(ILogger<CreateProgramCommandHandler> logger, IMapper mapper, IProgramRepository programRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _programRepository = programRepository;
    }

    public async Task<ReadProgramDto> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating program");

        Domain.Models.Program programModel = _mapper.Map<Domain.Models.Program>(request.Program);
        await _programRepository.AddAsync(programModel);

        var readProgramDto = _mapper.Map<ReadProgramDto>(programModel);
        return readProgramDto;
    }
}
