using MediatR;
using NetTask.Application.Dtos.Enum;

namespace NetTask.Application.Features.ApplicationQuestionTypes.Query;

/// <summary>
/// Query to get the types of application questions available.
/// </summary>
public record GetApplicationQuestionTypesQuery: IRequest<List<ReadEnumDto>>;

internal class GetApplicationQuestionTypesQueryHandler: IRequestHandler<GetApplicationQuestionTypesQuery, List<ReadEnumDto>>
{
    private readonly IMapper _mapper;

    public GetApplicationQuestionTypesQueryHandler(IMapper mapper) => _mapper = mapper;

    public Task<List<ReadEnumDto>> Handle(GetApplicationQuestionTypesQuery request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var enumKeyValues = Util.EnumToDictionary<Domain.Enums.ApplicationQuestionTypes>();

            var enumDto = _mapper.Map<List<ReadEnumDto>>(enumKeyValues);

            return enumDto;
        });
    }
}