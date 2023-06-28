namespace SurveyApp.Entities;

public class Question : IEntity
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int SurveyId { get; set; }
    public QuestionType Type { get; set; }
    public Answer Answer { get; set; }
    public Survey Survey { get; set; }
}