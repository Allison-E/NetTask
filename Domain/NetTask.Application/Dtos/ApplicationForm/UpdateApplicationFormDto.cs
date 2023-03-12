using NetTask.Application.Dtos.ApplicationForm.Questions;

namespace NetTask.Application.Dtos.ApplicationForm;

public class UpdateApplicationFormDto
{
    public string? CoverPhotoId { get; set; }
    public List<UpdateApplicationFormPersonalInformationQuestionDto> PersonalInfo { get; set; }
    public List<UpdateApplicationFormProfileQuestionDto> Profile { get; set; }
    public List<UpdateApplicationFormAdditionalQuestionDto>? AdditionalQuestions { get; set; }
}
