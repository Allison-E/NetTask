using MediatR;
using NetTask.Application.Dtos.ApplicationForm;
using NetTask.Application.Interfaces.Repositories;
using Newtonsoft.Json.Linq;

namespace NetTask.Application.Features.ApplicationForm.Command;

/// <summary>
/// Command for updating the application form for program with
/// ID <paramref name="ProgramId"/>.
/// </summary>
/// <param name="ProgramId">Program ID.</param>
/// <param name="ApplicationForm">Updated application form.</param>
public record UpdateApplicationFormCommand(string ProgramId, UpdateApplicationFormDto ApplicationForm): IRequest<ReadApplicationFormDto>;

internal class UpdateApplicationFormCommandHandler: IRequestHandler<UpdateApplicationFormCommand, ReadApplicationFormDto>
{
    public readonly IApplicationFormRepository _applicationFormRepository;
    public readonly ILogger<UpdateApplicationFormCommandHandler> _logger;
    public readonly IMapper _mapper;

    public UpdateApplicationFormCommandHandler(IApplicationFormRepository applicationFormRepository, ILogger<UpdateApplicationFormCommandHandler> logger, IMapper mapper)
    {
        _applicationFormRepository = applicationFormRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<ReadApplicationFormDto> Handle(UpdateApplicationFormCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var programGuid = Guid.Parse(request.ProgramId);

            var form = await _applicationFormRepository.GetForProgramAsync(programGuid);

            if (form is null)
                throw new NotFoundException();

            _mapper.Map(request.ApplicationForm, form);

            UpdateQuestions(ref form, request.ApplicationForm);

            await _applicationFormRepository.UpdateAsync(form);

            var formDto = _mapper.Map<ReadApplicationFormDto>(form);

            return formDto;
        }
        catch (FormatException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "An error occurred. Message: {Message}", ex.Message);
            throw new NotFoundException();
        }
    }

    private void UpdateQuestions(ref Domain.Models.ApplicationForm form, UpdateApplicationFormDto request)
    {
        // Update personal information questions.
        for (int i = 0; i < form.PersonalInfo.Count; i++)
        {
            var requestPersonalInfo = request.PersonalInfo[i];

            if (requestPersonalInfo.AdditionalInfo is null)
                continue;

            form.PersonalInfo[i].AdditionalInfo = JObject.FromObject(requestPersonalInfo.AdditionalInfo);
        }

        // Update profile questions.
        for (int i = 0; i < form.Profile.Count; i++)
        {
            var requestProfile = request.Profile[i];

            if (requestProfile.AdditionalInfo is null)
                continue;

            form.Profile[i].AdditionalInfo = JObject.FromObject(requestProfile.AdditionalInfo);
        }

        // Update additional questions.
        for (int i = 0; i < form.AdditionalQuestions.Count; i++)
        {
            var requestAdditionalQuestions = request.AdditionalQuestions[i];

            if (requestAdditionalQuestions.AdditionalInfo is null)
                continue;

            form.AdditionalQuestions[i].AdditionalInfo = JObject.FromObject(requestAdditionalQuestions.AdditionalInfo);
        }
    }
}
