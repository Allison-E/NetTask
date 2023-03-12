using Microsoft.Extensions.Logging.Abstractions;
using NetTask.Application.Interfaces.Repositories;
using NetTask.Infrastructure.Persistence.Repositories;
using NetTask.Tests.Unit.Repositories.Common;

namespace NetTask.Tests.Unit.Repositories;
public class ProgramRepositoryTests: IClassFixture<BaseRepositoryFixture>
{
    private readonly IProgramRepository repo;

    public ProgramRepositoryTests(BaseRepositoryFixture baseFixture)
    {
        repo = new ProgramRepository(baseFixture.DbContext, new NullLogger<ProgramRepository>());
    }

    [Fact]
    public async Task AddAsync_Should_PersistProgram()
    {
        var id = await CreateProgram();

        var programEntry = await repo.GetByIdAsync(id);

        Assert.True(id != default);
        Assert.True(programEntry != null);
    }

    [Fact]
    public async Task AddAsync_Should_UpdateCreationDate()
    {
        var id = await CreateProgram();

        var programEntry = await repo.GetByIdAsync(id);

        Assert.True(programEntry != null);
        Assert.True(programEntry.Created != default);
    }

    [Fact]
    public async Task FindExistingSkillsAsync_Should_ReturnSkillsContainingSearchQuery()
    {
        string skill = "Gaming";
        await CreateProgram(new List<string> { skill });

        var skills = await repo.FindExistingSkillsAsync("Ga");

        Assert.True(skills.Count > 0);
        Assert.Contains(skill, skills);
    }

    [Fact]
    public async Task FindExistingSkillsAsync_Should_ReturnSkillsContainingSearchQuery_When_QueryIsInDifferentCase()
    {
        string skill = "Gaming";
        await CreateProgram(new List<string> { skill });

        var skills = await repo.FindExistingSkillsAsync("ga");

        Assert.True(skills.Count > 0);
        Assert.Contains(skill, skills);
    }

    [Fact]
    public async Task FindExistingSkillsAsync_Should_ReturnAllSkills_When_QueryIsEmptyOrNull()
    {
        string skill = "Gaming";

        await CreateProgram(new List<string> { skill });

        var skills = await repo.FindExistingSkillsAsync(string.Empty);

        Assert.True(skills.Count > 0);
    }

    [Fact]
    public async Task GetAsync_Should_ReturnAllPrograms()
    {
        await CreateProgram();

        var programs = await repo.GetAsync();

        Assert.True(programs.Count > 0);
    }

    [Fact]
    public async Task GetByIdAsync_Should_ReturnProgram()
    {
        var id = await CreateProgram();

        var programEntry = await repo.GetByIdAsync(id);

        Assert.True(programEntry != null);
    }

    [Fact]
    public async Task GetByIdAsync_Should_ReturnNull_When_ProgramWithIdIsNotFound()
    {
        var programEntry = await repo.GetByIdAsync(Guid.NewGuid());

        Assert.True(programEntry == null);
    }

    [Fact]
    public async Task UpdateAsync_Should_UpdateProgram()
    {
        var id = await CreateProgram();
        var newTitle = "Learn C# Programming";

        var programEntry = await repo.GetByIdAsync(id);

        programEntry!.Title = newTitle;

        await repo.UpdateAsync(programEntry);

        programEntry = await repo.GetByIdAsync(id);

        Assert.True(programEntry!.Title == newTitle);
    }

    private async Task<Guid> CreateProgram(List<string>? keySkills = null)
    {
        Program program = new()
        {
            Title = "Title",
            Description = "Description",
            Summary = null,
            Benefits = "You get trained in different areas.",
            KeySkills = keySkills,
            Criteria = null,
            AdditionalInfo = new AdditionalProgramInformation
            {
                Duration = null,
                ApplicationCloseDate = DateTime.UtcNow.AddDays(14),
                ApplicationOpenDate = DateTime.UtcNow.AddDays(1),
                StartDate = DateTime.UtcNow.AddDays(21),
                Location = new ProgramLocation
                {
                    Address = "Abuja, Nigeria",
                    IsRemote = true,
                },
                MaxApplications = 200,
                MinQualification = Qualifications.University,
                Type = ProgramTypes.Webinar,
            },
        };

        var id = await repo.AddAsync(program);
        return id;
    }
}
