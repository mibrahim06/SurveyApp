using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Entities;

public enum OptionType
{
    Text = 0,
    MultipleChoice = 1,
    SingleChoice = 2,
    Rating = 3
}

public class Option : IEntity
{ 
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public OptionType OptionType { get; set; }
}