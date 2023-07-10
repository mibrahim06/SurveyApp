namespace SurveyApp.DataTransferObjects.Incoming;

public class QuestionAnswerRequest
{
    public int QuestionId { get; set; }
    public List<string> Answers { get; set; }
}