using SurveyApp.Entities;

namespace SurveyApp.Mvc.Models;

public class SurveyQuestionModel
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public AnswerType Type { get; set; }
    public List<QuestionAnswerModel> Answers { get; set; }
}