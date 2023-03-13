using Microsoft.Extensions.Logging.Abstractions;
using NetTask.Application.Interfaces.Repositories;
using NetTask.Infrastructure.Persistence.Repositories;
using NetTask.Tests.Unit.Repositories.Common;
using Newtonsoft.Json.Linq;

namespace NetTask.Tests.Unit.Repositories;
public class ApplicationFormRepositoryTests: IClassFixture<BaseRepositoryFixture>
{
    private readonly IApplicationFormRepository repo;

    public ApplicationFormRepositoryTests(BaseRepositoryFixture baseFixture)
    {
        repo = new ApplicationFormRepository(baseFixture.DbContext, new NullLogger<ApplicationFormRepository>());
    }

    [Fact]
    public async Task GetForProgramAsync_Should_ReturnApplicationForm()
    {
        Guid programId = Guid.NewGuid();

        await CreateApplicationForm(programId);

        var applicationFormEntry = await repo.GetForProgramAsync(programId);

        Assert.True(applicationFormEntry != null);
    }

    [Fact]
    public async Task GetForProgramAsync_Should_ReturnNull_When_ApplicationFormForProgramDoesNotExist()
    {
        var applicationFormEntry = await repo.GetForProgramAsync(Guid.NewGuid());

        Assert.True(applicationFormEntry == null);
    }

    private async Task<Guid> CreateApplicationForm(Guid programId)
    {
        ApplicationForm form = new()
        {
            CoverPhotoId = null,
            ProgramId = programId,
            PersonalInfo = new List<ApplicationQuestion>
            {
                new() { Message = "First Name", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Last Name", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Gender", Type = ApplicationQuestionTypes.DropDown, IsHidden = true, IsMandatory = false, IsInternal = false, AdditionalInfo = JObject.FromObject(
                    new DropDownQuestionInfo()
                    {
                        Options = new List<string> { "Male", "Female", },
                        IsOtherEnabled = true,
                    }),
                },
            },
            Profile = new List<ApplicationQuestion>
            {
                new() { Message = "Education", Type = ApplicationQuestionTypes.Paragraph, IsHidden = true, IsInternal = false, IsMandatory = false },
            },
            AdditionalQuestions = null,
        };

        var id = await repo.AddAsync(form);
        return id;
    }
}
