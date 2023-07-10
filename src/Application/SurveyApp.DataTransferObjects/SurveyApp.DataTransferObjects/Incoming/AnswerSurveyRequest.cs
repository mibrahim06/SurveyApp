namespace SurveyApp.DataTransferObjects.Incoming;

public class AnswerSurveyRequest
{
    public int SurveyId { get; set; }
    public List<QuestionAnswerRequest> Questions { get; set; }
}