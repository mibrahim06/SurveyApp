using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class QuestionAnswerModel
{
    public int Id { get; set; }
    public QuestionType Type { get; set; }
    public string Text { get; set; } = default!;
    public int Rating { get; set; }
    public int MultipleChoice { get; set; }
    public int SingleChoice { get; set; }
}