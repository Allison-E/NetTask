using NetTask.Application.Dtos.ApplicationForm.Questions.Common;

namespace NetTask.Application.Dtos.ApplicationForm.Questions;

public class UpdateApplicationFormPersonalInformationQuestionDto: IUpdateQuestionBaseDto, IHideable
{
    public ApplicationQuestionTypes TypeId { get; set; }
    public string Message { get; set; }
    public bool IsHidden { get; set; }
    public bool IsInternal { get; set; }
    public dynamic? AdditionalInfo { get; set; } = null;
}
