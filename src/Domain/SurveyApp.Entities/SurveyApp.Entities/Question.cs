namespace SurveyApp.Entities;

public enum OptionType
{
    Text = 0,
    MultipleChoice = 1,
    SingleChoice = 2,
    Rating = 3
}

public class Question : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
    public OptionType OptionType { get; set; }
    public ICollection<Option> Options { get; set; }
}