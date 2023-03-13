using MediatR;
using NetTask.Application.Dtos.Enum;

namespace NetTask.Application.Features.Qualifications.Query;

/// <summary>
/// Query to get program types.
/// </summary>
public record GetQualificationsQuery: IRequest<List<ReadEnumDto>>;

internal class GetQualificationsQueryHandler: IRequestHandler<GetQualificationsQuery, List<ReadEnumDto>>
{
    private readonly IMapper _mapper;

    public GetQualificationsQueryHandler(IMapper mapper) => _mapper = mapper;

    public Task<List<ReadEnumDto>> Handle(GetQualificationsQuery request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var enumKeyValues = Util.EnumToDictionary<Domain.Enums.Qualifications>();

            var enumDto = _mapper.Map<List<ReadEnumDto>>(enumKeyValues);

            return enumDto;
        });
    }
}