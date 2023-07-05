using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class SurveyQuestionModel
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public OptionType Type { get; set; }
    public List<QuestionOptionModel> Options { get; set; }
}