using SurveyApp.Entities;

namespace SurveyApp.DataTransferObjects.Incoming;

public class CreateNewQuestionRequest
{
    public string? Text { get; set; }
    public QuestionType Type { get; set; }
    public List<CreateNewAnswerRequest>? Answers { get; set; }
}