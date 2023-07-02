namespace SurveyApp.DataTransferObjects.Outgoing;

public class QuestionDisplayResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<AnswerDisplayResponse> Answers { get; set; } 
}