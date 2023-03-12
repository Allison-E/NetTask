using MediatR;
using NetTask.Application.Dtos.Program;
using NetTask.Application.Interfaces.Repositories;
using Newtonsoft.Json.Linq;

namespace NetTask.Application.Features.Program.Command;

/// <summary>
/// Command to create a program.
/// </summary>
/// <param name="Program">Program.</param>
public record CreateProgramCommand(CreateProgramDto Program): IRequest<ReadProgramDto>;

internal class CreateProgramCommandHandler: IRequestHandler<CreateProgramCommand, ReadProgramDto>
{
    private readonly IApplicationFormRepository _applicationFormRepository;
    private readonly ILogger<CreateProgramCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProgramRepository _programRepository;

    public CreateProgramCommandHandler(
        IApplicationFormRepository applicationFormRepository,
        ILogger<CreateProgramCommandHandler> logger,
        IMapper mapper,
        IProgramRepository programRepository)
    {
        _applicationFormRepository = applicationFormRepository;
        _logger = logger;
        _mapper = mapper;
        _programRepository = programRepository;
    }

    public async Task<ReadProgramDto> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
    {
        var program = await CreateProgramAsync(request.Program);

        await CreateApplicationFormAsync(program.Id);

        var readProgramDto = _mapper.Map<ReadProgramDto>(program);
        return readProgramDto;
    }

    private async Task<Domain.Models.Program> CreateProgramAsync(CreateProgramDto program)
    {
        _logger.LogInformation("Creating program");

        Domain.Models.Program programModel = _mapper.Map<Domain.Models.Program>(program);
        await _programRepository.AddAsync(programModel);

        return programModel;
    }

    public async Task<Guid> CreateApplicationFormAsync(Guid programId)
    {
        var form = GetDefaultApplicationForm(programId);
        await _applicationFormRepository.AddAsync(form);

        return form.Id;
    }

    private Domain.Models.ApplicationForm GetDefaultApplicationForm(Guid programId)
    {
        return new Domain.Models.ApplicationForm()
        {
            CoverPhotoId = null,
            ProgramId = programId,
            PersonalInfo = new List<ApplicationQuestion>
            {
                new() { Message = "First Name", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Last Name", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Email", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Nationality", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "Current Residence", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "ID Number", Type = ApplicationQuestionTypes.Number, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "Date of Birth", Type = ApplicationQuestionTypes.Date, IsHidden = true, IsMandatory = false, IsInternal = false},
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
                new() { Message = "Experience", Type = ApplicationQuestionTypes.Paragraph, IsHidden = false, IsInternal = false, IsMandatory = true },
                new() { Message = "Resume", Type = ApplicationQuestionTypes.FileUpload, IsHidden = true, IsInternal = false, IsMandatory = false },
            },
            AdditionalQuestions = null,
        };
    }
}
