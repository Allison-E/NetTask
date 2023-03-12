using MediatR;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.Program.Command;

/// <summary>
/// Command to update program.
/// </summary>
/// <param name="Id">Program ID.</param>
/// <param name="Program">Program.</param>
public record UpdateProgramCommand(string Id, UpdateProgramDto Program): IRequest<ReadProgramDto>;

internal class UpdateProgramCommandHandler: IRequestHandler<UpdateProgramCommand, ReadProgramDto>
{
    private readonly ILogger<UpdateProgramCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProgramRepository _programRepository;

    public UpdateProgramCommandHandler(ILogger<UpdateProgramCommandHandler> logger, IMapper mapper, IProgramRepository programRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _programRepository = programRepository;
    }

    public async Task<ReadProgramDto> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Guid id = Guid.Parse(request.Id);

            var programEntry = await _programRepository.GetByIdAsync(id);

            if (programEntry is null)
                throw new NotFoundException();

            _logger.LogInformation("Updating program");
            _mapper.Map(request.Program, programEntry);

            await _programRepository.UpdateAsync(programEntry);

            var updatedProgramDto = _mapper.Map<ReadProgramDto>(programEntry);

            return updatedProgramDto;
        }
        // Thrown by Guid.Parse().
        catch (FormatException ex)
        {
            _logger.LogWarning(ex, "An error occured. Message: {Message}", ex.Message);
            throw new NotFoundException();
        }
    }
}
