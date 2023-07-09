namespace SurveyApp.DataTransferObjects.Incoming;

public class CreateAnswerRequest
{
    public int QuestionId { get; set; }
    public string Text { get; set; }
}