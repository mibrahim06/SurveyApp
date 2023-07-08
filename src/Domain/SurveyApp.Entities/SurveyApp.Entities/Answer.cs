namespace SurveyApp.Entities;

public class Answer : IEntity
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public List<Option> Options { get; set; }
}