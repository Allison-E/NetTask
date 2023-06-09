﻿using MediatR;
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
    private readonly IWorkflowRepository _workflowRepository;

    public CreateProgramCommandHandler(
        IApplicationFormRepository applicationFormRepository,
        ILogger<CreateProgramCommandHandler> logger,
        IMapper mapper,
        IProgramRepository programRepository,
        IWorkflowRepository workflowRepository)
    {
        _applicationFormRepository = applicationFormRepository;
        _logger = logger;
        _mapper = mapper;
        _programRepository = programRepository;
        _workflowRepository = workflowRepository;
    }

    public async Task<ReadProgramDto> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
    {
        var program = await CreateProgramAsync(request.Program);

        await CreateDefaultApplicationFormForProgramAsync(program.Id);

        await CreateDefaultWorkflowForProgramAsync(program.Id);

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

    public async Task<Guid> CreateDefaultApplicationFormForProgramAsync(Guid programId)
    {
        _logger.LogInformation("Creating default application form for program {ProgramId}", programId);

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
                new() { Message = "First Name", Type = Domain.Enums.ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Last Name", Type = Domain.Enums.ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Email", Type = Domain.Enums.ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                new() { Message = "Nationality", Type = Domain.Enums.ApplicationQuestionTypes.ShortAnswer, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "Current Residence", Type = Domain.Enums.ApplicationQuestionTypes.ShortAnswer, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "ID Number", Type = Domain.Enums.ApplicationQuestionTypes.Number, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "Date of Birth", Type = Domain.Enums.ApplicationQuestionTypes.Date, IsHidden = true, IsMandatory = false, IsInternal = false},
                new() { Message = "Gender", Type = Domain.Enums.ApplicationQuestionTypes.DropDown, IsHidden = true, IsMandatory = false, IsInternal = false, AdditionalInfo = JObject.FromObject(
                    new DropDownQuestionInfo()
                    {
                        Options = new List<string> { "Male", "Female", },
                        IsOtherEnabled = true,
                    }),
                },
            },
            Profile = new List<ApplicationQuestion>
            {
                new() { Message = "Education", Type = Domain.Enums.ApplicationQuestionTypes.Paragraph, IsHidden = true, IsInternal = false, IsMandatory = false },
                new() { Message = "Experience", Type = Domain.Enums.ApplicationQuestionTypes.Paragraph, IsHidden = false, IsInternal = false, IsMandatory = true },
                new() { Message = "Resume", Type = Domain.Enums.ApplicationQuestionTypes.FileUpload, IsHidden = true, IsInternal = false, IsMandatory = false },
            },
            AdditionalQuestions = null,
        };
    }

    private async Task<Guid> CreateDefaultWorkflowForProgramAsync(Guid programId)
    {
        _logger.LogInformation("Creating default workflow for program {ProgramId}", programId);

        var workflow = GetDefaultWorkflow(programId);
        await _workflowRepository.AddAsync(workflow);

        return workflow.Id;
    }

    private Domain.Models.Workflow GetDefaultWorkflow(Guid programId)
    {
        return new Domain.Models.Workflow()
        {
            ProgramId = programId,
            Stages = new List<WorkflowStage>
            {
                new() { Name = "Applied", IsVisibleToCandidates = true, Type = Domain.Enums.WorkflowStageTypes.Shortlisting },
            },
        };
    }
}
