namespace SurveyApp.Entities;

public class MultipleChoiceAnswer : Answer
{
    public new int Id { get; set; }
    public List<Option> options;
}