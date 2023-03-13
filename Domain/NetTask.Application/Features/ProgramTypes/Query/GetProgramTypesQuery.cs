using MediatR;
using NetTask.Application.Dtos.Enum;

namespace NetTask.Application.Features.ProgramTypes.Query;

/// <summary>
/// Query to get program types.
/// </summary>
public record GetProgramTypesQuery: IRequest<List<ReadEnumDto>>;

internal class GetProgramTypesQueryHandler: IRequestHandler<GetProgramTypesQuery, List<ReadEnumDto>>
{
    private readonly IMapper _mapper;

    public GetProgramTypesQueryHandler(IMapper mapper) => _mapper = mapper;

    public async Task<List<ReadEnumDto>> Handle(GetProgramTypesQuery request, CancellationToken cancellationToken)
    {
        var enumKeyValues = Util.EnumToDictionary<Domain.Enums.ProgramTypes>();

        var enumDto = await Task.Run(() => _mapper.Map<List<ReadEnumDto>>(enumKeyValues));

        return enumDto;
    }
}
