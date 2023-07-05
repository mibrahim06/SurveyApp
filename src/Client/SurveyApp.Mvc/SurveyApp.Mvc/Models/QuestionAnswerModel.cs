namespace SurveyApp.Mvc.Models;

public class QuestionAnswerModel
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string answer { get; set; }
    public int count { get; set; }
}