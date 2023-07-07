namespace SurveyApp.Entities;

public class SingleChoiceAnswer : Answer
{
    public new int Id { get; set; }
    public Option option;
}