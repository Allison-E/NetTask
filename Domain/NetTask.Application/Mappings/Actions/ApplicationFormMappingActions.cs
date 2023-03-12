using NetTask.Application.Dtos.ApplicationForm.Questions;

namespace NetTask.Application.Mappings.Actions;
public class ApplicationQuestion_To_ReadApplicationFormPersonalInformationQuestion_MappingAction: IMappingAction<ApplicationQuestion, ReadApplicationFormPersonalInformationQuestionDto>
{
    public void Process(ApplicationQuestion source, ReadApplicationFormPersonalInformationQuestionDto destination, ResolutionContext context)
    {
        if (source.AdditionalInfo is not null)
        {
            destination.AdditionalInfo = source.AdditionalInfo.ToObject<dynamic>()!;
        }

        destination.TypeId = source.Type;
    }
}

public class ApplicationQuestion_To_ReadApplicationFormAdditionalQuestion_MappingAction: IMappingAction<ApplicationQuestion, ReadApplicationFormAdditionalQuestionDto>
{
    public void Process(ApplicationQuestion source, ReadApplicationFormAdditionalQuestionDto destination, ResolutionContext context)
    {
        if (source.AdditionalInfo is not null)
        {
            destination.AdditionalInfo = source.AdditionalInfo.ToObject<dynamic>()!;
        }

        destination.TypeId = source.Type;
    }
}

public class ApplicationQuestion_To_ReadApplicationFormProfileQuestion_MappingAction: IMappingAction<ApplicationQuestion, ReadApplicationFormProfileQuestionDto>
{
    public void Process(ApplicationQuestion source, ReadApplicationFormProfileQuestionDto destination, ResolutionContext context)
    {
        if (source.AdditionalInfo is not null)
        {
            destination.AdditionalInfo = source.AdditionalInfo.ToObject<dynamic>()!;
        }

        destination.TypeId = source.Type;
    }
}