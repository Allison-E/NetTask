using NetTask.Application.Dtos.ApplicationForm;
using NetTask.Application.Dtos.ApplicationForm.Questions;
using NetTask.Application.Mappings.Actions;

namespace NetTask.Application.Mappings;
internal class ApplicationFormProfile: Profile
{
    public ApplicationFormProfile()
    {
        CreateMap<ApplicationForm, ReadApplicationFormDto>();
        CreateMap<UpdateApplicationFormDto, ApplicationForm>();

        // Read application questions DTOs.
        CreateMap<ApplicationQuestion, ReadApplicationFormAdditionalQuestionDto>()
            .BeforeMap<ApplicationQuestion_To_ReadApplicationFormAdditionalQuestion_MappingAction>();

        CreateMap<ApplicationQuestion, ReadApplicationFormPersonalInformationQuestionDto>()
            .BeforeMap<ApplicationQuestion_To_ReadApplicationFormPersonalInformationQuestion_MappingAction>();

        CreateMap<ApplicationQuestion, ReadApplicationFormProfileQuestionDto>()
            .BeforeMap<ApplicationQuestion_To_ReadApplicationFormProfileQuestion_MappingAction>();

        // Update application questions DTOs.
        CreateMap<UpdateApplicationFormAdditionalQuestionDto, ApplicationQuestion>()
            .ForMember(a => a.Type, opt => opt.MapFrom(u => u.TypeId))
            .ForMember(u => u.AdditionalInfo, opt => opt.Ignore());

        CreateMap<UpdateApplicationFormPersonalInformationQuestionDto, ApplicationQuestion>()
            .ForMember(a => a.Type, opt => opt.MapFrom(u => u.TypeId))
            .ForMember(u => u.AdditionalInfo, opt => opt.Ignore());

        CreateMap<UpdateApplicationFormProfileQuestionDto, ApplicationQuestion>()
            .ForMember(a => a.Type, opt => opt.MapFrom(u => u.TypeId))
            .ForMember(u => u.AdditionalInfo, opt => opt.Ignore());
    }
}
