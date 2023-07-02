using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Entities;

public enum AnswerType
{
    Text = 0,
    MultipleChoice = 1,
    SingleChoice = 2,
    Rating = 3
}

public class AnswerOption
{
    public int Id { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public string OptionText { get; set; }
    public int? RatingValue { get; set; }
}

public class Answer : IEntity
{ 
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public AnswerType AnswerType { get; set; }
    public string AnswerText { get; set; }
    public List<AnswerOption> Options { get; set; }
    public int? Rating { get; set; }
}