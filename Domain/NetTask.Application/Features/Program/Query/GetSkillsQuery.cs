using MediatR;
using NetTask.Application.Interfaces.Repositories;

namespace NetTask.Application.Features.Program.Query;

/// <summary>
/// Query to get the skills which match <paramref name="SearchQuery"/>.
/// </summary>
/// <param name="SearchQuery">Search query.</param>
public record GetSkillsQuery(string SearchQuery): IRequest<List<string>>;

internal class GetSkillsQueryHandler: IRequestHandler<GetSkillsQuery, List<string>>
{
    private readonly IProgramRepository _programRepository;

    public GetSkillsQueryHandler(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<List<string>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _programRepository.FindExistingSkillsAsync(request.SearchQuery);

        return skills;
    }
}
