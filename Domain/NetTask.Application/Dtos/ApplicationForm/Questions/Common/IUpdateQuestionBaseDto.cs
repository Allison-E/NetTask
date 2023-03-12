namespace NetTask.Application.Dtos.ApplicationForm.Questions.Common;

public interface IUpdateQuestionBaseDto
{
    public ApplicationQuestionTypes TypeId { get; set; }
    public string Message { get; set; }
    public dynamic? AdditionalInfo { get; set; }
}
