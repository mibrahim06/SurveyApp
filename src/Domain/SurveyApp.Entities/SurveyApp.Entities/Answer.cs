using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Entities;

public class Answer : IEntity
{
    public int Id { get; set; }
    public QuestionType Type { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    [AllowNull]
    public string Text { get; set; }
    [AllowNull]
    public int Rating { get; set; }
    [AllowNull]
    public int MultipleChoice { get; set; }
    [AllowNull]
    public int SingleChoice { get; set; }
}