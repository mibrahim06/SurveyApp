namespace SurveyApp.Entities;

public class Result : IEntity
{
    public int Id { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public string Text { get; set; } 
}