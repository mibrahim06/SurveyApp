namespace SurveyApp.Entities;

public class Question : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
    public AnswerType AnswerType { get; set; }
    public ICollection<Answer> Answers { get; set; }
}